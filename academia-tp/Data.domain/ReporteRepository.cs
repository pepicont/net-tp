using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using DTOs;

namespace Data
{
    public class ReporteRepository
    {
        private readonly string _connectionString;

        public ReporteRepository()
        {
            _connectionString = @"Server=(localdb)\MSSQLLocalDB;Initial Catalog=TPI;Integrated Security=true;TrustServerCertificate=True";
        }

        
        // Obtiene alumnos por curso usando ADO.NET
        
        public List<AlumnoReporteDto> GetAlumnosPorCurso(int idCurso, int anio)
        {
            var alumnos = new List<AlumnoReporteDto>();

            string query = @"
                SELECT 
                    p.Legajo,
                    p.Nombre,
                    p.Apellido,
                    m.[Desc] AS DescMateria,
                    c.Anio_calendario AS AnioCalendario,
                    i.Condicion,
                    i.Nota,
                    i.Fecha_inscripcion
                FROM Curso c
                INNER JOIN Materia m ON c.Id_materia = m.Id
                LEFT JOIN Inscripcion i ON c.Id = i.Id_curso
                LEFT JOIN Persona p ON i.Id_alumno = p.Id
                WHERE c.Id = @IdCurso 
                  AND c.Anio_calendario = @Anio
                  AND (p.Tipo_persona = 1 OR p.Tipo_persona IS NULL)
                ORDER BY p.Apellido, p.Nombre";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@IdCurso", idCurso));
                    command.Parameters.Add(new SqlParameter("@Anio", anio));

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Verificar que el alumno exista (por el LEFT JOIN)
                            int legajoOrdinal = reader.GetOrdinal("Legajo");
                            if (reader.IsDBNull(legajoOrdinal))
                                continue;

                            var alumno = new AlumnoReporteDto
                            {
                                Legajo = reader.GetInt32(legajoOrdinal),
                                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                Apellido = reader.GetString(reader.GetOrdinal("Apellido")),
                                DescMateria = reader.GetString(reader.GetOrdinal("DescMateria")),
                                AnioCalendario = reader.GetInt32(reader.GetOrdinal("AnioCalendario")),
                                Condicion = reader.GetString(reader.GetOrdinal("Condicion")),
                                Fecha_inscripcion = reader.GetDateTime(reader.GetOrdinal("Fecha_inscripcion"))
                            };

                            // Manejar Nota (tipo real en SQL = float en C#, puede ser NULL)
                            int notaOrdinal = reader.GetOrdinal("Nota");
                            if (!reader.IsDBNull(notaOrdinal))
                            {
                                alumno.Nota = reader.GetFloat(notaOrdinal);
                            }

                            alumnos.Add(alumno);
                        }
                    }
                }
            }

            return alumnos;
        }

        
        // Obtiene cantidad de alumnos por curso usando ADO.NET
        
        public List<CursoCantidadDto> GetCantidadAlumnosPorCurso(int? materiaId, int? anio)
        {
            var datos = new List<CursoCantidadDto>();

            string query = @"
                SELECT 
                    c.Nombre AS NombreCurso,
                    COUNT(i.Id_alumno) AS CantidadAlumnos,
                    c.Cupo
                FROM Curso c
                LEFT JOIN Inscripcion i ON c.Id = i.Id_curso
                WHERE (@MateriaId IS NULL OR c.Id_materia = @MateriaId)
                  AND (@Anio IS NULL OR c.Anio_calendario = @Anio)
                GROUP BY c.Id, c.Nombre, c.Cupo
                ORDER BY c.Nombre";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@MateriaId", (object?)materiaId ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Anio", (object?)anio ?? DBNull.Value));

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            datos.Add(new CursoCantidadDto
                            {
                                NombreCurso = reader.GetString(reader.GetOrdinal("NombreCurso")),
                                CantidadAlumnos = reader.GetInt32(reader.GetOrdinal("CantidadAlumnos")),
                                Cupo = reader.GetInt32(reader.GetOrdinal("Cupo"))
                            });
                        }
                    }
                }
            }

            return datos;
        }

        
        // Obtiene nombre de un curso específico
        
        public string GetNombreCurso(int idCurso)
        {
            string nombreCurso = "Desconocido";

            string query = "SELECT Nombre FROM Curso WHERE Id = @IdCurso";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@IdCurso", idCurso));

                    connection.Open();

                    var result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        nombreCurso = result.ToString() ?? "Desconocido";
                    }
                }
            }

            return nombreCurso;
        }
    }
}