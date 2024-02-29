using Microsoft.EntityFrameworkCore;
using SistemaBoletimTransporteDigital.Data.Map;
using SistemaBoletimTransporteDigital.Models;

namespace SistemaBoletimTransporteDigital.Data
{
    public class BancoContext : DbContext
    {

        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }
        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<VeiculoModel> Veiculos { get; set; }

        public DbSet<CorridaModel> Corridas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CorridasMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
