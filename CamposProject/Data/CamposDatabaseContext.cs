using CamposProject.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CamposProject.Data
{
    public class CamposDatabaseContext : DbContext
    {
        public CamposDatabaseContext(DbContextOptions<CamposDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("Clientes");
            modelBuilder.Entity<Produto>().ToTable("Produtos");
            modelBuilder.Entity<Venda>().ToTable("Vendas");

        }


    }
}
