using DashBoard.Models;
using Microsoft.AspNetCore.Mvc;

namespace DashBoard.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult Dashboard()
        {
            // Simulating database data
            List<Employee> employees = new List<Employee>()
            {
                new Employee { EmployeeId = 1, Name = "Rahul Sharma", Position = "Software Engineer", Salary = 60000 },
                new Employee { EmployeeId = 2, Name = "Priya Singh", Position = "UI Designer", Salary = 55000 },
                new Employee { EmployeeId = 3, Name = "Aman Verma", Position = "QA Analyst", Salary = 50000 },
                new Employee { EmployeeId = 4, Name = "Riya Kapoor", Position = "Project Manager", Salary = 75000 }
            };

            // ViewBag → Announcement
            ViewBag.Announcement = "🎉 Company Meeting Today at 4 PM";

            // ViewData → Static configuration
            ViewData["DepartmentName"] = "Software Development";
            ViewData["ServerStatus"] = true;

            return View(employees);
        }
    }
}
