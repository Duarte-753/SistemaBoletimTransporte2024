using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaBoletimTransporteDigital.Models;

namespace SistemaBoletimTransporteDigital.Data.Map
{
    public class VeiculoDisponivelMap : IEntityTypeConfiguration<VeiculoModel>
    {
        public void Configure(EntityTypeBuilder<VeiculoModel> builder)
        {
            builder.HasKey(x => x.Id); // chave primaria da Corrida

            // Definindo relação com Usuario como chave estrangeira
           // builder.HasOne<CorridaModel>(c => c.CorridaT);
                         
        }
    }
}
