
using Microsoft.AspNetCore.Mvc;
using SistemaBoletimTransporteDigital.Models;
using SistemaBoletimTransporteDigital.Repositorio;

namespace SistemaBoletimTransporteDigital.Controllers
{
    public class UsuarioController : Controller
    {
        
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            List<UsuarioModel>  usuarios = _usuarioRepositorio.BuscarUsuario();
            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            UsuarioModel usuarioRepositorio = _usuarioRepositorio.ListarPorId(id);
            return View(usuarioRepositorio);
        }

        
        public IActionResult Detalhes(int id)
        {
            UsuarioModel usuarioRepositorio = _usuarioRepositorio.ListarPorId(id);
            return View(usuarioRepositorio);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            UsuarioModel usuarioRepositorio = _usuarioRepositorio.ListarPorId(id);
            return View(usuarioRepositorio);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado =_usuarioRepositorio.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Usuário apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Erro ao apagar o Usuário, detalhe do erro: ";
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao cadastrar o Usuário, tente novamente! detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuarioRepositorio)
        {
            //try
            //{
            //    if (ModelState.IsValid) // validação dos campos 
            //    {
            //        _usuarioRepositorio.Adicionar(usuarioRepositorio);
            //        TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
            //        return RedirectToAction("Index");
            //    }

            //    return View(usuarioRepositorio);
            //}
            //catch (Exception ex)
            //{
            //    TempData["MensagemErro"] = $"Erro ao cadastrar o Usuário, tente novamente! detalhe do erro: {ex.Message}";
            //    return RedirectToAction("Index");
            //}

            try
            {
                // Verificar a unicidade do código funcional
                var existingUsuario = _usuarioRepositorio.BuscarPorCodigoFuncional(usuarioRepositorio.CodigoFuncional);
                var existingUsuarioByUsername = _usuarioRepositorio.BuscarPorNomeUsuario(usuarioRepositorio.Usuario);
                var existingUsuarioByEmail = _usuarioRepositorio.BuscarPorEmail(usuarioRepositorio.Email);
                if (existingUsuario != null)
                {
                    ModelState.AddModelError("CodigoFuncional", "Este código funcional já está em uso.");
                    return View(usuarioRepositorio);
                }

                if (existingUsuarioByUsername != null)
                {
                    ModelState.AddModelError("Usuario", "Este nome de usuário já está em uso.");
                    return View(usuarioRepositorio);
                }
               
                if (existingUsuarioByEmail != null)
                {
                    ModelState.AddModelError("Email", "Este e-mail já está em uso.");
                    return View(usuarioRepositorio);
                }

                if (ModelState.IsValid) // validação dos campos 
                {
                    _usuarioRepositorio.Adicionar(usuarioRepositorio);
                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(usuarioRepositorio);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao cadastrar o Usuário, tente novamente! Detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Editar(UsuarioModel usuarioRepositorio)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.EditarUsuario(usuarioRepositorio);
                    TempData["MensagemSucesso"] = "Usuário editado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(usuarioRepositorio);
            }
            catch(Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao editar o Usuário, tente novamente! detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        

            

    }
}
