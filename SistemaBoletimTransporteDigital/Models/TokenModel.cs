using System.ComponentModel.DataAnnotations;

namespace SistemaBoletimTransporteDigital.Models
{
    public class TokenModel
    {
        

        [Required(ErrorMessage = "Digite o Token recebido")]
        [MaxLength(8)]
        public string Token { get; set; }
    }
}
