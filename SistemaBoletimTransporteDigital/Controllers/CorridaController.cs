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
        private readonly BancoContext _context;
        private readonly ISessao _sessao;
        private readonly IVeiculoRepositorio _veiculoRepositorio;

        public CorridaController(ICorridaRepositorio corridaRepositorio, ISessao sessao, IVeiculoRepositorio veiculoRepositorio, BancoContext context)
        {
            _corridaRepositorio = corridaRepositorio;
            _sessao = sessao;
            _veiculoRepositorio = veiculoRepositorio;
            _context = context;
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

        public async Task<IActionResult> CriarCorrida()
        {
            var dropdown = await _context.Veiculos
                .Select(s => new { Id = s.Id, Veiculo = s.Veiculo + " | " + s.Cor + " | " + s.Placa })
                .ToListAsync();

            ViewData["VeiculosDisponiveis"] = new SelectList(dropdown, "Id", "Veiculo");


            return View();
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
                if (ModelState.IsValid)
                {                 

                    _corridaRepositorio.FinalizarCorrida(corridaRepositorio);
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
