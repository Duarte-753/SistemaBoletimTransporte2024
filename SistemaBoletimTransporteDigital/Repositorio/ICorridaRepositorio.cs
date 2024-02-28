using SistemaBoletimTransporteDigital.Models;

namespace SistemaBoletimTransporteDigital.Repositorio
{
    public interface ICorridaRepositorio
    {
        CorridaModel BuscarPorId(int id);
    }
}
