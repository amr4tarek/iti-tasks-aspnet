using Day_4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day_4.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly CompanyDbContext _context;

        public DepartmentController(CompanyDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string name)
        {
            if (ModelState.IsValid)
            {
                var department = new Department
                {
                    Name = name
                };
                _context.Add(department);
                _context.SaveChanges();
                return RedirectToAction("Index", "Employee");
            }
            return View();
        }
    }
}
