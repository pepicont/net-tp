

using Domain.model;

namespace Domain.validators
{
    public static class PlanValidator
    {

        public static string? Validate(Plan? plan)
        {
            if (plan == null)
                return "El objeto Plan no puede ser nulo.";

            if (string.IsNullOrWhiteSpace(plan.Desc))
                return "La descripción es obligatoria.";

            if (plan.Id_especialidad == null || plan.Id_especialidad <= 0)
                return "Debe seleccionar una especialidad válida.";

            return null; // Todo OK
        }
    }
}
