using System.ComponentModel.DataAnnotations;

namespace SistemaBoletimTransporteDigital.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Digite o seu Usuário")]
        [MaxLength(40)]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite a senha")]
        [MaxLength(20)]
        public string Senha { get; set; }

    }
}
