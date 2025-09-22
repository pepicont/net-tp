using DataDomain;
using Domain.model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class PersonaRepository
    {

        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public Persona? GetOne(int id)
        {
            using var context = CreateContext();
           Persona? Persona = context.Persona.Find(id);
            if (Persona != null)
            {
                return Persona;
            }
            return null;
        }

        public Persona? GetByLegajo(string leg)
        {
            using var context = CreateContext();
            if (!int.TryParse(leg, out int legajo))
            {
                return null;
            }
            var persona = context.Persona.FirstOrDefault(u => u.Legajo == legajo);
            if (persona != null)
            {
                return persona;
            }
            return null;
        }

        public IEnumerable<Persona> GetAll()
        {
            using var context = CreateContext();
            return context.Persona.OrderBy(p => p.Nombre).ToList();
        }

        public Persona Create(Persona persona)
        {
            using var context = CreateContext();
            context.Persona.Add(persona);
            context.SaveChanges();
            return persona;
        }

        public bool Update(int id, Persona persona)
        {
            using var context = CreateContext();

            var existingPersona = context.Persona.Find(id);

            if (existingPersona == null)
                return false;

            existingPersona.Nombre = persona.Nombre;
            existingPersona.Apellido = persona.Apellido;
            existingPersona.Direccion= persona.Direccion;
            existingPersona.Email= persona.Email;
            existingPersona.Telefono = persona.Telefono;
            existingPersona.Fecha_nac= persona.Fecha_nac;
            existingPersona.Tipo_persona= persona.Tipo_persona;
            existingPersona.Id_plan = persona.Id_plan;
            context.SaveChanges();
            return true;
        }


        public bool Delete(int id)
        {
            using var context = CreateContext();
            var persona = context.Persona.Find(id);
            if (persona != null)
            {
                context.Persona.Remove(persona);
                context.SaveChanges();
                return true;
            }
            return false;
        }







    }
}
