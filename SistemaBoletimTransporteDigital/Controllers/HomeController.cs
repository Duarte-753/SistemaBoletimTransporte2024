using Microsoft.AspNetCore.Mvc;
using SistemaBoletimTransporteDigital.Dashboard;
using SistemaBoletimTransporteDigital.Models;

using System.Diagnostics;

namespace SistemaBoletimTransporteDigital.Controllers
{
    public class HomeController : Controller
    {
        private readonly DashboardCorridasService _dashboardCorridas;

        public HomeController(DashboardCorridasService dashboardCorridas)
        {
            _dashboardCorridas = dashboardCorridas ?? throw
                new ArgumentNullException(nameof(dashboardCorridas));
        }

        public JsonResult CorridasVeiculos(int dias)
        {
            var corridasVeiculos = _dashboardCorridas.GetCorridasFeitas(dias);       
            return Json(corridasVeiculos);
        }

        [HttpGet]
        public IActionResult Index()
        {           
            return View();
        }

        public IActionResult LandingPage()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}