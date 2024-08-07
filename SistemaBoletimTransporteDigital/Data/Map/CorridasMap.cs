﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaBoletimTransporteDigital.Models;

namespace SistemaBoletimTransporteDigital.Data.Map
{
    public class CorridasMap : IEntityTypeConfiguration<CorridaModel>
    {
        public void Configure(EntityTypeBuilder<CorridaModel> builder)
        {
            builder.HasKey(x => x.Id); // chave primaria da Corrida

            // Definindo relação com Usuario como chave estrangeira
            builder.HasOne<UsuarioModel>(c => c.Usuario);

            // Definindo relação com Veiculo como chave estrangeira
            builder.HasOne<VeiculoModel>(c => c.Veiculo);
                  
                   
        }
    }
}
