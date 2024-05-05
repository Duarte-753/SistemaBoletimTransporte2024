using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;
using SistemaBoletimTransporteDigital.Data;
using SistemaBoletimTransporteDigital.Helper;
using SistemaBoletimTransporteDigital.Models;
using SistemaBoletimTransporteDigital.Repositorio;
using SistemaBoletimTransporteDigital.ViewModels;

namespace SistemaBoletimTransporteDigital.Controllers
{
    public class BoletimVeiculoController : Controller
    {
        private readonly BancoContext _bancoContext;
        private readonly ICorridaRepositorio _corridaRepositorio;
        private readonly ISessao _sessao;
        private readonly IVeiculoRepositorio _veiculoRepositorio;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IManutencaoRepositorio _manutencaoRepositorio;


        public BoletimVeiculoController(ICorridaRepositorio corridaRepositorio, ISessao sessao, IVeiculoRepositorio veiculoRepositorio,
            BancoContext bancoContext, IUsuarioRepositorio usuarioRepositorio, IManutencaoRepositorio manutencaoRepositorio)
        {
            _bancoContext = bancoContext;
            _corridaRepositorio = corridaRepositorio;
            _sessao = sessao;
            _veiculoRepositorio = veiculoRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
            _manutencaoRepositorio = manutencaoRepositorio;
        }

        public async Task<IActionResult> Index(DateTime dataInicio, DateTime dataFinal, BoletimViewModel model)
        {         
            dataFinal = dataFinal.AddDays(1).AddSeconds(-1);
            int veiculoId = model.VeiculoId;

            var veiculosid = _veiculoRepositorio.ListarPorIdVeiculos(veiculoId);

            // Realizar a consulta no banco de dados usando as datas fornecidas            
            var corridas = await _bancoContext.Corridas
                               .Where(c => c.DataInicioCorrida >= dataInicio &&
                               c.DataFinalCorrida <= dataFinal &&
                               c.VeiculoID == veiculosid.Id).ToListAsync();

            var manutencoes = await _bancoContext.Manutencoes
                               .Where(c => c.DataManutencao >= dataInicio &&
                               c.DataManutencao <= dataFinal &&
                               c.VeiculoID == veiculosid.Id).ToListAsync();
            var viewModel = new BoletimViewModel
            {
                Filtros = new Filtro
                {
                    DataFinal = dataFinal,
                    DataInicial = dataInicio,
                },
                DadosCorrida = corridas,
                DadosManutencao = manutencoes
            };
            var corrida = new CorridaModel();
            corrida.VeiculosDisponiveis = _veiculoRepositorio.BuscarVeiculos();

            var usuario = new UsuarioModel();
            usuario.UsuariosDisponiveis = _usuarioRepositorio.BuscarUsuario();

            return View(viewModel);
        }
     
        public async Task<IActionResult> BoletimVeiculoPdf(DateTime dataInicio, DateTime dataFinal, int veiculoId)
        {          
            
            dataFinal = dataFinal.AddDays(1).AddSeconds(-1);

            var veiculo = await _bancoContext.Veiculos.Where(w => w.Id == veiculoId).FirstOrDefaultAsync();
            var viewModel = new BoletimViewModel
            {
                Filtros = new Filtro
                {
                    DataFinal = dataFinal,
                    DataInicial = dataInicio,

                },
                Placa = veiculo.Placa,
                VeiculoNome = veiculo.Veiculo,
                DadosCorrida = await _bancoContext.Corridas
                                .Include(i => i.Veiculo)
                                .Include(i => i.Usuario)
                               .Where(c => c.DataInicioCorrida >= dataInicio
                                   && c.DataFinalCorrida <= dataFinal
                                   && c.VeiculoID == veiculoId)
                               .ToListAsync(),

                DadosManutencao = await _bancoContext.Manutencoes
                                .Include(i => i.Veiculo)
                               .Where(c => c.DataManutencao >= dataInicio
                                   && c.DataManutencao <= dataFinal
                                   && c.VeiculoID == veiculoId)
                               .ToListAsync()
            };

            var corrida = new CorridaModel();
            corrida.VeiculosDisponiveis = _veiculoRepositorio.BuscarVeiculos();

            var usuario = new UsuarioModel();
            usuario.UsuariosDisponiveis = _usuarioRepositorio.BuscarUsuario();
           
            var pdfOptions = new ViewAsPdf("BoletimVeiculoPdf", viewModel)
            {
                FileName = dataInicio.Date.ToString("dd-MM-yyyy") + "_" + dataFinal.Date.ToString("dd-MM-yyyy") + "_Boletim.pdf",
                PageSize = Rotativa.AspNetCore.Options.Size.A4,
                PageMargins = new Rotativa.AspNetCore.Options.Margins(10, 10, 10, 10),
            };

            return pdfOptions;

        }



        public IActionResult SelecaoVeiculo(BoletimViewModel model)
        {
            
            // Definir datas padrão caso não tenham sido fornecidas
            if (!model.Filtros.DataInicial.HasValue)
            {
                model.Filtros.DataInicial = DateTime.Now.AddMonths(-1);
            }
            DateTime dataInicio = DateTime.Now.AddMonths(-1);

            if (!model.Filtros.DataFinal.HasValue)
            {
                model.Filtros.DataFinal = DateTime.Now.AddDays(1).AddSeconds(-1);
            }
            // Adiciona o tempo 23:59:59 à data final
            DateTime dataFinal = DateTime.Now.AddDays(1).AddSeconds(-1).AddDays(-1);

            var viewModel = new BoletimViewModel
            {
                Filtros = new Filtro
                {
                    DataFinal = dataFinal,
                    DataInicial = dataInicio,
                }, 
                DadosVeiculos = _veiculoRepositorio.BuscarVeiculos()
            };
        
            return View(viewModel);          
        }

        public async Task<IActionResult> ManutencaoVeiculo(DateTime dataInicio, DateTime dataFinal, int veiculoId)
        {

            dataFinal = dataFinal.AddDays(1).AddSeconds(-1);

            var veiculo = await _bancoContext.Veiculos.Where(w => w.Id == veiculoId).FirstOrDefaultAsync();
            var viewModel = new BoletimViewModel
            {
                Filtros = new Filtro
                {
                    DataFinal = dataFinal,
                    DataInicial = dataInicio,

                },

                DadosManutencao = await _bancoContext.Manutencoes
                                .Include(i => i.Veiculo)
                               .Where(c => c.DataManutencao >= dataInicio
                                   && c.DataManutencao <= dataFinal
                                   && c.VeiculoID == veiculoId)
                               .ToListAsync()
            };

            return View(viewModel);
        }

        public IActionResult DetalhesDaManutencao(int Id)
        {
            ManutencaoModel manutencaoModel =  _manutencaoRepositorio.ListarPorIdManutencao(Id);

            var manutencaoModeldetalhes = new ManutencaoModel();
            manutencaoModeldetalhes.VeiculosDisponiveis = _veiculoRepositorio.BuscarVeiculos();

            return View(manutencaoModel);
        }

    }
}
