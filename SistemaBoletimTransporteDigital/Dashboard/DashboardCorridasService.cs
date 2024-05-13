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

        public List<DashboardCadastros> GetCadastros()
        {
            var totalVeiculos = _bancoContext.Veiculos.Count();

            var totalMotoristas = _bancoContext.Usuario.Count(u => u.Perfil == Enums.PerfilEnum.motorista);

            // Inicializar lista para armazenar os dados dos veículos e motoristas
            var listaCadastro = new List<DashboardCadastros>();

            var dashboardCadastros = new DashboardCadastros
            {
                TotalVeiculos = totalVeiculos,
                TotalMotorista = totalMotoristas
            };

            listaCadastro.Add(dashboardCadastros);

            return listaCadastro;
        }

        public List<DashboardCarrosEmUso> GetCarrosEmUso()
        {       
            // Contar o total de veículos em uso
            var totalVeiculosEmUso = _bancoContext.Veiculos.Count(t => t.CarroEmUso == Enums.CarroEmUsoEnum.EmUso);

            // Contar o total de veículos disponíveis
            var totalVeiculosDisponivel = _bancoContext.Veiculos.Count(t => t.CarroEmUso == Enums.CarroEmUsoEnum.Disponivel);

            // Inicializar lista para armazenar os dados dos veículos e motoristas
            var listaCarros = new List<DashboardCarrosEmUso>();

            var dashboardVeiculos = new DashboardCarrosEmUso
            {
                VeiculoEmUso = totalVeiculosEmUso,
                VeiculoLivre = totalVeiculosDisponivel
            };

            listaCarros.Add(dashboardVeiculos);

            return listaCarros;
        }

        public List<DashboardMotoristaEmCorrida> GetMotoristaEmCorridas()
        {
            var totalUsuariosEmCorrida = _bancoContext.Usuario.Count(u => u.CorridaStatus == Enums.PerfilEnum.Iniciada && u.Perfil == Enums.PerfilEnum.motorista);

            var totalUsuariosDisponivel = _bancoContext.Usuario.Count(u => u.CorridaStatus == Enums.PerfilEnum.Finalizada && u.Perfil == Enums.PerfilEnum.motorista);

            // Inicializar lista para armazenar os dados dos veículos e motoristas
            var listaMotorista = new List<DashboardMotoristaEmCorrida>();

            var dashboardMotorista = new DashboardMotoristaEmCorrida
            {
                EmCorrida= totalUsuariosEmCorrida,
                Livre = totalUsuariosDisponivel
            };

            listaMotorista.Add(dashboardMotorista);

            return listaMotorista;
        }


    }
}
