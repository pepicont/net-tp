using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataDomain;
using Domain.model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
     public class InscripcionRepository
    {
        private TPIContext CreateContext() 
        {
            return new TPIContext();
                }
        public Inscripcion? GetOne(int id)
        {
            using var context = CreateContext();
            return context.Inscripcion.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Inscripcion> GetAll()
        {
            using var context = CreateContext();
            return context.Inscripcion.OrderBy(p => p.Id).ToList();
        }

        public Inscripcion Create(Inscripcion inscripcion)
        {
            using var context = CreateContext();
            context.Inscripcion.Add(inscripcion);
            context.SaveChanges();
            return inscripcion;
        }


        public bool Update(int id, Inscripcion inscripcion)
        {
            using var context = CreateContext();
            var existingInscripcion = context.Inscripcion.Find(id);
            if (existingInscripcion == null)
                return false;
            existingInscripcion.Id_alumno = inscripcion.Id_alumno;
            existingInscripcion.Id_curso = inscripcion.Id_curso;
            existingInscripcion.Condicion = inscripcion.Condicion;
            existingInscripcion.Nota = inscripcion.Nota;
            existingInscripcion.Fecha_inscripcion = inscripcion.Fecha_inscripcion;
            context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var inscripcion = context.Inscripcion.Find(id);
            if (inscripcion == null)
                return false;
            context.Inscripcion.Remove(inscripcion);
            context.SaveChanges();
            return true;
        }
    }
}
