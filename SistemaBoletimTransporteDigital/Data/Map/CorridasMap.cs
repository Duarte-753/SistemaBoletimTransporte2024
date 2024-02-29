using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaBoletimTransporteDigital.Models;

namespace SistemaBoletimTransporteDigital.Data.Map
{
    public class CorridasMap : IEntityTypeConfiguration<CorridaModel>
    {
        public void Configure(EntityTypeBuilder<CorridaModel> builder)
        {
            builder.HasKey(x => x.Id); // chave primaria da Corrida
            builder.HasOne(x => x.Usuario);// Chave Secundária
            builder.HasOne(x => x.Veiculo);// Chave secundaria
        }
    }
}
