using Microsoft.EntityFrameworkCore;
using SistemaBoletimTransporteDigital.Data;
using SistemaBoletimTransporteDigital.Models;

namespace SistemaBoletimTransporteDigital.Repositorio
{
    public class VeiculoRepositorio : IVeiculoRepositorio
    {
        private readonly BancoContext _bancoContext;

        public VeiculoRepositorio(BancoContext bancoContext) // construtor
        {
            this._bancoContext = bancoContext;
        }

        public VeiculoModel AdicionarVeiculo(VeiculoModel veiculo)
        {
            // gravar no banco de dados          
            _bancoContext.Veiculos.Add(veiculo);
            _bancoContext.SaveChanges();

            return veiculo;
        }

        public bool ApagarVeiculo(int id)
        {
            VeiculoModel veiculoDB = ListarPorIdVeiculos(id);

            if (veiculoDB == null) throw new System.Exception("Houve um erro na exclusão do veículo!");

            _bancoContext.Veiculos.Remove(veiculoDB);
            _bancoContext.SaveChanges();

            return true;
        }

        public VeiculoModel AtualizarVeiculo(VeiculoModel veiculo)
        {
            VeiculoModel veiculoDB = ListarPorIdVeiculos(veiculo.Id);

            if (veiculoDB == null) throw new System.Exception("Houve um erro na atualização do veículo!");

            veiculoDB.Prefixo = veiculo.Prefixo;
            veiculoDB.Veiculo = veiculo.Veiculo;
            veiculoDB.Cor = veiculo.Cor;
            veiculoDB.Placa = veiculo.Placa;
            veiculoDB.Quilometragem = veiculo.Quilometragem;
            veiculoDB.Ano = veiculo.Ano;
            veiculoDB.Valor = veiculo.Valor;
            veiculoDB.DataUltimaAtualizacao = veiculo.DataUltimaAtualizacao;

            _bancoContext.Veiculos.Update(veiculoDB);
            _bancoContext.SaveChanges();

            return veiculoDB;
        }//opcional

        public object BuscarPorPlaca(string placa)
        {
            return _bancoContext.Veiculos.FirstOrDefault(v => v.Placa == placa);
        }

        public object BuscarPorPrefixo(int prefixo)
        {
            return _bancoContext.Veiculos.FirstOrDefault(v => v.Prefixo == prefixo);
        }

        public List<VeiculoModel> BuscarVeiculos()
        {
            return _bancoContext.Veiculos.ToList();
        }
   
        public VeiculoModel EditarVeiculo(VeiculoModel veiculo)
        {
            VeiculoModel veiculoDB = ListarPorIdVeiculos(veiculo.Id);

            if (veiculoDB == null) throw new System.Exception("Houve um erro na atualização do veículo!");

            veiculoDB.Prefixo = veiculo.Prefixo;
            veiculoDB.Veiculo = veiculo.Veiculo;
            veiculoDB.Cor = veiculo.Cor;
            veiculoDB.Placa = veiculo.Placa;
            veiculoDB.Quilometragem = veiculo.Quilometragem;
            veiculoDB.Ano = veiculo.Ano;
            veiculoDB.Valor = veiculo.Valor;
            veiculoDB.DataUltimaAtualizacao = veiculo.DataUltimaAtualizacao;

            _bancoContext.Veiculos.Update(veiculoDB);
            _bancoContext.SaveChanges();

            return veiculoDB;
        }

        public VeiculoModel KmVeiculo(VeiculoModel veiculo)
        {
            VeiculoModel veiculoDB = ListarPorIdVeiculos(veiculo.Id);

            if (veiculoDB == null) throw new System.Exception("Houve um erro na atualização do KM desse veículo!");

            
            veiculoDB.Quilometragem = veiculo.Quilometragem;
            

            _bancoContext.Veiculos.Update(veiculoDB);
            _bancoContext.SaveChanges();

            return veiculoDB;
        }

        

        public VeiculoModel ListarPorIdVeiculos(int id)
        {
            return _bancoContext.Veiculos.First(x => x.Id == id);
        }

        

        public void CorridaVinculadoCarroSim(CorridaModel buscaUsuario)
        {
            VeiculoModel veiculoDB = ListarPorIdVeiculos(buscaUsuario.VeiculoID);

            if (veiculoDB == null) throw new System.Exception("Houve um erro na atualização do Veiculo!");

            veiculoDB.VinculadoCarroAcorrida = Enums.CarroEmUsoEnum.VinculadoCarroAcorridaSim;


            _bancoContext.Veiculos.Update(veiculoDB);
            _bancoContext.SaveChanges();

            return;
        }

        public void CorridaVinculadoCarroNao(CorridaModel buscaUsuario)
        {
            VeiculoModel veiculoDB = ListarPorIdVeiculos(buscaUsuario.VeiculoID);

            if (veiculoDB == null) throw new System.Exception("Houve um erro na atualização do Veiculo!");

            veiculoDB.VinculadoCarroAcorrida = Enums.CarroEmUsoEnum.VinculadoCarroAcorridaNao;


            _bancoContext.Veiculos.Update(veiculoDB);
            _bancoContext.SaveChanges();

            return;
        }


        /*public VeiculoModel UsoVeiculo(VeiculoModel veiculo)
        {
            VeiculoModel veiculoDB = ListarPorIdVeiculos(veiculo.Id);

            if (veiculoDB == null) throw new System.Exception("Houve um erro na atualização carro em uso do veículo!");

            veiculoDB.CarroEmUso = Enums.CarroEmUsoEnum.EmUso;
            

            _bancoContext.Veiculos.Update(veiculoDB);
            _bancoContext.SaveChanges();

            return veiculoDB;
        }*/
    }
}
