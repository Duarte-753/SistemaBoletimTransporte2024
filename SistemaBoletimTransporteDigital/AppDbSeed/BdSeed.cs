using Microsoft.EntityFrameworkCore;
using SistemaBoletimTransporteDigital.Models;

namespace SistemaBoletimTransporteDigital.AppDbSeed
{
    public static class BdSeed
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            SeedUsuarios(modelBuilder);
            SeedVeiculos(modelBuilder);           
        }

        private static void SeedUsuarios(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioModel>().HasData(
                new UsuarioModel
                {
                    Id = 1,
                    CodigoFuncional = 1234,
                    Nome = "admin",
                    Usuario = "ADMIN",
                    Senha = "d033e22ae348aeb5660fc2140aec35850c4da997",
                    Email = "julioduartebatista753@gmail.com",
                    Celular = "11912345678",
                    Perfil = Enums.PerfilEnum.Admin,
                    CorridaStatus = Enums.PerfilEnum.Finalizada,
                    EstaVinculadoAumaCorrida = Enums.PerfilEnum.VinculadoAcorridaNao,
                    DataCriacao = DateTime.Now,
                    DataUltimaAtualizacao = DateTime.Now,
                    // Outras propriedades
                }
            );
            //modelBuilder.Entity<UsuarioModel>().HasData(
            //    new UsuarioModel
            //    {
            //        Id = 2,
            //        CodigoFuncional = 567,
            //        Nome = "motorista",
            //        Usuario = "MOTORISTA",
            //        Senha = "a61e38f3910fba1d8e1fb97f4b3561df07ab0d81",
            //        Email = "julioduartebatista753@gmail.com",
            //        Celular = "11912345678",
            //        Perfil = Enums.PerfilEnum.motorista,
            //        CorridaStatus = Enums.PerfilEnum.Finalizada,
            //        EstaVinculadoAumaCorrida = Enums.PerfilEnum.VinculadoAcorridaNao,
            //        DataCriacao = DateTime.Now,
            //        DataUltimaAtualizacao = DateTime.Now,
            //        // Outras propriedades
            //    }
            //);
           // modelBuilder.Entity<UsuarioModel>().HasData(
           //    new UsuarioModel
           //    {
           //        Id = 3,
           //        CodigoFuncional = 9876,
           //        Nome = "motorista2",
           //        Usuario = "MOTORISTA2",
           //        Senha = "b739522c59a564437fc8c6ad639176f704766596",
           //        Email = "julioduartebatista753@gmail.com",
           //        Celular = "11912345678",
           //        Perfil = Enums.PerfilEnum.motorista,
           //        CorridaStatus = Enums.PerfilEnum.Finalizada,
           //        EstaVinculadoAumaCorrida = Enums.PerfilEnum.VinculadoAcorridaNao,
           //        DataCriacao = DateTime.Now,
           //        DataUltimaAtualizacao = DateTime.Now,
           //        // Outras propriedades
           //    }
           //);
            // Adicione mais usuários conforme necessário
        }

        private static void SeedVeiculos(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VeiculoModel>().HasData(
                new VeiculoModel
                {
                    Id = 1,
                    Prefixo = 12345,
                    Veiculo = "GOLF GTI",
                    Cor = "BRANCO",
                    Placa = "FWF1232",
                    Quilometragem = 12600,
                    Ano = 2014,
                    Valor = 259875,
                    CadastroSistema = DateTime.Now,
                    DataUltimaAtualizacao = DateTime.Now,
                    CarroEmUso = Enums.CarroEmUsoEnum.Disponivel,
                    // Popule outras propriedades
                }
            );

            modelBuilder.Entity<VeiculoModel>().HasData(
               new VeiculoModel
               {
                   Id = 2,
                   Prefixo = 678910,
                   Veiculo = "FIAT UNO SPORT",
                   Cor = "PRETO",
                   Placa = "ASD2Y45",
                   Quilometragem = 450067,
                   Ano = 2016,
                   Valor = 15000,
                   CadastroSistema = DateTime.Now,
                   DataUltimaAtualizacao = DateTime.Now,
                   CarroEmUso = Enums.CarroEmUsoEnum.Disponivel,
                   // Popule outras propriedades
               }
           );

            // modelBuilder.Entity<VeiculoModel>().HasData(
            //    new VeiculoModel
            //    {
            //        Id = 3,
            //        Prefixo = 121235,
            //        Veiculo = "Palio Weekend",
            //        Cor = "Azul",
            //        Placa = "JHF-7653",
            //        Quilometragem = 100,
            //        Ano = 2024,
            //        Valor = 45000,
            //        CadastroSistema = DateTime.Now,
            //        DataUltimaAtualizacao = DateTime.Now,
            //        CarroEmUso = Enums.CarroEmUsoEnum.Disponivel,
            //        // Popule outras propriedades
            //    }
            //);
            // Adicione mais veículos conforme necessário
        }
        
    }
}
