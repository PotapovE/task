using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MyMvcUI.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Welcome(string name, int count = 1)
        {
            ViewData["Message"] = "Hi " + name;
            ViewData["Count"] = count;

            return View();
        }
    }
}