using DataDomain;
using Domain.model;
using Microsoft.EntityFrameworkCore;
using DTOs;

namespace Data
{
    public class EspecialidadRepository
    {

        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public Especialidad? GetOne(int id)
        {
            using var context = CreateContext();
            Especialidad? especialidad = context.Especialidad.Find(id);
            if (especialidad != null)
            {
                return especialidad;
            }
            return null;
        }

        public IEnumerable<Especialidad> GetAll()
        {
            using var context = CreateContext();
            return context.Especialidad.OrderBy(p => p.Desc).ToList();
        }

        public Especialidad Create(Especialidad especialidad)
        {
            using var context = CreateContext();
            context.Especialidad.Add(especialidad);
            context.SaveChanges();
            return especialidad;
        }

        public bool Update(int id, EspecialidadDTO especialidad)
        {
            using var context = CreateContext();
            Especialidad? existingEspecialidad = context.Especialidad.Find(id);

            if (existingEspecialidad != null)
            {
                existingEspecialidad.Desc = especialidad.Desc;
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
            var especialidad = context.Especialidad.Find(id);
            if (especialidad != null)
            {
                context.Especialidad.Remove(especialidad);
                context.SaveChanges();
                return true;
            }
            return false;
        }







    }
}
