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
            return context.Usuario.Find(id);
        }

        public Usuario? GetByUserName(string username)
        {
            using var context = CreateContext();

            return context.Usuario.FirstOrDefault(u => u.Nombre_usuario == username);
            
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

        public bool Update(int id, Usuario usu)
        {
            using var context = CreateContext();

            var existingUsuario = context.Usuario.Find(id);

            if (existingUsuario == null)
                return false;

            existingUsuario.Nombre_usuario = usu.Nombre_usuario;
            existingUsuario.Habilitado = usu.Habilitado;
            existingUsuario.Nombre = usu.Nombre;
            existingUsuario.Apellido = usu.Apellido;
            existingUsuario.Email = usu.Email;
            existingUsuario.Cambia_clave = usu.Cambia_clave;
            existingUsuario.Id_persona = usu.Id_persona;

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
