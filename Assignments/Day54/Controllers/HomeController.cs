using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WEEKMVC.Models;

namespace WEEKMVC.Controllers
{

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
