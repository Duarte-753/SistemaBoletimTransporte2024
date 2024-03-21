using SistemaBoletimTransporteDigital.Models;

namespace SistemaBoletimTransporteDigital.Repositorio
{
    public interface IManutencaoRepositorio
    {
        void AdicionarManutencao(ManutencaoModel manutencaoModel, int id, string caminhoParaSalvarBD, int idCorrida);
        List<ManutencaoModel> BuscarManutencao(int usuarioId);

        CorridaModel ListarPorId(int id);
    }
}
