

using Domain.model;

namespace Domain.validators
{
    public static class MateriaValidator
    {

        public static string? Validate(Materia? i)
        {
            if (i == null)
                return "La i no puede ser nula.";

            if (string.IsNullOrWhiteSpace(i.Desc))
                return "La descripción es obligatoria.";

            if(i.Hs_semanales <= 0 || i.Hs_semanales >= 20)
                return "Las horas semanales deben ser mayores a cero.";

            if (i.Hs_totales <= 0 || i.Hs_totales >= 200)
                return "Las horas totales deben ser mayores a cero.";

            if(i.Hs_semanales * 4 > i.Hs_totales)
                return "Las horas totales deben ser al menos cuatro veces las horas semanales.";

            if(i.Id_plan <= 0)
                return "Debe seleccionar un plan válido.";

            return null; 
        }
    }
}
