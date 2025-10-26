using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataDomain;
using Domain.model;

namespace Data
{
    public class DocenteRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public Docente? GetOne(int id)
        {
            using var context = CreateContext();
            return context.Docente.Find(id);

        }

        public IEnumerable<Docente> GetAll()
        {
            using var context = CreateContext();
            return context.Docente.ToList();
        }

        public Docente Create(Docente materia)
        {
            using var context = CreateContext();
            context.Docente.Add(materia);
            context.SaveChanges();
            return materia;
        }

        public bool Update(int id, Docente materia)
        {
            using var context = CreateContext();
            Docente? existingDocente = context.Docente.Find(id);

            if (existingDocente != null)
            {
                existingDocente.Id_docente = materia.Id_docente;
                existingDocente.Id_curso = materia.Id_curso;
                existingDocente.Cargo = materia.Cargo;
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var materia = context.Docente.Find(id);
            if (materia != null)
            {
                context.Docente.Remove(materia);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
