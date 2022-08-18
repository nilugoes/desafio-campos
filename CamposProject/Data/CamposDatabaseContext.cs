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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("Clientes");
         
        }
    }
}
