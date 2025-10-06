
using Domain.model;
using DataDomain;
using DTOs;
using Data;
namespace Domain.services
{
    public class ComisionServices

    {
        private ComisionRepository repository;
        private PlanRepository planRepository;
        public ComisionServices()
        {
            repository = new ComisionRepository();
            planRepository = new PlanRepository();
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
            var plan = planRepository.GetOne(comision.Id_plan);
            if (plan == null)
            {
                throw new Exception("El plan con el ID especificado no existe.");
            }
            return repository.Create(comision);
        }

        public bool Update(int id, Comision comision)
        {
            var plan = planRepository.GetOne(comision.Id_plan);
            if (plan == null)
            {
                throw new Exception("El plan con el ID especificado no existe.");
            }
            return repository.Update(id, comision);
        }

        public bool Delete(int id)
        {
            return repository.Delete(id);
        }
    }
}