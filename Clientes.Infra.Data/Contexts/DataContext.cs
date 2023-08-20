using Clientes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Clientes.Infra.Data.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Detalhes> Detalhes { get; set; }
    }
}
