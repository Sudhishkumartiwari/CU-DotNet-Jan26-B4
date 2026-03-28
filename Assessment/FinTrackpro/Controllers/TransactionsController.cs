using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinTrackpro.Data;
using FinTrackpro.Models;

namespace FinTrackpro.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly FinTrackproContext _context;

        public TransactionsController(FinTrackproContext context)
        {
            _context = context;
        }

        // compute current balance for an account using stored initial Balance and existing transactions
        private async Task<double> GetCurrentBalanceAsync(int accountId, int? excludeTransactionId = null)
        {
            var account = await _context.Account.FindAsync(accountId);
            if (account == null)
            {
                return 0.0;
            }

            var balance = account.Balance;

            var txs = await _context.Transaction
                .Where(t => t.AccountId == accountId && (!excludeTransactionId.HasValue || t.Id != excludeTransactionId.Value))
                .ToListAsync();

            foreach (var t in txs)
            {
                if (string.Equals(t.Category, "debit", StringComparison.OrdinalIgnoreCase))
                {
                    balance -= t.Amount;
                }
                else
                {
                    balance += t.Amount;
                }
            }

            return balance;
        }

        // GET: Transactions
        public async Task<IActionResult> Index()
        {
            var finTrackproContext = _context.Transaction.Include(t => t.Account);
            return View(await finTrackproContext.ToListAsync());
        }

        // GET: Transactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction
                .Include(t => t.Account)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // GET: Transactions/Create
        public async Task<IActionResult> Create(int? accountId)
        {
            ViewData["AccountId"] = new SelectList(_context.Account, "Id", "AccountName", accountId);

            var transaction = new Transaction();

            if (accountId.HasValue)
            {
                transaction.AccountId = accountId.Value;
                // expose current balance to the view so user can see before creating debit
                ViewBag.CurrentBalance = await GetCurrentBalanceAsync(accountId.Value);
            }
            return View(transaction);
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,Amount,Category,Date,AccountId")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                // check sufficient balance for debit (trim and ignore case)
                if (!string.IsNullOrWhiteSpace(transaction.Category) &&
                    string.Equals(transaction.Category.Trim(), "debit", StringComparison.OrdinalIgnoreCase))
                {
                    var current = await GetCurrentBalanceAsync(transaction.AccountId);
                    if (current - transaction.Amount < 0)
                    {
                        ModelState.AddModelError("Amount", "Insufficient balance to perform this debit.");
                        ViewData["AccountId"] = new SelectList(_context.Account, "Id", "AccountName", transaction.AccountId);
                        ViewBag.CurrentBalance = current;
                        return View(transaction);
                    }
                }

                _context.Add(transaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountId"] = new SelectList(_context.Account, "Id", "AccountName", transaction.AccountId);
            return View(transaction);
        }

        // GET: Transactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            ViewData["AccountId"] = new SelectList(_context.Account, "Id", "AccountName", transaction.AccountId);
            // show current balance excluding this transaction
            ViewBag.CurrentBalance = await GetCurrentBalanceAsync(transaction.AccountId, excludeTransactionId: transaction.Id);
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,Amount,Category,Date,AccountId")] Transaction transaction)
        {
            if (id != transaction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionExists(transaction.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountId"] = new SelectList(_context.Account, "Id", "AccountName", transaction.AccountId);
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction
                .Include(t => t.Account)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaction = await _context.Transaction.FindAsync(id);
            if (transaction != null)
            {
                _context.Transaction.Remove(transaction);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionExists(int id)
        {
            return _context.Transaction.Any(e => e.Id == id);
        }
    }
}
