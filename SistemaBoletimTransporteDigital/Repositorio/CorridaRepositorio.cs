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

        public List<CorridaModel> BuscarCorrida(int usuarioId) //estou passando o usuario por que somente ira aparecer as corridas do usuario refrente a ele no seu login sem acesso a corrida dos outros motorista
        {
            return _bancoContext.Corridas.Where(x => x.UsuarioID == usuarioId).ToList();
        }

        public CorridaModel AdicionarCorrida(CorridaModel corrida, int id)
        {
            // gravar no banco de dados
            corrida.DataFinalCorrida = null;
            corrida.StatusDaCorrida = Enums.StatusCorridaEnum.Iniciada;
            corrida.UsuarioID = id;
            _bancoContext.Corridas.Add(corrida);       
            _bancoContext.SaveChanges();

            return corrida;

        }

        
    }
}
