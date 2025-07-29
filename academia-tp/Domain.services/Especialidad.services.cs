namespace Domain.services;
using Domain.model;
using DataDomain;
using DTOs;
using System;
using System.Linq;

public class EspecialidadServices
{
    public Especialidad GetOne(int id)
    {
        Especialidad? especialidad = InMemory.especialidades.Find(x => x.Id == id);
        if (especialidad != null)
        {
            return new Especialidad(especialidad.Id, especialidad.Desc);
        }
        return null;
    }

    public IEnumerable<Especialidad> GetAll()
    {
        List <Especialidad> especialidades = InMemory.especialidades.ToList();
        if (especialidades != null)
        {
            especialidades.ForEach(x => new Especialidad(x.Id, x.Desc));
        }
        return especialidades;
    }
        

    public Especialidad Create(EspecialidadDTO especialidadDTO)
    {
        int id = (InMemory.especialidades.Count()) + 1;
        Especialidad especialidad = new Especialidad(id, especialidadDTO.Desc);
        InMemory.especialidades.Add(especialidad);
        return especialidad;
    }

    public bool Delete(int id)
    {
        Especialidad? especialidad = InMemory.especialidades.Find(x => x.Id == id);

        if (especialidad != null)
        {
            InMemory.especialidades.Remove(especialidad);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Update(int id, EspecialidadDTO especialidad)
    {
        Especialidad? especialidadActualizada = InMemory.especialidades.Find(x => x.Id == id);

        if (especialidadActualizada != null)
        {
            especialidadActualizada.Desc = especialidad.Desc;
            return true;
        }
        else
        {
            return false;
        }
    }
}



