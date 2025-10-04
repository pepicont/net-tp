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
        public DbSet<Materia> Materia { get; set; }

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
                // Configuración de la foreign key y borrado en cascada
                entity.HasOne<Especialidad>()
                      .WithMany()
                      .HasForeignKey(p => p.Id_especialidad)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasData(
                    new Plan { Id = 1, Desc = "Plan 2025", Id_especialidad = 1 },
                    new Plan { Id = 2, Desc = "Plan 2026", Id_especialidad = 2 });
            });

            modelBuilder.Entity<Especialidad>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.Desc);
                entity.HasData(
                    new Especialidad { Id = 1, Desc = "Ingeniería" },
                    new Especialidad { Id = 2, Desc = "Medicina" }
                );
            });

            modelBuilder.Entity<Materia>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.Desc);
                entity.Property(e => e.Hs_semanales);
                entity.Property(e => e.Hs_totales);
                entity.Property(e => e.Id_plan);
                // Configuración de la foreign key y borrado en cascada
                entity.HasOne<Plan>()
                      .WithMany()
                      .HasForeignKey(p => p.Id_plan)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasData(
                    new Materia { Id = 1, Desc = "Matemática I", Hs_semanales = 4, Hs_totales = 64, Id_plan = 1 },
                    new Materia { Id = 2, Desc = "Programación I", Hs_semanales = 6, Hs_totales = 96, Id_plan = 1 }
                );
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
                // Datos iniciales para Persona
                entity.HasData(
                    new Persona
                    {
                        Id = 1,
                        Nombre = "Juan",
                        Apellido = "Pérez",
                        Direccion = "Calle Falsa 123",
                        Email = "juan@mail.com",
                        Telefono = "123456",
                        Fecha_nac = "1990-01-01",
                        Legajo = 1,
                        Tipo_persona = 1,
                        Id_plan = 1
                    },
                    new Persona
                    {
                        Id = 2,
                        Nombre = "Bruno",
                        Apellido = "Vitali",
                        Direccion = "Calle Falsa 123",
                        Email = "bruno@mail.com",
                        Telefono = "123456",
                        Fecha_nac = "1990-01-01",
                        Legajo = 2,
                        Tipo_persona = 1,
                        Id_plan = 2
                    }
                );
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
                entity.Property(e => e.Tipo);
                // Foreign key a Persona
                entity.HasOne<Persona>()
                      .WithMany()
                      .HasForeignKey(u => u.Id_persona)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasData(
                    new Usuario
                    {
                        Id = 1,
                        Nombre_usuario = "admin",
                        Clave = "$2a$12$oio9TEk650CiHoYazcMtQeBw5Ft6lrDvlGAEd3ktpUpRbTWRl9MLq", // Idealmente, hasheada
                        Habilitado = true,
                        Nombre = "Admin",
                        Apellido = "Principal",
                        Email = "admin@mail.com",
                        Cambia_clave = false,
                        Id_persona = 1,
                        Tipo = "Admin"
                    },
                    new Usuario
                    {
                        Id = 2,
                        Nombre_usuario = "bruno",
                        Clave = "$2a$12$oio9TEk650CiHoYazcMtQeBw5Ft6lrDvlGAEd3ktpUpRbTWRl9MLq", // Idealmente, hasheada
                        Habilitado = true,
                        Nombre = "Bruno",
                        Apellido = "Vitali",
                        Email = "bruno@mail.com",
                        Cambia_clave = false,
                        Id_persona = 2,
                        Tipo = "Usuario"
                    });
        });
        }
    }
}



