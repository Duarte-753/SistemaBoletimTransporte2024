using SistemaBoletimTransporteDigital.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaBoletimTransporteDigital.Models
{
    public class CorridaModel
    {
        public int Id { get; set; }

        public DateTime DataInicioCorrida { get; set; } = DateTime.Now;

        public DateTime? DataFinalCorrida { get; set; } = DateTime.Now;


        [Required(ErrorMessage = "Descreva onde vai utilizar o Veículo escolhido.")] //Faz o Campo de baixo ser obrigatório   
        public string DescricaoCorrida { get; set; }

        public int? KmInicial { get; set; }

        public int? KmFinal { get; set; }


        public int? KmPercorrido { get; set; }


        public StatusCorridaEnum? StatusDaCorrida { get; set; }

        public int UsuarioID { get; set; }

        public virtual UsuarioModel? Usuario { get; set; }

        public int VeiculoID { get; set; }

        public virtual VeiculoModel? Veiculo { get; set; }


        [NotMapped]
        //[Required(ErrorMessage = "Selecione os Veículo")]
        public virtual ICollection<VeiculoModel>? VeiculosDisponiveis { get; set; }

    }
}