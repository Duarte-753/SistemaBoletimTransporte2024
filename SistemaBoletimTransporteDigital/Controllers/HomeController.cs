using Microsoft.AspNetCore.Mvc;
using SistemaBoletimTransporteDigital.Helper;
using SistemaBoletimTransporteDigital.Models;
using SistemaBoletimTransporteDigital.Repositorio;
using System.Diagnostics;

namespace SistemaBoletimTransporteDigital.Controllers
{
    public class HomeController : Controller
    {     

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