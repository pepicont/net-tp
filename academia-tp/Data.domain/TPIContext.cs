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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Plan>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.Desc);
                entity.Property(e => e.Id_especialidad);
            });
            modelBuilder.Entity<Especialidad>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.Desc);
            });
            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre);
                entity.Property(e => e.Apellido);
                entity.Property(e => e.Direccion);
                entity.Property(e => e.Email);
                entity.Property(a => a.Legajo);
                entity.Property(e => e.Telefono);
                entity.Property(e => e.Fecha_nac);
                entity.Property(e => e.Tipo_persona);
                entity.Property(e => e.Id_plan);
            });
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.Nombre_usuario);
                entity.Property(e => e.Clave);
                entity.Property(e => e.Habilitado);
                entity.Property(e => e.Nombre);
                entity.Property(e => e.Apellido);
                entity.Property(e => e.Email);
                entity.Property(e => e.Cambia_clave);
                entity.Property(e => e.Id_persona);
            });
        }
    };
}
