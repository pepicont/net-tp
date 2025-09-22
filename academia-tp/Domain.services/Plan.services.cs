namespace Domain.services;
using Domain.model;
using DataDomain;
using DTOs;
using Data;

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
        return repository.Delete(id);
    }
}
