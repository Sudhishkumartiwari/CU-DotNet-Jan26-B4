using FinTrackpro.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinTrackpro.Controllers
{
    [Route("Portfolio")]
    public class PortfolioController : Controller
    {
        private static List<Transaction> Transactions = new List<Transaction>
        {
            new Transaction
            {
                 Id = 1,
                Description = "Bought TCS Shares",
                Amount = 12000,
                Category = "Investment",
                Date = DateTime.Now.AddDays(-5)
            },
             new Transaction
            {
                Id = 2,
                Description = "Bought Infosys Shares",
                Amount = 15000,
                Category = "Investment",
                Date = DateTime.Now.AddDays(-2)
            },
            new Transaction
            {
                Id = 3,
                Description = "Bought HDFC Bank Shares",
                Amount = 18000,
                Category = "Investment",
                Date = DateTime.Now.AddDays(-1)
            }
        };
        [HttpGet("Index")]
        public IActionResult Index()
        {
            ViewData["Total"] = Transactions.Sum(t => t.Amount);
            return View(Transactions);
        }
        [HttpGet]
        [Route("/Asset/Info/{id:int}")]
        public IActionResult Details(int id)
        {
            var item = Transactions.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
       
        [HttpGet("/Delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            var item = Transactions.FirstOrDefault(t => t.Id == id);
            if (item != null)
            {
                Transactions.Remove(item);
                TempData["Message"] = "Portfolio record deleted successfully";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
