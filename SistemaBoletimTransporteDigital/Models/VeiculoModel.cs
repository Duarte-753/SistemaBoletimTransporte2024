using System.ComponentModel.DataAnnotations;

namespace SistemaBoletimTransporteDigital.Models
{
    public class VeiculoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o Prefixo do Veículo")]
        public string Prefixo { get; set; }

        [Required(ErrorMessage = "Digite o nome do Veículo")]
        public string Veiculo { get; set; }

        [Required(ErrorMessage = "Digite a cor do Veículo")]
        public string Cor { get; set; }

        [Required(ErrorMessage = "Digite a placa do Veículo")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "Digite a quilometragem em que Veículo está no momento")]
        public string Quilometragem { get; set; }

        [Required(ErrorMessage = "Digite o Ano do Veículo")]
        public string Ano { get; set; }

        [Required(ErrorMessage = "Digite o valor do Veículo")]
        public string Valor { get; set; }

        public DateTime CadastroSistema { get; set; } = DateTime.Now;

        public DateTime DataUltimaAtualizacao { get; set; } = DateTime.Now;

    }
}
