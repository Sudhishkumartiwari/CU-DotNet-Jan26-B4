using Microsoft.AspNetCore.Mvc;

namespace WEEKMVC.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Software()
        {
            return View();
        }

        public IActionResult Tools()
        {
            return View();
        }
    }
}
