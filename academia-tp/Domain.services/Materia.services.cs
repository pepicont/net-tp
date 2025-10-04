
using Domain.model;
using DataDomain;
using DTOs;
using Data;
namespace Domain.services
{
    public class MateriaServices

    {
        private MateriaRepository repository;
        public MateriaServices()
        {
            repository = new MateriaRepository();
        }

        public Materia? GetOne(int id)
        {
            return repository.GetOne(id);
        }

        public IEnumerable<Materia> GetAll()
        {
            return repository.GetAll();
        }

        public Materia Create(Materia materia)
        {
            return repository.Create(materia);
        }

        public bool Update(int id, Materia materia)
        {
            return repository.Update(id, materia);
        }

        public bool Delete(int id)
        {
            return repository.Delete(id);
        }
    }
}