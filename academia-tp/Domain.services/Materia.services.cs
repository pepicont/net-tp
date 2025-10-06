
using Domain.model;
using DataDomain;
using DTOs;
using Data;
namespace Domain.services
{
    public class MateriaServices

    {
        private MateriaRepository repository;
        private PlanRepository planRepository;
        public MateriaServices()
        {
            repository = new MateriaRepository();
            planRepository = new PlanRepository();
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
            var plan = planRepository.GetOne(materia.Id_plan);
            if (plan == null)
            {
                throw new Exception("El plan con el ID especificado no existe.");
            }
            return repository.Create(materia);
        }

        public bool Update(int id, Materia materia)
        {
            var plan = planRepository.GetOne(materia.Id_plan);
            if (plan == null)
            {
                throw new Exception("El plan con el ID especificado no existe.");
            }
            return repository.Update(id, materia);
        }

        public bool Delete(int id)
        {
            return repository.Delete(id);
        }
    }
}