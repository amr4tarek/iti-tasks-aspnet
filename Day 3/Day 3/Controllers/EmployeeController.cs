using Microsoft.AspNetCore.Mvc;
using Day_3.Models;

namespace Day_3.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly CompanyDbContext _context;

        public EmployeeController(CompanyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult EmployeeForm()
        {
            return View();
        }
        // Employee/EmployeeForm/
        [HttpPost]
        public IActionResult EmployeeForm(Employee emp)
        {
            _context.Add(emp);
            _context.SaveChanges();
            TempData["Name"] = emp.Name;
            TempData["Age"] = emp.Age;
            TempData["City"] = emp.City;
            return RedirectToAction("Details");
        }
        // Employee/Details/
        public IActionResult Details()
        {
            return View();
        }
    }
}
