using SistemaBoletimTransporteDigital.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaBoletimTransporteDigital.Models
{
    public class CorridaModel 
    {
        public int Id { get; set; }

        public DateTime DataInicioCorrida { get; set; } = DateTime.Now;

        public DateTime? DataFinalCorrida { get; set; } = DateTime.Now;

        public string? DescricaoCorrida { get; set; }

        public StatusCorridaEnum? StatusDaCorrida { get; set; }




        public int UsuarioID { get; set; }
      
        public UsuarioModel? Usuario { get; set; }

        public int VeiculoID { get; set; }
        //public string NomeUsuarioMotorista { get; set; }

        // public string NomeVeiculo { get; set; }

        //  public string CorVeiculo { get; set; }

        // public string PlacaVeiculo { get; set; }

        // public string KmVeiculo { get; set; }

        public VeiculoModel? Veiculo { get; set; }

        [NotMapped]
        public virtual List<VeiculoModel> VeiculosDisponiveis { get; set; }
    }
}
