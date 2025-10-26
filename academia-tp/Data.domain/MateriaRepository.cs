using DataDomain;
using Domain.model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class MateriaRepository
    {

        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public Materia? GetOne(int id)
        {
            using var context = CreateContext();
            return context.Materia.Find(id);

        }

        public IEnumerable<Materia> GetAll()
        {
            using var context = CreateContext();
            return context.Materia.OrderBy(p => p.Desc).ToList();
        }

        public Materia Create(Materia materia)
        {
            using var context = CreateContext();
            context.Materia.Add(materia);
            context.SaveChanges();
            return materia;
        }

        public bool Update(int id, Materia materia)
        {
            using var context = CreateContext();
            Materia? existingMateria = context.Materia.Find(id);

            if (existingMateria != null)
            {
                existingMateria.Desc = materia.Desc;
                existingMateria.Hs_totales = materia.Hs_totales;
                existingMateria.Hs_semanales = materia.Hs_totales;
                existingMateria.Id_plan = (int)materia.Id_plan;
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
            var materia = context.Materia.Find(id);
            if (materia != null)
            {
                context.Materia.Remove(materia);
                context.SaveChanges();
                return true;
            }
            return false;
        }







    }
}
