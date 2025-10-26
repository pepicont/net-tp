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
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Inscripcion> Inscripcion { get; set; }
        public DbSet<Docente> Docente { get; set; }

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
               
                entity.HasOne<Especialidad>()
                      .WithMany()
                      .HasForeignKey(p => p.Id_especialidad)
                      .OnDelete(DeleteBehavior.Restrict);
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

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.Id_materia);
                entity.Property(e => e.Anio_calendario);
                entity.Property(e => e.Cupo);
                entity.Property(e => e.Nombre);

                entity.HasOne<Materia>()
                      .WithMany()
                      .HasForeignKey(c => c.Id_materia)
                      .OnDelete(DeleteBehavior.Cascade);


                entity.HasData(
                    new Curso { Id = 1, Id_materia = 1, Anio_calendario = 2025, Cupo = 30, Nombre = "A" },
                    new Curso { Id = 2, Id_materia = 1, Anio_calendario = 2025, Cupo = 25, Nombre = "B" },
                    new Curso { Id = 3, Id_materia = 1, Anio_calendario = 2025, Cupo = 27, Nombre = "C" },
                    new Curso { Id = 4, Id_materia = 1, Anio_calendario = 2025, Cupo = 35, Nombre = "D" },
                    new Curso { Id = 5, Id_materia = 2, Anio_calendario = 2025, Cupo = 15, Nombre = "E" }
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
                    },
                    new Persona
                    {
                        Id = 3,
                        Nombre = "Ana",
                        Apellido = "García",
                        Direccion = "Av. Siempreviva 742",
                        Email = "ana@mail.com",
                        Telefono = "654321",
                        Fecha_nac = "1992-03-15",
                        Legajo = 3,
                        Tipo_persona = 1,
                        Id_plan = 1
                    },
new Persona
{
    Id = 4,
    Nombre = "Luis",
    Apellido = "Martínez",
    Direccion = "Calle Luna 45",
    Email = "luis@mail.com",
    Telefono = "789456",
    Fecha_nac = "1991-07-22",
    Legajo = 4,
    Tipo_persona = 1,
    Id_plan = 1
},
new Persona
{
    Id = 5,
    Nombre = "Sofía",
    Apellido = "Fernández",
    Direccion = "Calle Sol 99",
    Email = "sofia@mail.com",
    Telefono = "321654",
    Fecha_nac = "1993-11-30",
    Legajo = 5,
    Tipo_persona = 1,
    Id_plan = 1
},
new Persona
{
    Id = 6,
    Nombre = "Carlos",
    Apellido = "Ramírez",
    Direccion = "Av. Libertad 100",
    Email = "carlos@mail.com",
    Telefono = "987654",
    Fecha_nac = "1990-05-10",
    Legajo = 6,
    Tipo_persona = 1,
    Id_plan = 1
},
new Persona
{
    Id = 7,
    Nombre = "Lucía",
    Apellido = "Torres",
    Direccion = "Calle Norte 12",
    Email = "lucia@mail.com",
    Telefono = "456789",
    Fecha_nac = "1994-08-18",
    Legajo = 7,
    Tipo_persona = 1,
    Id_plan = 1
},
new Persona
{
    Id = 8,
    Nombre = "Miguel",
    Apellido = "Sánchez",
    Direccion = "Calle Sur 34",
    Email = "miguel@mail.com",
    Telefono = "147258",
    Fecha_nac = "1992-12-05",
    Legajo = 8,
    Tipo_persona = 1,
    Id_plan = 1
},
new Persona
{
    Id = 9,
    Nombre = "Valeria",
    Apellido = "López",
    Direccion = "Av. Central 56",
    Email = "valeria@mail.com",
    Telefono = "258369",
    Fecha_nac = "1995-02-14",
    Legajo = 9,
    Tipo_persona = 1,
    Id_plan = 1
},
new Persona
{
    Id = 10,
    Nombre = "Diego",
    Apellido = "Gómez",
    Direccion = "Calle Este 78",
    Email = "diego@mail.com",
    Telefono = "369258",
    Fecha_nac = "1991-09-09",
    Legajo = 10,
    Tipo_persona = 1,
    Id_plan = 1
},
new Persona
{
    Id = 11,
    Nombre = "Marina",
    Apellido = "Ruiz",
    Direccion = "Calle Oeste 21",
    Email = "marina@mail.com",
    Telefono = "753159",
    Fecha_nac = "1993-06-25",
    Legajo = 11,
    Tipo_persona = 1,
    Id_plan = 1
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
                    
        }
            );
            modelBuilder.Entity<Inscripcion>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.Id_curso);
                entity.Property(e => e.Id_alumno);
                entity.Property(e => e.Condicion);
                entity.Property(e => e.Nota);
                entity.Property(e => e.Fecha_inscripcion);
                entity.HasOne<Curso>()
                      .WithMany()
                      .HasForeignKey(i => i.Id_curso)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne<Persona>()
                      .WithMany()
                      .HasForeignKey(i => i.Id_alumno)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasData(
             new Inscripcion { Id = 1, Id_curso = 1, Id_alumno = 1, Condicion = "Regular", Nota = 8, Fecha_inscripcion = new DateTime(2025, 1, 1) },
             new Inscripcion { Id = 2, Id_curso = 2, Id_alumno = 2, Condicion = "Aprobado", Nota = 10, Fecha_inscripcion = new DateTime(2025, 1, 2) },
             new Inscripcion { Id = 3, Id_curso = 1, Id_alumno = 3, Condicion = "Regular", Nota = 7, Fecha_inscripcion = new DateTime(2025, 1, 3) },
new Inscripcion { Id = 4, Id_curso = 2, Id_alumno = 4, Condicion = "Regular", Nota = 8, Fecha_inscripcion = new DateTime(2025, 1, 4) },
new Inscripcion { Id = 5, Id_curso = 3, Id_alumno = 5, Condicion = "Regular", Nota = 9, Fecha_inscripcion = new DateTime(2025, 1, 5) },
new Inscripcion { Id = 6, Id_curso = 4, Id_alumno = 6, Condicion = "Regular", Nota = 6, Fecha_inscripcion = new DateTime(2025, 1, 6) },
new Inscripcion { Id = 7, Id_curso = 1, Id_alumno = 7, Condicion = "Regular", Nota = 7, Fecha_inscripcion = new DateTime(2025, 1, 7) },
new Inscripcion { Id = 8, Id_curso = 2, Id_alumno = 8, Condicion = "Regular", Nota = 8, Fecha_inscripcion = new DateTime(2025, 1, 8) },
new Inscripcion { Id = 9, Id_curso = 3, Id_alumno = 9, Condicion = "Regular", Nota = 9, Fecha_inscripcion = new DateTime(2025, 1, 9) },
new Inscripcion { Id = 10, Id_curso = 4, Id_alumno = 10, Condicion = "Regular", Nota = 6, Fecha_inscripcion = new DateTime(2025, 1, 10) }
                  );

                
            });

            modelBuilder.Entity<Docente>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.Id_curso);
                entity.Property(e => e.Id_docente);
                entity.Property(e => e.Cargo);

                entity.HasOne<Curso>()
                      .WithMany()
                      .HasForeignKey(d => d.Id_curso)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne<Persona>()
                        .WithMany()
                        .HasForeignKey(d => d.Id_docente)
                        .OnDelete(DeleteBehavior.Restrict);

                entity.HasData(
                    new { Id = 1, Id_curso = 1, Id_docente = 1, Cargo = "Titular" },
                    new { Id = 2, Id_curso = 2, Id_docente = 2, Cargo = "Auxiliar" }
                    );
            });
        }
    }
}



