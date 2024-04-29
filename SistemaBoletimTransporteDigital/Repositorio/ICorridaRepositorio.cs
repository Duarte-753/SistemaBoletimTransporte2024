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

        CorridaModel FinalizarCorrida(CorridaModel corrida, int id);

        //VeiculoModel UsoVeiculo(VeiculoModel veiculo, int id);

        VeiculoModel ListarPorIdVeiculos(int id);
     
        void UsoVeiculo(CorridaModel corridaRepositorio);

        void NaoUsoVeiculo(CorridaModel corridaRepositorio);

        void CalcKmPercorrido(CorridaModel corridaRepositorio);
     

    }
}
