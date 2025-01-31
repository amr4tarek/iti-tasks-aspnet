using Microsoft.AspNetCore.Mvc;

namespace Day1.Controllers
{
    public class Part4Controller : Controller
    {
        // tempdata 
        public IActionResult TempDataFun()
        {
            TempData["Message"] = "TempData example.";
            return RedirectToAction("TempDataMsg");
        }

        public IActionResult TempDataMsg()
        {
            
            return Content(TempData["Message"] as string);
        }

        // viewBag
        public IActionResult ViewBagFun()
        {
            ViewBag.Message = "ViewBag example.";
            return View();
        }

        //viewData
        public IActionResult ViewDataFun()
        {
            ViewData["Message"] = "ViewData example.";
            return View();
        }


    }
}
