using Microsoft.AspNetCore.Mvc;

namespace SistemaBoletimTransporteDigital.Controllers
{
    public class RelatorioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
