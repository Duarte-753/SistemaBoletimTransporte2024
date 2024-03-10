using Microsoft.AspNetCore.Mvc;
using SistemaBoletimTransporteDigital.Helper;
using SistemaBoletimTransporteDigital.Models;
using SistemaBoletimTransporteDigital.Repositorio;

namespace SistemaBoletimTransporteDigital.Controllers
{
    public class CorridaController : Controller
    {
        private readonly ICorridaRepositorio _corridaRepositorio;
        private readonly ISessao _sessao;
        private readonly IVeiculoRepositorio _veiculoRepositorio;

        public CorridaController(ICorridaRepositorio corridaRepositorio , ISessao sessao, IVeiculoRepositorio veiculoRepositorio)
        {
            _corridaRepositorio = corridaRepositorio;
            _sessao = sessao;
            _veiculoRepositorio = veiculoRepositorio;
        }
        public IActionResult Index()
        {
            
            UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
            List<CorridaModel> corridas = _corridaRepositorio.BuscarCorrida(usuarioLogado.Id); // buscando somente a corrida do usuario

            var corrida = new CorridaModel();
            corrida.VeiculosDisponiveis = _veiculoRepositorio.BuscarVeiculos();

            return View(corridas);
        }

        public IActionResult CriarCorrida()
        {
            var corrida = new CorridaModel();
            corrida.VeiculosDisponiveis = _veiculoRepositorio.BuscarVeiculos();

            return View(corrida);
        }

        [HttpPost]
        public IActionResult CriarCorrida(CorridaModel corridaRepositorio)
        {
            try
            {
                if (ModelState.IsValid) // validação dos campos 
                {
                    UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                    

                    _corridaRepositorio.AdicionarCorrida(corridaRepositorio, usuarioLogado.Id);
                    return RedirectToAction("CarroKmCorrida");
                }
                return View(corridaRepositorio);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao iniciar a corrida, tente novamente! detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

      /* public IActionResult FinalizarCorrida(int id)
        {
            CorridaModel corridaRepositorio = _corridaRepositorio.BuscarCorrida(id);
            return View(corridaRepositorio);
        }
        [HttpPost]
        public IActionResult FinalizarCorrida(int id)
        {
            VeiculoModel corridaRepositorio = _veiculoRepositorio.ListarPorIdVeiculos(corridaRepositorio);
            return View(corridaRepositorio);
        }*/

        public IActionResult CarroKmCorrida(int id)
        {
            try
            {               
                VeiculoModel veiculo = _veiculoRepositorio.ListarPorIdVeiculos(id);

                if (veiculo != null)
                {
                    return View(veiculo);
                }

                TempData["MensagemErro"] = "Veículo não encontrado.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao carregar dados do veículo, tente novamente! Detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult CarroKmCorrida(VeiculoModel veiculoRepositorio)
        {
            if (veiculoRepositorio.Id != 0)
            {
                _veiculoRepositorio.KmVeiculo(veiculoRepositorio);              
                return RedirectToAction("Index", "Corrida");
            }
            else
            {
                TempData["MensagemErro"] = "Erro ao colocar o KM do Veículo, tente novamente!";
                return RedirectToAction("Index");
            }
        }

        

    }
}
