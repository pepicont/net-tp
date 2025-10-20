using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.model;
using Data;



namespace Domain.services
{
    public class DocenteSevices
    {
        private DocenteRepository repository;
        private CursoRepository cursoRepository;
        private PersonaRepository personaRepository;

        public DocenteSevices()
        {
            repository = new DocenteRepository();
            cursoRepository = new CursoRepository();
            personaRepository = new PersonaRepository();
        }

        public Docente? GetOne(int id)
        {
            return repository.GetOne(id);
        }

        public IEnumerable<Docente> GetAll()
        {
            return repository.GetAll();
        }

        public Docente Create(Docente comision)
        {
            var persona = personaRepository.GetOne(comision.Id_docente);
            if (persona == null)
            {
                throw new Exception("El docente con el ID especificado no existe.");
            }
            var curso = cursoRepository.GetOne(comision.Id_curso);
            if (curso == null)
            {
                throw new Exception("El curso con el ID especificado no existe.");
            }
            return repository.Create(comision);
        }

        public bool Update(int id, Docente comision)
        {
            var persona = personaRepository.GetOne(comision.Id_docente);
            if (persona == null)
            {
                throw new Exception("El docente con el ID especificado no existe.");
            }
            var curso = cursoRepository.GetOne(comision.Id_curso);
            if (curso == null)
            {
                throw new Exception("El curso con el ID especificado no existe.");
            }
            return repository.Update(id, comision);
        }

        public bool Delete(int id)
        {
            return repository.Delete(id);
        }
    }
}
