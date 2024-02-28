using Microsoft.AspNetCore.Mvc;

namespace SistemaBoletimTransporteDigital.Controllers
{
    public class BoletimController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
