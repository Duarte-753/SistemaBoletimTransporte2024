using SistemaBoletimTransporteDigital.Data;
using SistemaBoletimTransporteDigital.Models;

namespace SistemaBoletimTransporteDigital.Dashboard
{
    public class DashboardCorridasService
    {
        private readonly BancoContext _bancoContext;
        public DashboardCorridasService(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<DashboardGrafico> GetCorridasFeitas(int dias = 360)
        {
            var data = DateTime.Now.AddDays(-dias);

            // Buscar todos os veículos no contexto do banco de dados
            var veiculos = _bancoContext.Veiculos.ToList();

            // Inicializar lista para armazenar os dados dos veículos
            var lista = new List<DashboardGrafico>();

            // Para cada veículo, buscar as corridas e manutenções e calcular os totais
            foreach (var veiculo in veiculos)
            {
                // Buscar corridas para o veículo
                var corridas = _bancoContext.Corridas
                    .Where(c => c.VeiculoID == veiculo.Id && c.DataFinalCorrida >= data)
                    .Count();

                // Buscar manutenções para o veículo
                var manutencoes = _bancoContext.Manutencoes
                    .Where(m => m.VeiculoID == veiculo.Id && m.DataManutencao >= data)
                    .Count();

                // Criar objeto DashboardGrafico para o veículo e adicionar à lista
                lista.Add(new DashboardGrafico
                {
                    VeiculoNome ="Prefixo: "+veiculo.Prefixo+ " | " + veiculo.Veiculo.ToString() + " |"+" Placa: " +veiculo.Placa +" ",
                    TotalCorridas = corridas,
                    TotalManutencao = manutencoes
                });
            }

            return lista;
        }

    }
}
