
using SistemaBoletimTransporteDigital.Data;
using SistemaBoletimTransporteDigital.Models;

namespace SistemaBoletimTransporteDigital.Repositorio
{
    public class RelatorioUsuarioRepositorio : IRelatorioUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;

        public RelatorioUsuarioRepositorio(BancoContext bancoContext) // construtor
        {
            this._bancoContext = bancoContext;
        }

        public List<UsuarioModel> BuscarUsuario() // buscar os dados do banco da tabela Usuario
        {
            return _bancoContext.Usuario.ToList();
        }
    }
}
