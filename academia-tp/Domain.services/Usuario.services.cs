using DataDomain;
using Domain.model;
using Microsoft.EntityFrameworkCore;
using DTOs;
using Data;
namespace Domain.services
{

    public class UsuarioServices

    {
        private UsuarioRepository repository;
        public UsuarioServices()
        {
            repository = new UsuarioRepository();
        }

        public Usuario? GetOne(int id)
        {
            return repository.GetOne(id);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return repository.GetAll();
        }

        public Usuario Create(Usuario usuario)
        {
            usuario.Clave = PasswordHasher.HashPassword(usuario.Clave);
            return repository.Create(usuario);
        }

        public bool Update(int id, Usuario usuario)
        {
            usuario.Clave = PasswordHasher.HashPassword(usuario.Clave);
            return repository.Update(id, usuario);
        }

        public bool Delete(int id)
        {
            return repository.Delete(id);
        }
    }
}