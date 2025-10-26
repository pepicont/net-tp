using Domain.model;
using DataDomain;
using DTOs;
using Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Domain.services
{
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
