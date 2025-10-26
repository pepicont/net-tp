

using Domain.model;

namespace Domain.validators
{
    public static class CursoValidator
    {

        public static string? Validate(Curso? curso)
        {
            if (curso == null)
                return "El objeto Plan no puede ser nulo.";

            if (curso.Id_materia == null || curso.Id_materia <= 0)
                return "Debe seleccionar una materia válida.";

            if (curso.Anio_calendario == null || curso.Anio_calendario <= 0)
                return "El año calendario debe ser un número positivo.";

            if (curso.Cupo == null || curso.Cupo <= 0 || curso.Cupo >= 200)
                return "El cupo debe ser un número positivo, hasta 200";

            if(string.IsNullOrWhiteSpace(curso.Nombre))
                return "El nombre es obligatorio.";

            return null; // Todo OK
        }
    }
}
