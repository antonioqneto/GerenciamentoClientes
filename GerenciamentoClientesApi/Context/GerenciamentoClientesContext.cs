using GerenciamentoClientesModel;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoClientesApi.Context
{
    public class GerenciamentoClientesContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public GerenciamentoClientesContext(DbContextOptions<GerenciamentoClientesContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            // modelBuilder.SetarConfigCliente();
            // public DbSet<Cliente> ConfigClientes { get; set; }

            modelBuilder.Seed();
        }

    }
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Cliente>().HasData(new Cliente[]
            {
                new Cliente(1, "Marcos", "Marcos@email.com", "1987654321"),
                new Cliente(2, "Joana", "Joana@email.com", "19912345678"),
                new Cliente(3, "Dexter", "Dexter@email.com", "19999999999"),
            });
        }
    }
}