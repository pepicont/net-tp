using DataDomain;
using Domain.model;
using Microsoft.EntityFrameworkCore;
using DTOs;

namespace Data
{
    public class UsuarioRepository
    {

        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public Usuario? GetOne(int id)
        {
            using var context = CreateContext();
            Usuario? usuario = context.Usuario.Find(id);
            if (usuario != null)
            {
                return usuario;
            }
            return null;
        }

        public Usuario? GetByUserName(string username)
        {
            using var context = CreateContext();

            var usuario = context.Usuario.FirstOrDefault(u => u.Nombre_usuario == username);
            if (usuario != null)
            {
                return usuario;
            }
            return null;
        }

        public IEnumerable<Usuario> GetAll()
        {
            using var context = CreateContext();
            return context.Usuario.OrderBy(p => p.Nombre_usuario).ToList();
        }

        public Usuario Create(Usuario Usuario)
        {
            using var context = CreateContext();
            context.Usuario.Add(Usuario);
            context.SaveChanges();
            return Usuario;
        }

        public bool Update(int id, UsuarioDTO dto)
        {
            using var context = CreateContext();

            var existingUsuario = context.Usuario.Find(id);

            if (existingUsuario == null)
                return false;

            existingUsuario.Nombre_usuario = dto.Nombre_usuario;
            existingUsuario.Habilitado = dto.Habilitado;
            existingUsuario.Nombre = dto.Nombre;
            existingUsuario.Apellido = dto.Apellido;
            existingUsuario.Email = dto.Email;
            existingUsuario.Cambia_clave = dto.Cambia_clave;
            existingUsuario.Id_persona = dto.Id_persona;

            context.SaveChanges();
            return true;
        }


        public bool Delete(int id)
        {
            using var context = CreateContext();
            var Usuario = context.Usuario.Find(id);
            if (Usuario != null)
            {
                context.Usuario.Remove(Usuario);
                context.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
