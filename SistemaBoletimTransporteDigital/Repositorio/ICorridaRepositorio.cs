using SistemaBoletimTransporteDigital.Models;

namespace SistemaBoletimTransporteDigital.Repositorio
{
    public interface ICorridaRepositorio
    {
        public List<CorridaModel> BuscarCorrida(int usuarioId);

        public CorridaModel AdicionarCorrida(CorridaModel corrida, int id);
    }
}
