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

        public CorridaModel FinalizarCorrida(CorridaModel corrida, int id)
        {

            CorridaModel corridaDB = ListarPorId(corrida.Id);

            if (corridaDB == null) throw new System.Exception("Houve um erro na atualização da corrida!");

            
            corridaDB.StatusDaCorrida = Enums.StatusCorridaEnum.Finalizada;
            corridaDB.KmFinal = corrida.KmFinal;
            corridaDB.DataFinalCorrida = corrida.DataFinalCorrida;

            


            _bancoContext.Corridas.Update(corridaDB);
            _bancoContext.SaveChanges();

            return corridaDB;

        }

        public CorridaModel ListarPorId(int id)
        {
            return _bancoContext.Corridas.First(x => x.Id == id);
        }

       //     //    //////////////////////////////////////////////////////////////////////////////////////////////////////


        //public VeiculoModel UsoVeiculo(VeiculoModel veiculo, int id)
        //{
        //    VeiculoModel veiculoDB = ListarPorIdVeiculos(veiculo.Id);

        //    if (veiculoDB == null) throw new System.Exception("Houve um erro na atualização carro em uso do veículo!");

        //    veiculoDB.CarroEmUso = Enums.CarroEmUsoEnum.EmUso;


        //    _bancoContext.Veiculos.Update(veiculoDB);
        //    _bancoContext.SaveChanges();

        //    return veiculoDB;
        //}

        public VeiculoModel ListarPorIdVeiculos(int id)
        {
            return _bancoContext.Veiculos.First(x => x.Id == id);
        }

        public void UsoVeiculo(CorridaModel corridaRepositorio)
        {
            
            VeiculoModel veiculoDB = ListarPorIdVeiculos(corridaRepositorio.VeiculoID);

            if (veiculoDB == null) throw new System.Exception("Houve um erro na atualização carro em uso do veículo!");

            veiculoDB.CarroEmUso = Enums.CarroEmUsoEnum.EmUso;


            _bancoContext.Veiculos.Update(veiculoDB);
            _bancoContext.SaveChanges();

            return;
        }

        public void NaoUsoVeiculo(CorridaModel corridaRepositorio)
        {
            

            VeiculoModel veiculoDB = ListarPorIdVeiculos(corridaRepositorio.VeiculoID);

            if (veiculoDB == null) throw new System.Exception("Houve um erro na atualização carro em uso do veículo!");

            veiculoDB.CarroEmUso = Enums.CarroEmUsoEnum.Disponivel;


            _bancoContext.Veiculos.Update(veiculoDB);
            _bancoContext.SaveChanges();

            return;
        }
    }
}
