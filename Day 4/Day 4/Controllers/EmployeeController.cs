using Day_4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Day_4.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly CompanyDbContext _context;

        public EmployeeController(CompanyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();
            var departments = _context.Departments.ToDictionary(d => d.DepartmentId, d => d.Name);

            ViewData["Departments"] = departments;
            return View(employees);
        }

        public IActionResult Create()
        {
            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(string name, int age, string city, int departmentId)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee
                {
                    Name = name,
                    Age = age,
                    City = city,
                    DepartmentId = departmentId
                };
                _context.Add(employee);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "Name", departmentId);
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "Name", employee.DepartmentId);
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(int id, string name, int age, string city, int departmentId)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                employee.Name = name;
                employee.Age = age;
                employee.City = city;
                employee.DepartmentId = departmentId;

                _context.Update(employee);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "Name", departmentId);
            return View(employee);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _context.Employees
                .FirstOrDefault(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var employee = _context.Employees.Find(id);
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
