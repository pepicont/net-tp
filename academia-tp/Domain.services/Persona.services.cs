using DataDomain;
using Domain.model;
using Microsoft.EntityFrameworkCore;
using DTOs;
using Data;
namespace Domain.services
{

    public class PersonaServices

    {
        private PersonaRepository repository;
        public PersonaServices()
        {
            repository = new PersonaRepository();
        }

        public Persona? GetOne(int id)
        {
            return repository.GetOne(id);
        }
        public Persona? GetByLegajo(int leg)
        {
            return repository.GetByLegajo(leg);
        }

        public IEnumerable<Persona> GetAll()
        {
            return repository.GetAll();
        }

        public Persona Create(Persona persona)
        {
            return repository.Create(persona);
        }

        public bool Update(int id, Persona persona)
        {
            return repository.Update(id, persona);
        }

        public bool Delete(int id)
        {
            return repository.Delete(id);
        }
    }
}