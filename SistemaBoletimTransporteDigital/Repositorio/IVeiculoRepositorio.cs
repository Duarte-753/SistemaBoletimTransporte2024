using SistemaBoletimTransporteDigital.Models;

namespace SistemaBoletimTransporteDigital.Repositorio
{
    public interface IVeiculoRepositorio
    {
            
        VeiculoModel ListarPorIdVeiculos(int id);

        List<VeiculoModel> BuscarVeiculos();

        VeiculoModel AdicionarVeiculo(VeiculoModel veiculo);

        VeiculoModel AtualizarVeiculo(VeiculoModel veiculo);

        VeiculoModel EditarVeiculo(VeiculoModel veiculo);

        bool ApagarVeiculo(int id);
    }
}
