using Microsoft.AspNetCore.Mvc;

namespace PontoDigital_Definitivo.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}