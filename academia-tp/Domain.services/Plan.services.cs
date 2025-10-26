
using Domain.model;
using DataDomain;
using DTOs;
using Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
namespace Domain.services
{
    public class PlanServices

    {
        private PlanRepository repository;
        public PlanServices()
        {
            repository = new PlanRepository();
        }

        public Plan? GetOne(int id)
        {
            return repository.GetOne(id);
        }

        public IEnumerable<Plan> GetAll()
        {
            return repository.GetAll();
        }

        public Plan Create(Plan plan)
        {
            return repository.Create(plan);
        }

        public bool Update(int id, UpdatePlanDTO plan)
        {
            return repository.Update(id, plan);
        }

        public bool Delete(int id)
        {
            try
            {
                return repository.Delete(id);
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is SqlException sqlEx && sqlEx.Number == 547)
                {
                    // No se puede eliminar porque tiene planes asociados
                    return false;
                }

                throw; // otros errores los propagás
            }
        }
    }
}