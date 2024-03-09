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

        public IActionResult ConfirmacaoIniciarCorrida()
        {
            return View();
        }

        // // // // // // // // metodos referente a view// // // // // // // // // // // // // // // // // // 
        [HttpPost]
        public IActionResult CriarCorrida(CorridaModel corridaRepositorio)
        {
            try
            {
                if (ModelState.IsValid) // validação dos campos 
                {
                    UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();

                    _corridaRepositorio.AdicionarCorrida(corridaRepositorio, usuarioLogado.Id);
                    return RedirectToAction("Index");
                }
                return View(corridaRepositorio);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao iniciar a corrida, tente novamente! detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
