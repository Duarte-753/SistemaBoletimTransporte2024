using SistemaBoletimTransporteDigital.Models;

namespace SistemaBoletimTransporteDigital.Repositorio
{
    public interface IRelatorioUsuarioRepositorio
    {
        public List<UsuarioModel> BuscarUsuario();
    }
}
