using SistemaBoletimTransporteDigital.Data;
using SistemaBoletimTransporteDigital.Models;

namespace SistemaBoletimTransporteDigital.Repositorio
{
    public class CorridaRepositorio : ICorridaRepositorio
    {
        private readonly BancoContext _bancoContext;

        public CorridaRepositorio(BancoContext bancoContext) // construtor
        {
            this._bancoContext = bancoContext;
        }
        public CorridaModel BuscarPorId(int id)
        {
            return _bancoContext.Corridas.First(x => x.Id == id);
        }
    }
}
