

using Domain.model;

namespace Domain.validators
{
    public static class EspecialidadValidator
    {
        
        public static string? Validate(Especialidad? especialidad)
        {
            if (especialidad == null)
                return "El objeto Especialidad no puede ser nulo.";

            if (string.IsNullOrWhiteSpace(especialidad.Desc))
                return "La descripción es obligatoria.";

            return null; 
        }
    }
}
