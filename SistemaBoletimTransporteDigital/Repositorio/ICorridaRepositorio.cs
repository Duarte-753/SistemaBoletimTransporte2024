using SistemaBoletimTransporteDigital.Models;

namespace SistemaBoletimTransporteDigital.Repositorio
{
    public interface ICorridaRepositorio
    {
        public List<CorridaModel> BuscarCorrida(int usuarioId);
    }
}
