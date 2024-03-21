using SistemaBoletimTransporteDigital.Models;

namespace SistemaBoletimTransporteDigital.Repositorio
{
    public interface IManutencaoRepositorio
    {
        void AdicionarManutencao(ManutencaoModel manutencaoModel, int id, string caminhoParaSalvarBD);
        List<ManutencaoModel> BuscarManutencao(int usuarioId);
    }
}
