using Microsoft.EntityFrameworkCore;
using TesteDesenvolvedor.Domain;

namespace TesteDesenvolvedor.Repository.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Parada> Paradas { get; set; }
        public DbSet<Linha> Linhas { get; set; }
        public DbSet<PosicaoVeiculo> PosicaoVeiculos { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<PosicaoVeiculo>(builder => {
                builder.HasNoKey();
                builder.ToTable("PosicaoVeiculos");
            });
        }

    }
}
