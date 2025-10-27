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

        public void Logout()
        {
            Usuario = null;
            NotifyStateChanged(); // Notificar el cambio
        }
        public void SetUsuario(Usuario usuario)
        {
            Usuario = usuario;
            NotifyStateChanged(); // Notificar el cambio
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }

    
}
