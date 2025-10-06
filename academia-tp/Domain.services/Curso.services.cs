
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
        private ComisionRepository comisionRepository;
        public CursoServices()
        {
            repository = new CursoRepository();
            materiaRepository = new MateriaRepository();
            comisionRepository = new ComisionRepository();
        }

        public Curso? GetOne(int id)
        {
            return repository.GetOne(id);
        }

        public IEnumerable<Curso> GetAll()
        {
            return repository.GetAll();
        }

        public Curso Create(Curso comision)
        {
            var materia = materiaRepository.GetOne(comision.Id_materia);
            if (materia == null)
            {
                throw new Exception("La materia con el ID especificado no existe.");
            }

            var comi = comisionRepository.GetOne(comision.Id_comision);
            if (comi == null)
            {
                throw new Exception("La comision con el ID especificado no existe.");
            }
            return repository.Create(comision);
        }

        public bool Update(int id, Curso comision)
        {
            var materia = materiaRepository.GetOne(comision.Id_materia);
            if (materia == null)
            {
                throw new Exception("La materia con el ID especificado no existe.");
            }

            var comi = comisionRepository.GetOne(comision.Id_comision);
            if (comi == null)
            {
                throw new Exception("La comision con el ID especificado no existe.");
            }
            return repository.Update(id, comision);
        }

        public bool Delete(int id)
        {
            return repository.Delete(id);
        }
    }
}