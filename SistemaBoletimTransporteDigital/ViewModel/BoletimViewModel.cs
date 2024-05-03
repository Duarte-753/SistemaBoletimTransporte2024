using SistemaBoletimTransporteDigital.Models;
using System.ComponentModel.DataAnnotations;

namespace SistemaBoletimTransporteDigital.ViewModels
{
    public class BoletimViewModel
    {
        public BoletimViewModel()
        {
            Filtros = new Filtro();
            DadosCorrida = new List<CorridaModel>();
            DadosManutencao = new List<ManutencaoModel>();
            DadosUsuario = new List<UsuarioModel>();
        }
        public Filtro Filtros { get; set; }

        public List<CorridaModel> DadosCorrida { get; set; }

        public List<ManutencaoModel> DadosManutencao { get; set; }

        public List<UsuarioModel> DadosUsuario { get; set; }

        public List<VeiculoModel> DadosVeiculos { get; set; }

        public string VeiculoNome { get; set; }
        public string Placa { get; set; }

        public int Prefixo { get; set; }

    }

    public class Filtro
    {
        [DataType(DataType.Date)]
        public DateTime? DataInicial { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataFinal { get; set; }
    }
  
}
