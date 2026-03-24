using Microsoft.AspNetCore.Mvc;
using QuickLoan.Models;


namespace QuickLoan.Controllers
{
    public class LoanController : Controller
    {
     
        private static List<Loan> _loans = new List<Loan>
        {
            new Loan { Id = 1, BorrowerName = "Hritik Singh", LenderName = "QuickLoan", Amount = 50000, IsSettled = true },
            new Loan { Id = 2, BorrowerName = "Samwell", LenderName = "Aegon", Amount = 10540, IsSettled = false },
            new Loan { Id = 3, BorrowerName = "Aegon", LenderName = "Ned", Amount = 24368, IsSettled = false },
            new Loan { Id = 4, BorrowerName = "Rehar", LenderName = "Ned", Amount = 85382, IsSettled = true },
            new Loan { Id = 5, BorrowerName = "Jorah", LenderName = "Samwell", Amount = 90000, IsSettled = false }
        };

        public IActionResult Index()
        {
            return View(_loans);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Loan loan)
        {
            if (ModelState.IsValid)
            {
                loan.Id = _loans.Count > 0 ? _loans.Max(l => l.Id) + 1 : 1;
                _loans.Add(loan);
                return RedirectToAction("Index"); 
            }
            return View(loan);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var loan = _loans.FirstOrDefault(l => l.Id == id);
            if (loan == null) return NotFound();
            return View(loan);
        }

        [HttpPost]
        public IActionResult Edit(Loan updatedLoan)
        {
            if (ModelState.IsValid)
            {
                var loan = _loans.FirstOrDefault(l => l.Id == updatedLoan.Id);
                if (loan != null)
                {
                    loan.BorrowerName = updatedLoan.BorrowerName;
                    loan.LenderName = updatedLoan.LenderName;
                    loan.Amount = updatedLoan.Amount;
                    loan.IsSettled = updatedLoan.IsSettled;
                }
                return RedirectToAction("Index");
            }
            return View(updatedLoan);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var loan = _loans.FirstOrDefault(l => l.Id == id);
            if (loan != null) _loans.Remove(loan);
            return RedirectToAction("Index");
        }
    }
}