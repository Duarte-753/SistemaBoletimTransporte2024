using Microsoft.EntityFrameworkCore;
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
        
    }
}
