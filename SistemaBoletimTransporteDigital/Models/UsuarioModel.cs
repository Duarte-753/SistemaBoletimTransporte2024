using SistemaBoletimTransporteDigital.Enums;
using SistemaBoletimTransporteDigital.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaBoletimTransporteDigital.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Digite o Código Funcional do funcionario")] //Faz o Campo de baixo ser obrigatório
        public int CodigoFuncional { get; set; }

        [Required(ErrorMessage = "Digite o Nome do funcionario")]
        [MaxLength(40)]
        public string Nome { get; set; }

        [Required(ErrorMessage ="Digite o nome de Usuário")]
        [MaxLength(20)]
        public string Usuario { get; set; }

        [Required(ErrorMessage ="Digite a senha desse Usuário")]
        [MaxLength(40)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Digite um email para recuperação de senha.")]
        [EmailAddress(ErrorMessage ="O e-mail informado não é valido!")]
        [MaxLength(40)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite o celular para contato.")]
        [Phone(ErrorMessage = "O celular informado não é valido.")]
        [MaxLength(20)]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Selecione o Perfil do Usuário.")]
        public PerfilEnum? Perfil { get; set; }

        public PerfilEnum? CorridaStatus { get; set; }

        public PerfilEnum? EstaVinculadoAumaCorrida { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now;

        public DateTime DataUltimaAtualizacao { get; set; } = DateTime.Now;



        public virtual List<CorridaModel>? Corridas { get; set; }

        public virtual List<ManutencaoModel>? Manutencoes { get; set; }


        public bool SenhaValida(string senha)
        {
            return Senha == senha.GerarHash();
        }

        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash();
        }

        public string GerarNovaSenha()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);
            Senha = novaSenha.GerarHash();
            return novaSenha;
        }

        [NotMapped]
        //[Required(ErrorMessage = "Selecione os Veículo")]
        public virtual ICollection<UsuarioModel>? UsuariosDisponiveis { get; set; }


    }
}
