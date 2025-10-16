using DataDomain;
using Domain.model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class CursoRepository
    {

        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public Curso? GetOne(int id)
        {
            using var context = CreateContext();
            return context.Curso.Find(id);

        }

        public IEnumerable<Curso> GetAll()
        {
            using var context = CreateContext();
            return context.Curso.OrderBy(c => c.Id).ToList();
        }

        public Curso Create(Curso materia)
        {
            using var context = CreateContext();
            context.Curso.Add(materia);
            context.SaveChanges();
            return materia;
        }

        public bool Update(int id, Curso materia)
        {
            using var context = CreateContext();
            Curso? existingCurso = context.Curso.Find(id);

            if (existingCurso != null)
            {
                existingCurso.Id_comision = materia.Id_comision;
                existingCurso.Id_materia = materia.Id_materia;
                existingCurso.Anio_calendario = materia.Anio_calendario;
                existingCurso.Cupo = materia.Cupo;

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
            var materia = context.Curso.Find(id);
            if (materia != null)
            {
                context.Curso.Remove(materia);
                context.SaveChanges();
                return true;
            }
            return false;
        }







    }
}
