namespace BlazorWeb.Components.Base
{
    public abstract class ProtectedAdmin : ProtectedComponentBase
    {
        protected override string[] AllowedRoles => new[] { "Admin" };
    }
}
