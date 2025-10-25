namespace BlazorWeb.Components.Base
{
    public abstract class ProtectedUser : ProtectedComponentBase
    {
        protected override string[] AllowedRoles => new[] { "Usuario" };
    }
}
