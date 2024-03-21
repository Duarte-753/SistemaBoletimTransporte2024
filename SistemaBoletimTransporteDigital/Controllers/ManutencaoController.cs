using Microsoft.AspNetCore.Mvc;
using SistemaBoletimTransporteDigital.Data;
using SistemaBoletimTransporteDigital.Helper;
using SistemaBoletimTransporteDigital.Models;
using SistemaBoletimTransporteDigital.Repositorio;

namespace SistemaBoletimTransporteDigital.Controllers
{
    public class ManutencaoController : Controller
    {
        private string _caminhoimagem;

        private readonly ICorridaRepositorio _corridaRepositorio;
        private readonly BancoContext _bancoContext;
        private readonly ISessao _sessao;
        private readonly IVeiculoRepositorio _veiculoRepositorio;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IManutencaoRepositorio _manutencaoRepositorio;

        public ManutencaoController(IManutencaoRepositorio manutencaoRepositorio, IWebHostEnvironment sistema, ICorridaRepositorio corridaRepositorio, ISessao sessao, IVeiculoRepositorio veiculoRepositorio, BancoContext context, IUsuarioRepositorio usuario)
        {
            _corridaRepositorio = corridaRepositorio;
            _sessao = sessao;
            _veiculoRepositorio = veiculoRepositorio;
            _bancoContext = context;
            _usuarioRepositorio = usuario;
            _caminhoimagem = sistema.WebRootPath;
            _manutencaoRepositorio = manutencaoRepositorio;
        }
     

        public IActionResult Index()
        {
            UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
            List<ManutencaoModel> manutencao = _manutencaoRepositorio.BuscarManutencao(usuarioLogado.Id); // buscando somente a corrida do usuario
                
            return View(manutencao);
        }


        public IActionResult CriarManutencao()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CriarManutencao(ManutencaoModel manutencaoModel, IFormFile imagem)
        {                   
            try
            {
                if (ModelState.IsValid) // validação dos campos 
                {
                    if (imagem != null && imagem.Length > 0)
                    {
                        string caminhoParaSalvarImagem = _caminhoimagem + "\\ImagensManutencoes\\";
                        string novoNomeParaImagem = Guid.NewGuid().ToString() + "_" + imagem.FileName;

                        if (!Directory.Exists(caminhoParaSalvarImagem))
                        {
                            Directory.CreateDirectory(caminhoParaSalvarImagem);
                        }

                        string caminhoCompleto = Path.Combine(caminhoParaSalvarImagem, novoNomeParaImagem);

                        using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                        {
                            imagem.CopyToAsync(stream);
                        }
                        string caminhoParaSalvarBD = caminhoCompleto;

                        UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                        _manutencaoRepositorio.AdicionarManutencao(manutencaoModel, usuarioLogado.Id, caminhoParaSalvarBD);
                    }
                  
                    TempData["MensagemSucesso"] = "Manutenção feita com sucesso!";
                    return RedirectToAction("Index", "Corrida");
                }
                return View(manutencaoModel);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao fazer a manutenção, tente novamente! detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }

        }
    }
}
