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

        public void AdicionarManutencao(ManutencaoModel manutencaoModel, int id, string caminhoParaSalvarBD, int idcorrida)
        {
            CorridaModel veiculoDB = ListarPorId(idcorrida);
            // gravar no banco de dados
            manutencaoModel.CaminhoDaImagem = caminhoParaSalvarBD;          
            manutencaoModel.UsuarioID = id;
            manutencaoModel.VeiculoID = veiculoDB.VeiculoID;



            _bancoContext.Manutencoes.Add(manutencaoModel);
            _bancoContext.SaveChanges();


            return;
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
