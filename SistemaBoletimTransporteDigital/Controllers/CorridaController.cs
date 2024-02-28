using Microsoft.AspNetCore.Mvc;
using SistemaBoletimTransporteDigital.Models;

namespace SistemaBoletimTransporteDigital.Controllers
{
    public class CorridaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CriarCorrida()
        {
            return View();
        }
    }
}
