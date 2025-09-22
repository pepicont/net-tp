namespace Domain.services;
using Domain.model;
using DataDomain;
using DTOs;
using Data;

public class EspecialidadServices

{
    private EspecialidadRepository repository;
    public EspecialidadServices()
    {
        repository = new EspecialidadRepository();
    }

    public Especialidad? GetOne(int id)
    {
        return repository.GetOne(id);
    }

    public IEnumerable<Especialidad> GetAll()
    {
        return repository.GetAll();
    }

    public Especialidad Create(Especialidad especialidad)
    {
        return repository.Create(especialidad);
    }

    public bool Update(int id, EspecialidadDTO especialidad)
    {
        return repository.Update(id, especialidad);
    }

    public bool Delete(int id)
    {
        return repository.Delete(id);
    }
}
