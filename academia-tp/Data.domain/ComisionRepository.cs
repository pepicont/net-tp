using DataDomain;
using Domain.model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ComisionRepository
    {

        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public Comision? GetOne(int id)
        {
            using var context = CreateContext();
            return context.Comision.Find(id);

        }

        public IEnumerable<Comision> GetAll()
        {
            using var context = CreateContext();
            return context.Comision.OrderBy(p => p.Desc).ToList();
        }

        public Comision Create(Comision materia)
        {
            using var context = CreateContext();
            context.Comision.Add(materia);
            context.SaveChanges();
            return materia;
        }

        public bool Update(int id, Comision materia)
        {
            using var context = CreateContext();
            Comision? existingComision = context.Comision.Find(id);

            if (existingComision != null)
            {
                existingComision.Desc = materia.Desc;
                existingComision.Anio_especialidad = materia.Anio_especialidad;
                existingComision.Id_plan = (int)materia.Id_plan;
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
            var materia = context.Comision.Find(id);
            if (materia != null)
            {
                context.Comision.Remove(materia);
                context.SaveChanges();
                return true;
            }
            return false;
        }







    }
}
