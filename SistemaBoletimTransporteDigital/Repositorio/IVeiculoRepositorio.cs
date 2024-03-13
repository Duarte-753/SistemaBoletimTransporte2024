﻿using SistemaBoletimTransporteDigital.Models;
using Implementation = SistemaBoletimTransporteDigital.Repositorio.VeiculoRepositorio;


namespace SistemaBoletimTransporteDigital.Repositorio
{
    public interface IVeiculoRepositorio
    {
            
        VeiculoModel ListarPorIdVeiculos(int id);

        [ImplementedMethod(nameof(Implementation.BuscarVeiculos))] // apenas um modo de fazer atalho para implementação

        List<VeiculoModel> BuscarVeiculos();

        VeiculoModel AdicionarVeiculo(VeiculoModel veiculo);

        VeiculoModel AtualizarVeiculo(VeiculoModel veiculo);

        VeiculoModel EditarVeiculo(VeiculoModel veiculo);

        VeiculoModel KmVeiculo(VeiculoModel veiculo);

        bool ApagarVeiculo(int id);
    }
}
