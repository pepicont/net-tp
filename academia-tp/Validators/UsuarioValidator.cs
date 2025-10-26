

using Domain.model;

namespace Domain.validators
{
    public static class UsuarioValidator
    {

        public static string? Validate(Usuario? i)
        {
            if (i == null)
                return "El objeto Plan no puede ser nulo.";

            if(string.IsNullOrWhiteSpace(i.Nombre))
                return "El nombre no puede estar vacío.";

            if(string.IsNullOrWhiteSpace(i.Apellido))
                return "El apellido no puede estar vacío.";

            if(string.IsNullOrWhiteSpace(i.Email))
                return "El email no puede estar vacío.";

            if(string.IsNullOrWhiteSpace(i.Nombre_usuario))
                return "El nombre de usuario debe ser un valor positivo.";
            if(i.Id_persona <= 0)
                return "El ID de la persona debe ser un valor positivo.";

            return null; // Todo OK
        }
    }
}
