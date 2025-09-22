using Domain.model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DataDomain
{
    public class TPIContext : DbContext
    {
        public DbSet<Plan> Plan { get; set; }
        public DbSet<Especialidad> Especialidad { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Persona> Persona { get; set; }

        public TPIContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=TPI;Integrated Security=true;TrustServerCertificate=True")
                .LogTo(Console.WriteLine, LogLevel.Information);
        }

    }
}
