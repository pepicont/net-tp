using Domain.model;
using Data;
using DTOs;

namespace Domain.services
{
    public static class AuthService
    {
        

        public static Usuario? Login(string nombreUsuario, string clave)
        {
            UsuarioRepository repository = new UsuarioRepository();

            
            var usuario = repository.GetByUserName(nombreUsuario);

            if (usuario == null)
                return null;

            if (!usuario.Habilitado)
                return null;

            if (!PasswordHasher.VerifyPassword(clave, usuario.Clave))
                return null;

            return usuario;
        }

        public static Usuario Register(Usuario dto)
        {
            UsuarioRepository repository = new UsuarioRepository();

            var existingUser = repository.GetByUserName(dto.Nombre_usuario);
            if (existingUser != null)
                throw new Exception("El nombre de usuario ya está en uso.");

            var allUsers = repository.GetAll();

            dto.Clave = PasswordHasher.HashPassword(dto.Clave);
            dto.Habilitado = true;
            dto.Cambia_clave = false;

            return repository.Create(dto);
        }
    }


    // ===== PASSWORD HASHER =====
    public static class PasswordHasher
    {
        // Work factor (coste computacional)
        private const int WorkFactor = 12; 

        public static string HashPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("La contraseña no puede estar vacía", nameof(password));
            }

            return BCrypt.Net.BCrypt.HashPassword(password, workFactor: WorkFactor);
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(hashedPassword))
                return false;

            try
            {
                return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
            }
            catch
            {
                return false;
            }
        }

        
    }
}
