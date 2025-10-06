
using Domain.model;
using DataDomain;
using DTOs;
using Data;
namespace Domain.services
{
    public class ComisionServices

    {
        private ComisionRepository repository;
        public ComisionServices()
        {
            repository = new ComisionRepository();
        }

        public Comision? GetOne(int id)
        {
            return repository.GetOne(id);
        }

        public IEnumerable<Comision> GetAll()
        {
            return repository.GetAll();
        }

        public Comision Create(Comision comision)
        {
            return repository.Create(comision);
        }

        public bool Update(int id, Comision comision)
        {
            return repository.Update(id, comision);
        }

        public bool Delete(int id)
        {
            return repository.Delete(id);
        }
    }
}