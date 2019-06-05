using Microsoft.AspNetCore.Mvc;

namespace PontoDigitalCSharp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}