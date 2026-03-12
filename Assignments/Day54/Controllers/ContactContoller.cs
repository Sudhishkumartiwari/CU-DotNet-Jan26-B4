using Microsoft.AspNetCore.Mvc;

namespace WEEKMVC.Controllers
{
    public class ContactContoller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
