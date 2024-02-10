using System.ComponentModel.DataAnnotations;

namespace SistemaBoletimTransporteDigital.Models
{
    public class TokenModel
    {
        

        [Required(ErrorMessage = "Digite o Token recebido")]
        public string Token { get; set; }
    }
}
