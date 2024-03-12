using SistemaBoletimTransporteDigital.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaBoletimTransporteDigital.Models
{
    public class ManutencaoModel
    {
              
            public int Id { get; set; }

            public DateTime DataManutencao { get; set; } = DateTime.Now;
          
            [Required(ErrorMessage = "Descreva a manutenção.")] //Faz o Campo de baixo ser obrigatório   
            public string DescricaoManutencao { get; set; }

            public ManutencaoEnum TipoManutencao { get; set; }

            public int UsuarioID { get; set; }

            public virtual UsuarioModel? Usuario { get; set; }

            public int VeiculoID { get; set; }

            public virtual VeiculoModel? Veiculo { get; set; }

            [NotMapped]
            //[Required(ErrorMessage = "Selecione os Veículo")]
            public virtual ICollection<VeiculoModel>? VeiculosDisponiveis { get; set; }
        
    }
}
