using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Domain.model;
using DTOs;

namespace Domain.services
{
    public class InscripcionServices
    {
        private readonly InscripcionRepository inscripcionRepository;
        private readonly PersonaRepository personaRepository;
        private readonly CursoRepository cursoRepository;
        private readonly MateriaRepository materiaRepository;

        public InscripcionServices()
        {
            inscripcionRepository = new InscripcionRepository();
            personaRepository = new PersonaRepository();
            cursoRepository = new CursoRepository();
            materiaRepository = new MateriaRepository();
        }

        public Inscripcion? GetOne(int id)
        {
            return inscripcionRepository.GetOne(id);
        }

        public IEnumerable<InscripcionDTO> SearchDTO(string searchTerm)
        {
            var inscripciones = inscripcionRepository.GetAll().ToList();

            // Si hay término de búsqueda, filtrar antes de convertir a DTO
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var normalizedSearchTerm = searchTerm.Trim().ToLower();
                inscripciones = FilterInscripciones(inscripciones, normalizedSearchTerm);
            }

            return ConvertToDTO(inscripciones);
        }

        public IEnumerable<InscripcionDTO> GetInscripcionesByAlumno(int idAlumno)
        {
            var inscripciones = inscripcionRepository.GetAll()
                .Where(i => i.Id_alumno == idAlumno)
                .ToList();
            return ConvertToDTO(inscripciones);
        }

        public Inscripcion? Create(Inscripcion inscripcion)
        {
            // Validar alumno
            var alumno = personaRepository.GetOne(inscripcion.Id_alumno);
            if (alumno == null || alumno.Tipo_persona != 1)
                throw new InvalidOperationException("El alumno no existe o no es de tipo alumno.");

            // Validar curso
            var curso = cursoRepository.GetOne(inscripcion.Id_curso);
            if (curso == null)
                throw new InvalidOperationException("El curso no existe.");

            // Validar que no esté ya inscripto
            var yaInscripto = inscripcionRepository.GetAll()
                .Any(i => i.Id_alumno == inscripcion.Id_alumno && i.Id_curso == inscripcion.Id_curso);
            if (yaInscripto)
                throw new InvalidOperationException("El alumno ya está inscripto en este curso.");

            // Validar cupo
            var inscriptosEnCurso = inscripcionRepository.GetAll()
                .Count(i => i.Id_curso == inscripcion.Id_curso);
            if (inscriptosEnCurso >= curso.Cupo)
                throw new InvalidOperationException("No hay cupo disponible para este curso.");

            return inscripcionRepository.Create(inscripcion);
        }

        public bool Update(int id, Inscripcion inscripcion)
        {
            return inscripcionRepository.Update(id, inscripcion);
        }

        public bool Delete(int id)
        {
            return inscripcionRepository.Delete(id);
        }

        // Métodos privados optimizados
        private List<Inscripcion> FilterInscripciones(List<Inscripcion> inscripciones, string searchTerm)
        {
            // Cargar datos una sola vez para el filtrado
            var personas = personaRepository.GetAll().ToList();
            var cursos = cursoRepository.GetAll().ToList();
            var materias = materiaRepository.GetAll().ToList();

            return inscripciones.Where(inscripcion =>
            {
                // Buscar por alumno
                var alumno = personas.FirstOrDefault(p => p.Id == inscripcion.Id_alumno);
                if (alumno != null &&
                    (alumno.Nombre.ToLower().Contains(searchTerm) ||
                     alumno.Apellido.ToLower().Contains(searchTerm)))
                {
                    return true;
                }

                // Buscar por curso/materia
                var curso = cursos.FirstOrDefault(c => c.Id == inscripcion.Id_curso);
                if (curso != null)
                {
                    var materia = materias.FirstOrDefault(m => m.Id == curso.Id_materia);

                    if ((materia != null && materia.Desc.ToLower().Contains(searchTerm)))          
                    {
                        return true;
                    }
                }

                return false;
            }).ToList();
        }

        private IEnumerable<InscripcionDTO> ConvertToDTO(IEnumerable<Inscripcion> inscripciones)
        {
            // Cargar datos una sola vez
            var personas = personaRepository.GetAll().ToList();
            var cursos = cursoRepository.GetAll().ToList();
            var materias = materiaRepository.GetAll().ToList();

            return inscripciones.Select(inscripcion =>
            {
                var dto = new InscripcionDTO
                {
                    Id = inscripcion.Id,
                    Id_alumno = inscripcion.Id_alumno,
                    Id_curso = inscripcion.Id_curso,
                    Condicion = inscripcion.Condicion,
                    Nota = inscripcion.Nota,
                    Fecha_inscripcion = inscripcion.Fecha_inscripcion
                };

                // Datos del alumno
                var alumno = personas.FirstOrDefault(p => p.Id == inscripcion.Id_alumno);
                if (alumno != null)
                {
                    dto.NombreAlumno = alumno.Nombre;
                    dto.ApellidoAlumno = alumno.Apellido;
                    dto.LegajoAlumno = alumno.Legajo;
                }

                // Datos del curso
                var curso = cursos.FirstOrDefault(c => c.Id == inscripcion.Id_curso);
                if (curso != null)
                {
                    dto.AnioCalendario = curso.Anio_calendario;

                    var materia = materias.FirstOrDefault(m => m.Id == curso.Id_materia);
                    if (materia != null)
                        dto.DescMateria = materia.Desc;
                }

                return dto;
            }).ToList();
        }
        public List<AlumnoReporteDto> GetAlumnosPorCurso(int idCurso, int anio)
        {
            var inscripciones = inscripcionRepository.GetByCursoAnio(idCurso, anio);
            var personas = personaRepository.GetAll().ToList();
            var cursos = cursoRepository.GetAll().ToList();
            var materias = materiaRepository.GetAll().ToList();

            return inscripciones.Select(i =>
            {
                var persona = personas.FirstOrDefault(p => p.Id == i.Id_alumno);
                var curso = cursos.FirstOrDefault(c => c.Id == i.Id_curso);
                var materia = materias.FirstOrDefault(m => m.Id == curso?.Id_materia);

                return new AlumnoReporteDto
                {
                    Legajo = persona?.Legajo ?? 0,
                    Nombre = persona?.Nombre ?? "",
                    Apellido = persona?.Apellido ?? "",
                    DescMateria = materia?.Desc ?? "",
                    AnioCalendario = curso?.Anio_calendario ?? 0,
                    Condicion = i.Condicion,
                    Nota = i.Nota,
                    Fecha_inscripcion = i.Fecha_inscripcion
                };
            }).ToList();
        }
    }

    }
