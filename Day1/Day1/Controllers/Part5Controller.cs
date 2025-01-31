using Microsoft.AspNetCore.Mvc;

namespace Day1.Controllers
{
    public class Part5Controller : Controller
    {
        [NonAction]
        public string NonActionFun()
        {
            return "This is not an action method.";
        }

        [HttpGet]
        public IActionResult ActionFun()
        {
            
            return Content("Amr Tarek");
        }

        private string PrivateFun()
        {
            return "This is a private method.";
        }
    }
}
