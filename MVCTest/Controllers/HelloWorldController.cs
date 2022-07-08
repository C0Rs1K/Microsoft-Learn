using Microsoft.AspNetCore.Mvc;

namespace MVCTest.Controllers
{
    public class HelloWorldController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
