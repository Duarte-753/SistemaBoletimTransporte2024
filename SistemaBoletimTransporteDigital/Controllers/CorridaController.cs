using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaBoletimTransporteDigital.Data;
using SistemaBoletimTransporteDigital.Helper;
using SistemaBoletimTransporteDigital.Models;
using SistemaBoletimTransporteDigital.Repositorio;

namespace SistemaBoletimTransporteDigital.Controllers
{
    public class CorridaController : Controller
    {
        private readonly ICorridaRepositorio _corridaRepositorio;
        private readonly BancoContext _bancoContext;
        private readonly ISessao _sessao;
        private readonly IVeiculoRepositorio _veiculoRepositorio;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public CorridaController(ICorridaRepositorio corridaRepositorio, ISessao sessao, IVeiculoRepositorio veiculoRepositorio, BancoContext context,IUsuarioRepositorio usuario)
        {
            _corridaRepositorio = corridaRepositorio;
            _sessao = sessao;
            _veiculoRepositorio = veiculoRepositorio;
            _bancoContext = context;
            _usuarioRepositorio = usuario;
        }
        public IActionResult Index()
        {
            
            UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
            List<CorridaModel> corridas = _corridaRepositorio.BuscarCorrida(usuarioLogado.Id); // buscando somente a corrida do usuario



            //var dropdown = _veiculoRepositorio.BuscarVeiculos();
            //ViewBag.VeiculosDisponiveis = new SelectList(dropdown, "Id", "Veiculo");

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
                    _corridaRepositorio.UsoVeiculo(corridaRepositorio);

                    var buscaUsuario = _corridaRepositorio.ListarPorId(corridaRepositorio.Id);

                    _usuarioRepositorio.CorridaStatusUserI(buscaUsuario);

                    TempData["MensagemSucesso"] = "Corrida Iniciada com sucesso!";
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



        public IActionResult FinalizarCorrida(int id)
        {
            CorridaModel corridaRepositorio = _corridaRepositorio.ListarPorId(id);
            return View(corridaRepositorio);
        }

        [HttpPost]
        public IActionResult FinalizarCorrida(CorridaModel corridaRepositorio)
        {
            try
            {
                if (corridaRepositorio != null)
                {
                    UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                    

                    _corridaRepositorio.FinalizarCorrida(corridaRepositorio, usuarioLogado.Id);

                    var buscaVeiculo = _corridaRepositorio.ListarPorId(corridaRepositorio.Id);

                    _corridaRepositorio.NaoUsoVeiculo(buscaVeiculo);
                    _corridaRepositorio.CalcKmPercorrido(corridaRepositorio);

                    var buscaUsuario = _corridaRepositorio.ListarPorId(corridaRepositorio.Id);

                    _usuarioRepositorio.CorridaStatusUserF(buscaUsuario);

                    TempData["MensagemSucesso"] = "Corrida Finalizada com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(corridaRepositorio);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao finalizar a corrida, tente novamente! detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }  

    }
}
