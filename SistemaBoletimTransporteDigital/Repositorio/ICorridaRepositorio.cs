using SistemaBoletimTransporteDigital.Models;
using Implementation = SistemaBoletimTransporteDigital.Repositorio.CorridaRepositorio;


namespace SistemaBoletimTransporteDigital.Repositorio
{
    public interface ICorridaRepositorio
    {
        public List<CorridaModel> BuscarCorrida(int usuarioId);

        [ImplementedMethod(nameof(Implementation.AdicionarCorrida))] // apenas um modo de fazer atalho para implementação

        public CorridaModel AdicionarCorrida(CorridaModel corrida, int id);

        CorridaModel ListarPorId(int id);

        CorridaModel FinalizarCorrida(CorridaModel corrida);
    }
}
