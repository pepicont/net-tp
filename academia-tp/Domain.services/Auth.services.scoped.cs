using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.model;
using Data;
using DTOs;

namespace Domain.services
{
    public class AuthServiceScoped
    {
        private readonly UsuarioRepository _repository;

        public AuthServiceScoped()
        {
            _repository = new UsuarioRepository();
            Usuario = null;
        }

        public Usuario? Usuario { get; private set; }

        // Evento para notificar cambios de estado
        public event Action? OnChange;

        public Usuario? Login(string nombreUsuario, string clave)
        {
            var usuario = _repository.GetByUserName(nombreUsuario);

            if (usuario == null)
                return null;

            if (!usuario.Habilitado)
                return null;

            if (!PasswordHasherSingleton.VerifyPassword(clave, usuario.Clave))
                return null;

            Usuario = usuario;
            NotifyStateChanged(); // Notificar el cambio
            return usuario;
        }

        public Usuario Register(Usuario usuario)
        {
            var existingUser = _repository.GetByUserName(usuario.Nombre_usuario);
            if (existingUser != null)
                throw new Exception("El nombre de usuario ya está en uso.");

            var allUsers = _repository.GetAll();

            usuario.Clave = PasswordHasherSingleton.HashPassword(usuario.Clave);
            usuario.Habilitado = true;
            usuario.Cambia_clave = false;

            return _repository.Create(usuario);
        }

        public void Logout()
        {
            Usuario = null;
            NotifyStateChanged(); // Notificar el cambio
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }

    // ===== PASSWORD HASHER =====
    public static class PasswordHasherSingleton
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