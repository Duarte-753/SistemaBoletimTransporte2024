using Microsoft.AspNetCore.Mvc;

namespace SistemaBoletimTransporteDigital.Controllers
{
    public class ManutencaoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CriarManutencao()
        {
            return View();
        }
    }
}
