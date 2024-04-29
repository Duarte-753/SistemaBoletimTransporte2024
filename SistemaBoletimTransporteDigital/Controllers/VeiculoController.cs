using Microsoft.AspNetCore.Mvc;
using SistemaBoletimTransporteDigital.Models;
using SistemaBoletimTransporteDigital.Repositorio;

namespace SistemaBoletimTransporteDigital.Controllers
{
    public class VeiculoController : Controller
    {
        private readonly IVeiculoRepositorio _veiculoRepositorio;

        public VeiculoController(IVeiculoRepositorio veiculoRepositorio)
        {
            _veiculoRepositorio = veiculoRepositorio;
        }


        public IActionResult Index()
        {
            List<VeiculoModel> veiculos = _veiculoRepositorio.BuscarVeiculos();
            return View(veiculos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            VeiculoModel veiculoRepositorio = _veiculoRepositorio.ListarPorIdVeiculos(id);
            return View(veiculoRepositorio);
        }


        public IActionResult Detalhes(int id)
        {
            VeiculoModel veiculoRepositorio = _veiculoRepositorio.ListarPorIdVeiculos(id);
            return View(veiculoRepositorio);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            VeiculoModel veiculoRepositorio = _veiculoRepositorio.ListarPorIdVeiculos(id);
            return View(veiculoRepositorio);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _veiculoRepositorio.ApagarVeiculo(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Veículos apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Erro ao apagar o Veículos, detalhe do erro: ";
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao cadastrar o Veículos, tente novamente! detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(VeiculoModel veiculoRepositorio)
        {
            //try
            //{
            //    if (ModelState.IsValid) // validação dos campos 
            //    {
            //        _veiculoRepositorio.AdicionarVeiculo(veiculoRepositorio);
            //        TempData["MensagemSucesso"] = "Veículo cadastrado com sucesso!";
            //        return RedirectToAction("Index");
            //    }

            //    return View(veiculoRepositorio);
            //}
            //catch (Exception ex)
            //{
            //    TempData["MensagemErro"] = $"Erro ao cadastrar o Veículo, tente novamente! detalhe do erro: {ex.Message}";
            //    return RedirectToAction("Index");
            //}
            try
            {
                // Verificar a unicidade do prefixo
                var existingVeiculoByPrefixo = _veiculoRepositorio.BuscarPorPrefixo(veiculoRepositorio.Prefixo);
                var existingVeiculoByPlaca = _veiculoRepositorio.BuscarPorPlaca(veiculoRepositorio.Placa);

                if (existingVeiculoByPrefixo != null)
                {
                    ModelState.AddModelError("Prefixo", "Este prefixo já está em uso.");
                    return View(veiculoRepositorio);
                }

                // Verificar a unicidade da placa
                
                if (existingVeiculoByPlaca != null)
                {
                    ModelState.AddModelError("Placa", "Esta placa já está em uso.");
                    return View(veiculoRepositorio);
                }

                if (ModelState.IsValid) // validação dos campos 
                {
                    _veiculoRepositorio.AdicionarVeiculo(veiculoRepositorio);
                    TempData["MensagemSucesso"] = "Veículo cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(veiculoRepositorio);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao cadastrar o Veículo, tente novamente! Detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Editar(VeiculoModel veiculoRepositorio)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _veiculoRepositorio.EditarVeiculo(veiculoRepositorio);
                    TempData["MensagemSucesso"] = "Veículo editado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(veiculoRepositorio);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao editar o Veículo, tente novamente! detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
