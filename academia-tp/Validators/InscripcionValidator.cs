

using Domain.model;
using DTOs;

namespace Domain.validators
{
    public static class InscripcionValidator
    {

        public static string? Validate(InscripcionDTO? insc)
        {
            if (insc == null)
                return "El objeto Plan no puede ser nulo.";

            if(insc.Id_alumno <= 0)
                return "El Id del alumno es obligatorio y debe ser mayor que cero.";

            if (insc.Id_curso <= 0)
                return "El Id del curso es obligatorio y debe ser mayor que cero.";

            if(string.IsNullOrWhiteSpace(insc.Condicion))
                return "La condición es obligatoria.";
            if( insc.Condicion != "Aprobado" && insc.Condicion != "Libre" && insc.Condicion != "Regular" && insc.Condicion != "Inscripto")
                return "La condición debe ser 'Aprobado', 'Libre', 'Regular' o 'Inscripto'.";

            if (insc.Nota != null)
            {
                if (insc.Nota < 0 || insc.Nota > 10)
                    return "La nota debe estar entre 0 y 10.";
            }

            if(insc.Fecha_inscripcion < DateTime.Now)
                return "La fecha de inscripción no puede ser pasada.";

            return null; 
        }
    }
}
