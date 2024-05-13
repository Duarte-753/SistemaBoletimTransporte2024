﻿using Microsoft.AspNetCore.Mvc;
using SistemaBoletimTransporteDigital.Dashboard;
using SistemaBoletimTransporteDigital.Enums;
using SistemaBoletimTransporteDigital.Helper;
using SistemaBoletimTransporteDigital.Models;

using System.Diagnostics;

namespace SistemaBoletimTransporteDigital.Controllers
{
    public class HomeController : Controller
    {
        private readonly DashboardCorridasService _dashboardCorridas;
        private readonly ISessao _sessao;
      
        public HomeController(DashboardCorridasService dashboardCorridas, ISessao sessao)
        {
            _dashboardCorridas = dashboardCorridas ?? throw
                new ArgumentNullException(nameof(dashboardCorridas));
            _sessao = sessao;
        }
       
        public JsonResult CarroDisponivelstatus()
        {
            var VeiculosUso = _dashboardCorridas.GetCarrosEmUso();
            return Json(VeiculosUso);
        }
        public JsonResult MotoristaDisponivel()
        {
            var MotoristaDisponivel = _dashboardCorridas.GetMotoristaEmCorridas();
            return Json(MotoristaDisponivel);
        }
        public JsonResult CorridasVeiculos(int dias)
        {
            var corridasVeiculos = _dashboardCorridas.GetCorridasFeitas(dias);
            return Json(corridasVeiculos);
        }
        public JsonResult CadastrosV_M()
        {
            var cadastros = _dashboardCorridas.GetCadastros();
            return Json(cadastros);
        }

        //public JsonResult DashboardData(int dias)
        //{
        //    var cadastros = _dashboardCorridas.GetCadastros();
        //    var carrosEmUso = _dashboardCorridas.GetCarrosEmUso();
        //    var motoristasEmCorrida = _dashboardCorridas.GetMotoristaEmCorridas();
        //    var corridasFeitas = _dashboardCorridas.GetCorridasFeitas(dias);

        //    var dashboardData = new DashboardData
        //    {
        //        Cadastros = cadastros,
        //        CarrosEmUso = carrosEmUso,
        //        MotoristasEmCorrida = motoristasEmCorrida,
        //        CorridasFeitas = corridasFeitas
        //    };

        //    return Json(dashboardData);
        //}


        [HttpGet]
        public IActionResult Index()
        {
            UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();

            // Verifica se o usuário está logado e se seu perfil é motorista
            if (usuarioLogado != null && usuarioLogado.Perfil == PerfilEnum.motorista)
            {
                return RedirectToAction("IndexMotorista");
            }
            else
            {
                // Caso contrário, redireciona para a página padrão do admin
                return View();
            }
        }

        private object ObterUsuarioLogado()
        {
            return new UsuarioModel { Perfil = PerfilEnum.motorista };
        }

        public IActionResult IndexMotorista()
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