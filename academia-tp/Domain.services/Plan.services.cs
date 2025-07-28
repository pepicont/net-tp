namespace Domain.services;
using Domain.model;
using DataDomain;
using DTOs;


public class PlanServices

{
    public Plan Create(CreatePlanDTO planDTO)
    {
        int id = (InMemory.planes.Count()) + 1;
        Plan plan = new Plan(id, planDTO.Desc, planDTO.Id_especialidad);
        InMemory.planes.Add(plan);
        return plan;
    }


    public bool Delete(int id)
    {
        Plan? plan = InMemory.planes.Find(x => x.Id == id);

        if (plan != null)
        {
            InMemory.planes.Remove(plan);
            return true;
        }
        else
        {
            return false;
        }
    }


    public Plan GetOne(int id)
    {
        //Deberia devolver un objeto cloneado 
        Plan? plan = InMemory.planes.Find(x => x.Id == id);
        if (plan != null)
        {
            return new Plan(plan.Id, plan.Desc, plan.Id_especialidad);
        }
        return null;
    }


    public IEnumerable<Plan> GetAll()
    {
        return InMemory.planes.ToList();
    }

   
    public bool Update(int id, UpdatePlanDTO plan)
    {
        Plan ? planEncontrado = InMemory.planes.Find(x => x.Id == id);

        if (planEncontrado != null)
        {
            planEncontrado.Desc = plan.Desc;
            planEncontrado.Id_especialidad = (int)plan.Id_especialidad;
            return true;
        }
        else
        {
            return false;
        }
    }
}
