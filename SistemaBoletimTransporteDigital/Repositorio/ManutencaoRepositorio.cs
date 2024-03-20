using SistemaBoletimTransporteDigital.Data;
using SistemaBoletimTransporteDigital.Models;

namespace SistemaBoletimTransporteDigital.Repositorio
{
    public class ManutencaoRepositorio : IManutencaoRepositorio
    {
        private readonly BancoContext _bancoContext;


        public ManutencaoRepositorio(BancoContext bancoContext) // construtor
        {
            this._bancoContext = bancoContext;

        }

        public List<ManutencaoModel> BuscarManutencao(int usuarioId)
        {
            return _bancoContext.Manutencoes.Where(x => x.UsuarioID == usuarioId ).ToList();
        }
    }
}
