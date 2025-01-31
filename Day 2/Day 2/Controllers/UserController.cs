using Day1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Reflection;
using System.Xml.Linq;

namespace Day1.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult UserForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserForm(UserModel model)
        {
            TempData["Name"] = model.Name;
            TempData["Age"] = model.Age;
            TempData["Address"] = model.Address;
            TempData["Gender"] = model.Gender;
            return RedirectToAction("Details");
        }

        public IActionResult Details()
        {
            return View();
        }


    }
}
