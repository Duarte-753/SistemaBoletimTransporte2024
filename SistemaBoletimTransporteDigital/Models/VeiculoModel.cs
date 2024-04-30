using SistemaBoletimTransporteDigital.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaBoletimTransporteDigital.Models
{
    public class VeiculoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o Prefixo do Veículo")]
        public int Prefixo { get; set; }

        [Required(ErrorMessage = "Digite o nome do Veículo")]
        public string Veiculo { get; set; }

        [Required(ErrorMessage = "Digite a cor do Veículo")]
        public string Cor { get; set; }

        [Required(ErrorMessage = "Digite a placa do Veículo")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "Digite a quilometragem em que Veículo está no momento")]
        public int Quilometragem { get; set; }

        [Required(ErrorMessage = "Digite o Ano do Veículo")]
        public int Ano { get; set; }

        [Required(ErrorMessage = "Digite o valor do Veículo")]
        public int Valor { get; set; }

        public DateTime CadastroSistema { get; set; } = DateTime.Now;

        public DateTime DataUltimaAtualizacao { get; set; } = DateTime.Now;

        public CarroEmUsoEnum? CarroEmUso { get; set; } = CarroEmUsoEnum.Disponivel;

        public CarroEmUsoEnum? VinculadoCarroAcorrida { get; set; }

        public virtual ICollection<CorridaModel>? Corridas { get; set; }

        public virtual ICollection<ManutencaoModel>? Manutencoes { get; set; }


    }
}
