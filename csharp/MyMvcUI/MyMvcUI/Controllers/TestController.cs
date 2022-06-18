using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MyMvcUI.Controllers
{
    public class TestController : Controller
    {
        public string Index()
        {
            return "This is good";
        }
        public string Welcome(string name, int ID)
        {
            return HtmlEncoder.Default.Encode($"Hi {name}! ID: {ID}");
        }
    }
}
