using SistemaBoletimTransporteDigital.Data;
using SistemaBoletimTransporteDigital.Migrations;
using SistemaBoletimTransporteDigital.Models;

namespace SistemaBoletimTransporteDigital.Repositorio
{
    public class ManutencaoRepositorio : IManutencaoRepositorio
    {
        private readonly BancoContext _bancoContext;


        public ManutencaoRepositorio(BancoContext bancoContext) // construtor
        {
            this._bancoContext = bancoContext;

        }

        public ManutencaoModel AdicionarManutencao(ManutencaoModel manutencaoModel,int id, string caminhoParaSalvarBD, int idcorrida)
        {
            try
            {
                CorridaModel corridaDB = ListarPorId(idcorrida);

                // Gravar no banco de dados
                manutencaoModel.CaminhoDaImagem = caminhoParaSalvarBD;
                manutencaoModel.VeiculoID = corridaDB.VeiculoID;
                manutencaoModel.UsuarioID = id;
                manutencaoModel.DataManutencao = DateTime.Now;
                manutencaoModel.CorridaID = idcorrida;

                _bancoContext.Manutencoes.Add(manutencaoModel);
                _bancoContext.SaveChanges();

                return manutencaoModel;
            }
            catch (Exception ex)
            {
                // Exibir informações detalhadas sobre a exceção
                Console.WriteLine($"Erro ao fazer a manutenção: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Detalhe do erro interno: {ex.InnerException.Message}");
                }
                throw; // Re-lança a exceção para que seja tratada em um nível superior
            }
        }

        public List<ManutencaoModel> BuscarManutencao(int usuarioId)
        {
            return _bancoContext.Manutencoes.Where(x => x.UsuarioID == usuarioId ).ToList();
        }
        public CorridaModel ListarPorId(int id)
        {
            return _bancoContext.Corridas.First(x => x.Id == id);
        }
    }
}
