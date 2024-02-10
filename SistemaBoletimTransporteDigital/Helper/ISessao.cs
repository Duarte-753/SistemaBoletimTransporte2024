using SistemaBoletimTransporteDigital.Models;

namespace SistemaBoletimTransporteDigital.Helper
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario (UsuarioModel usuario);
        void RemoverSessaoDoUsuario();
        UsuarioModel BuscarSessaoDoUsuario();

    }
}
