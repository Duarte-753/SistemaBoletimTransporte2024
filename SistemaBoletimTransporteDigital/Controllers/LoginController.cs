using Microsoft.AspNetCore.Mvc;

using SistemaBoletimTransporteDigital.Helper;
using SistemaBoletimTransporteDigital.Models;
using SistemaBoletimTransporteDigital.Repositorio;

namespace SistemaBoletimTransporteDigital.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;
        private readonly IEmail _email;
        
        public LoginController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao, IEmail email)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
            _email = email;
        }
        public IActionResult Index()
        { // se o usuario estiver logado redirecionar para tela home
            if (_sessao.BuscarSessaoDoUsuario() != null)
            {
                return RedirectToAction("Index", "Home");
            }          
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult RedefinirSenha()
        {
            return View();
        }
        public IActionResult ConfirmarToken()
        {
            return View();
        }

        public IActionResult EditarNovaSenha(int id)//quando for posto o token vai fazer busca referente ai ID e salvar o id na variavel ID.
        {
            try
            {
                // Buscar o usuário com base no ID
                UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);

                if (usuario != null)
                {
                    return View(usuario);
                }

                TempData["MensagemErro"] = "Usuário não encontrado.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao carregar dados do usuário, tente novamente! Detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult EditarNovaSenha(UsuarioModel model)// colocar nova senha nova e atualizar nova senha do usuario.
        {           
                if (model.Id != 0)
                {
                    _usuarioRepositorio.EditarNovaSenha(model);
                    TempData["MensagemSucesso"] = "Senha atualizada com sucesso!";
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                TempData["MensagemErro"] = "Erro ao atualizar a senha do Usuário, tente novamente!";
                return RedirectToAction("Index");                
                }                                                                  
        }

        public IActionResult Sair()
        {
           _sessao.RemoverSessaoDoUsuario();

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);

                if (ModelState.IsValid)
                {
                    if (usuario != null)
                    { 
                        if(usuario.SenhaValida(loginModel.Senha))
                        {
                            _sessao.CriarSessaoDoUsuario(usuario); //vai criar a sessao do usuario assim que logar
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["MensagemErro"] = "Senha do usuário incorreta. Por favor, tente novamente!";

                    }

                    TempData["MensagemErro"] = "Usuário ou senha incorreto. Por favor, tente novamente!";

                }
                return View("Index");

            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao fazer Login no Sistema, tente novamente! detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult ConfirmarToken(TokenModel tokenModel)//validacao do token
        {
            try
            {
                UsuarioModel senha = _usuarioRepositorio.BuscarPorToken(tokenModel.Token.GerarHash());// validando o token digitado transformando em hash para salvar na variavel

                
                    if (senha != null)// só quero validar a senha token se não veio vazio
                    {
                        
                        if (senha.SenhaValida(tokenModel.Token))//vai validar o token se igual 
                        {
                        
                        return RedirectToAction("EditarNovaSenha", "Login", new { id = senha.Id });
                        }

                        TempData["MensagemErro"] = "Token do usuário incorreta. Por favor, tente novamente!";
                    }

                    TempData["MensagemErro"] = "Usuário ou Token incorreto. Por favor, tente novamente!";

                
                return View("Index");

            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao validar Token, tente novamente! detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult EnviarLinkParaRedefinirSenha(RedefinirSenhaModel redefinirSenhaModel)
        {

            try
            {              

                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorEmailLogin(redefinirSenhaModel.Email, redefinirSenhaModel.Login);

                    if (usuario != null)
                    {
                        string novaSenha = usuario.GerarNovaSenha();                   
                        string mensagem = $"Seu Token para redifinição de senha é: {novaSenha}";

                        bool emailEnviado = _email.Enviar(usuario.Email, "Sistema Boletim de Transporte Digital - Token", mensagem);                       
                       
                        if (emailEnviado)
                        {
                            _usuarioRepositorio.Atualizar(usuario);
                            TempData["MensagemSucesso"] = "Enviamos para seu e-mail cadastrado um Token.";
                            
                        }
                        else
                        {
                            TempData["MensagemErro"] = "Não conseguimos enviar e-mail. Por favor, tente novamente.";
                        }
                        return RedirectToAction("ConfirmarToken", "Login");

                    }

                    TempData["MensagemErro"] = "Erro ao redefinir a sua senha. Por favor, verifique os dados informados, tente novamente!";

                }
                return View("Index");

            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ops,Erro ao redefinir a sua senha, tente novamente! detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }

        }
       
        
    }
}
