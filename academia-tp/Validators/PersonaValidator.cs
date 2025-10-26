

using Domain.model;

namespace Domain.validators
{
    public static class PersonaValidator
    {

        public static string? Validate(Persona? i)
        {
            if (i == null)
                return "El objeto Plan no puede ser nulo.";

            if(string.IsNullOrWhiteSpace(i.Nombre))
                return "El nombre no puede estar vacío.";

            if(string.IsNullOrWhiteSpace(i.Apellido))
                return "El apellido no puede estar vacío.";

            if(string.IsNullOrWhiteSpace(i.Direccion))
                return "La dirección no puede estar vacía.";

            if(string.IsNullOrWhiteSpace(i.Email))
                return "El email no puede estar vacío.";

            if(string.IsNullOrWhiteSpace(i.Telefono))
                return "El teléfono no puede estar vacío.";

            if(string.IsNullOrWhiteSpace(i.Fecha_nac))
                return "La fecha de nacimiento no puede estar vacía.";

            if(i.Tipo_persona <= 0)
                return "El tipo de persona debe ser un valor positivo.";

            if(i.Id_plan <= 0)
                return "El ID del plan debe ser un valor positivo.";

            if (i.Legajo < 0)
                return "El legajo no puede ser un valor negativo.";


            return null; 
        }
    }
}
