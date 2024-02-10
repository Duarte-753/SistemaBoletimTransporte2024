using SistemaBoletimTransporteDigital.Models;
using Newtonsoft.Json; // Instalar pacote Json

namespace SistemaBoletimTransporteDigital.Helper
{
    public class Sessao : ISessao // Ijetamos o ISessao a clase Sessao 
    {
        private readonly IHttpContextAccessor _httpContex;

        public Sessao(IHttpContextAccessor httpContex)
        {
            _httpContex = httpContex;
        }

        public UsuarioModel BuscarSessaoDoUsuario()
        {
            string sessaoUsuario = _httpContex.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario)) return null;
            return JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
        }

        public void CriarSessaoDoUsuario(UsuarioModel usuario)
        {
            string valor = JsonConvert.SerializeObject(usuario);

            _httpContex.HttpContext.Session.SetString("sessaoUsuarioLogado",valor);
        }

        public void RemoverSessaoDoUsuario()
        {
            _httpContex.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}
