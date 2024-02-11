using System.ComponentModel.DataAnnotations;

namespace SistemaBoletimTransporteDigital.Models
{
    public class RedefinirSenhaModel
    {

        [Required(ErrorMessage = "Digite o seu Usuário")]
        [MaxLength(40)]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite o e-mail")]
        [MaxLength(40)]
        public string Email { get; set; }

    }
}
