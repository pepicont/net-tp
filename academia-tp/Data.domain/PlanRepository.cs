using DataDomain;
using Domain.model;
using Microsoft.EntityFrameworkCore;
using DTOs;

namespace Data
{
    public class PlanRepository
    {

        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public Plan? GetOne(int id)
        {
            using var context = CreateContext();
            return context.Plan.Find(id);
            
        }

        public IEnumerable<Plan> GetAll()
        {
            using var context = CreateContext();
            return context.Plan.OrderBy(p => p.Desc).ToList();
        }

        public Plan Create(Plan plan)
        {
            using var context = CreateContext();
            context.Plan.Add(plan);
            context.SaveChanges();
            return plan;
        }

        public bool Update(int id, UpdatePlanDTO plan)
        {
            using var context = CreateContext();
            Plan? existingPlan = context.Plan.Find(id);

            if (existingPlan != null)
            {
                existingPlan.Desc = plan.Desc;
                existingPlan.Id_especialidad = (int)plan.Id_especialidad;
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
            var plan = context.Plan.Find(id);
            if (plan != null)
            {
                context.Plan.Remove(plan);
                context.SaveChanges();
                return true;
            }
            return false;
        }


    }
}
