
using Domain.model;
using DataDomain;
using DTOs;
using Data;
namespace Domain.services
{
    public class CursoServices

    {
        private CursoRepository repository;
        private MateriaRepository materiaRepository;
        public CursoServices()
        {
            repository = new CursoRepository();
            materiaRepository = new MateriaRepository();
        }

        public Curso? GetOne(int id)
        {
            return repository.GetOne(id);
        }

        public IEnumerable<Curso> GetAll()
        {
            return repository.GetAll();
        }

        public Curso Create(Curso curso)
        {
            var materia = materiaRepository.GetOne(curso.Id_materia);
            if (materia == null)
            {
                throw new Exception("La materia con el ID especificado no existe.");
            }
            return repository.Create(curso);
        }

        public bool Update(int id, Curso curso)
        {
            var materia = materiaRepository.GetOne(curso.Id_materia);
            if (materia == null)
            {
                throw new Exception("La materia con el ID especificado no existe.");
            }
            return repository.Update(id, curso);
        }

        public bool Delete(int id)
        {
            return repository.Delete(id);
        }
    }
}