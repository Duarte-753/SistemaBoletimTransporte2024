using Microsoft.AspNetCore.Mvc;

namespace SistemaBoletimTransporteDigital.Controllers
{
    public class LandingPageController : Controller
    {
        public IActionResult Index()
        { 
            return View();
        }
    }
}
