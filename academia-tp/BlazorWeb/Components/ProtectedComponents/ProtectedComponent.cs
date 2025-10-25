using Domain.services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorWeb.Components.Base
{
    
    public abstract class ProtectedComponentBase : ComponentBase
    {
        [Inject]
        protected AuthServiceScoped AuthService { get; set; } = default!;

        [Inject]
        protected NavigationManager NavigationManager { get; set; } = default!;

        protected abstract string[] AllowedRoles { get; }
        public static class RenderModes
        {
            public static readonly InteractiveServerRenderMode ProtectedMode =
                new InteractiveServerRenderMode(prerender: false);
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            VerificarAutenticacion();
        }


        private void VerificarAutenticacion()
        {
            if (AuthService.Usuario == null || !AllowedRoles.Contains(AuthService.Usuario.Tipo))
            {
                NavigationManager.NavigateTo("/login", forceLoad: true);
            }
        }

    }
}