using SistemaBoletimTransporteDigital.Models;

namespace SistemaBoletimTransporteDigital.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel BuscarPorLogin(string login);

        UsuarioModel BuscarPorEmailLogin(string email, string login);

        UsuarioModel ListarPorId(int id);

        UsuarioModel BuscarPorToken(string token);

        List<UsuarioModel> BuscarUsuario();

        UsuarioModel Adicionar(UsuarioModel usuario);

        UsuarioModel Atualizar(UsuarioModel usuario);

        UsuarioModel EditarUsuario(UsuarioModel usuario);

        public UsuarioModel EditarNovaSenha(UsuarioModel usuario);

        bool Apagar(int id);

          
        void CorridaStatusUserI(CorridaModel buscaUsuario);

        void CorridaStatusUserF(CorridaModel buscaUsuario);

        object BuscarPorCodigoFuncional(string codigoFuncional);

        public UsuarioModel BuscarPorNomeUsuario(string nomeUsuario);
        object BuscarPorEmail(string email);
    }
}
