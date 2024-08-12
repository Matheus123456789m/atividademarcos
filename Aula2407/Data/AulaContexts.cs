using Aula2407.Models;
using Microsoft.EntityFrameworkCore;

namespace Aula2407.Data
{
    public class AulaContexts : DbContext
    {
        public AulaContexts(DbContextOptions<AulaContexts> options) : base(options)
        {
        }
        public DbSet<Aula2407.Models.Cliente> Clientes { get; set; } = default!;
        public DbSet<Aula2407.Models.Produto> Produtos { get; set; } = default!;

       

        //public DbSet<Cliente> Cliente { get; set;}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Cliente>().ToTable("Cliente");
        //}
    }

}
