using Microsoft.AspNetCore.Hosting;
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
            List<ManutencaoModel> manutencao = _manutencaoRepositorio.BuscarManutencao(usuarioLogado.Id); // buscando somente a manutenção do usuario

            var manutencaoModel = new ManutencaoModel();
            manutencaoModel.VeiculosDisponiveis = _veiculoRepositorio.BuscarVeiculos();


            return View(manutencao);
        }

        public IActionResult DetalhesDaManutencao(int id)
        {
            ManutencaoModel manutencaoModel = _manutencaoRepositorio.ListarPorIdManutencao(id);

            var manutencaoModeldetalhes = new ManutencaoModel();
            manutencaoModeldetalhes.VeiculosDisponiveis = _veiculoRepositorio.BuscarVeiculos();

            return View(manutencaoModel);
        }


        public IActionResult CriarManutencao()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CriarManutencao(ManutencaoModel manutencaoModel, IFormFile imagem, int id)
        {                   
            try
            {
                if (ModelState.IsValid) // validação dos campos 
                { 
                    
                    if (imagem != null && imagem.Length > 0) 
                    {
                       
                        string caminhoParaSalvarImagem = _caminhoimagem + "\\ImagensManutencoes\\";
                        string novoNomeParaImagem = Guid.NewGuid().ToString() + "_" + imagem.FileName ;

                        if (!Directory.Exists(caminhoParaSalvarImagem))
                        {
                            Directory.CreateDirectory(caminhoParaSalvarImagem);
                        }

                        string caminhoCompleto = Path.Combine(caminhoParaSalvarImagem, novoNomeParaImagem);                      

                        using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                        {
                            await imagem.CopyToAsync(stream);
                        }

                        string caminhoParaSalvarBD = novoNomeParaImagem;
                        int IdCorrida = id;
                        manutencaoModel.Id = 0;
                        

                        UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                        _manutencaoRepositorio.AdicionarManutencao(manutencaoModel, usuarioLogado.Id, caminhoParaSalvarBD, IdCorrida);

                        TempData["MensagemSucesso"] = "Manutenção feita com sucesso!";
                        return RedirectToAction("Index", "Corrida");
                    }                 
                                  
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
