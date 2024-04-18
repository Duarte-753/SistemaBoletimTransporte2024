using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaBoletimTransporteDigital.Data;
using SistemaBoletimTransporteDigital.Helper;
using SistemaBoletimTransporteDigital.Models;
using SistemaBoletimTransporteDigital.Repositorio;
using SistemaBoletimTransporteDigital.ViewModels;

namespace SistemaBoletimTransporteDigital.Controllers
{
    public class BoletimController : Controller
    {
        private readonly BancoContext _bancoContext;
        private readonly ICorridaRepositorio _corridaRepositorio;
        private readonly ISessao _sessao;
        private readonly IVeiculoRepositorio _veiculoRepositorio;


        public BoletimController(ICorridaRepositorio corridaRepositorio, ISessao sessao, IVeiculoRepositorio veiculoRepositorio, BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
            _corridaRepositorio = corridaRepositorio;
            _sessao = sessao;
            _veiculoRepositorio = veiculoRepositorio;
        }

        public async Task<IActionResult> Index(BoletimViewModel model)
        {
            var usuarioLogado = _sessao.BuscarSessaoDoUsuario();
            var corridasUsuario = _corridaRepositorio.BuscarCorrida(usuarioLogado.Id);

            // Definir datas padrão caso não tenham sido fornecidas
            if (!model.Filtros.DataInicial.HasValue)
            {
                model.Filtros.DataInicial = DateTime.Now.AddMonths(-1);
            }

            if (!model.Filtros.DataFinal.HasValue)
            {
                model.Filtros.DataFinal = DateTime.Now;
            }

            // Realizar a consulta no banco de dados usando as datas fornecidas
            var corridas = await _bancoContext.Corridas
                 .Where(c => c.DataInicioCorrida >= model.Filtros.DataInicial && c.DataFinalCorrida <= model.Filtros.DataFinal &&
                      c.UsuarioID == usuarioLogado.Id
                ).ToListAsync();

            var viewModel = new BoletimViewModel
            {
                Filtros = model.Filtros,
                Dados = corridas// Usar os resultados da consulta como dados
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(DateTime dataInicio, DateTime dataFinal)
        {
            var corridas = await _bancoContext.Corridas
                                        .Where(c => c.DataInicioCorrida >= dataInicio && c.DataFinalCorrida <= dataFinal).ToListAsync();


            var viewModel = new BoletimViewModel
            {
                Filtros = new Filtro
                {
                    DataFinal = dataFinal,
                    DataInicial = dataInicio,
                },
                Dados = corridas// Usar os resultados da consulta como dados
            };

            return View(viewModel);
        }

        //[HttpPost]
        //public IActionResult Index()
        //{
        //    UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
        //    List<CorridaModel> corridas = _corridaRepositorio.BuscarCorrida(usuarioLogado.Id); // buscando somente a corrida do usuario
        //    //var dropdown = _veiculoRepositorio.BuscarVeiculos();
        //    //ViewBag.VeiculosDisponiveis = new SelectList(dropdown, "Id", "Veiculo");
        //    var corrida = new CorridaModel();
        //    corrida.VeiculosDisponiveis = _veiculoRepositorio.BuscarVeiculos();


        //    return View(corridas);
        //}

    }
}
