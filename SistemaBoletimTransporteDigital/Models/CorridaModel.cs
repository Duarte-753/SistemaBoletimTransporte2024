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


        [Required(ErrorMessage = "Descreva qual vai ser o Serviço a executar.")] //Faz o Campo de baixo ser obrigatório   
        public string DescricaoCorrida { get; set; }

        [Required(ErrorMessage = "Descreva o Local de saída.")]
        public string LocalSaidaCorrida { get; set; } 
        
        public string? LocalChegadaCorrida { get; set; }

        [Required(ErrorMessage = "Qual a Km do Veículo do momento.")]
        public int KmInicial { get; set; }
       
        public int? KmFinal { get; set; }


        public int? KmPercorrido { get; set; }


        public StatusCorridaEnum? StatusDaCorrida { get; set; }

        public int UsuarioID { get; set; }

        public virtual UsuarioModel? Usuario { get; set; }

        //[Required(ErrorMessage = "Por favor, selecione um veículo.")]
        public int VeiculoID { get; set; }

        public virtual VeiculoModel? Veiculo { get; set; }

        //[NotMapped]
        //public virtual ICollection<ManutencaoModel>? Manutencoes { get; set; }

        [NotMapped]
        //[Required(ErrorMessage = "Selecione os Veículo")]
        public virtual ICollection<VeiculoModel>? VeiculosDisponiveis { get; set; }

    }
}