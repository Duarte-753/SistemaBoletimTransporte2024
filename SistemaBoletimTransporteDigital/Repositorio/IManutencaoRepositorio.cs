using SistemaBoletimTransporteDigital.Models;

namespace SistemaBoletimTransporteDigital.Repositorio
{
    public interface IManutencaoRepositorio
    {
        List<ManutencaoModel> BuscarManutencao(int usuarioId);
    }
}
