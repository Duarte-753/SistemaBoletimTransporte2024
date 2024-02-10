using System.ComponentModel.DataAnnotations;

namespace SistemaBoletimTransporteDigital.Models
{
    public class RedefinirSenhaModel
    {

        [Required(ErrorMessage = "Digite o seu Usuário")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite o e-mail")]
        public string Email { get; set; }

    }
}
