using System;
using System.Collections.Generic;

namespace DTOs
{
    public class AlumnoReporteDto
    {
        public int Legajo { get; set; }
        public string? Nombre { get; set; } = "";
        public string? Apellido { get; set; } = "";
        public string? DescMateria { get; set; } = "";
        public string? DescComision { get; set; } = "";
        public int AnioCalendario { get; set; }
        public string? Condicion { get; set; } = "";
        public float? Nota { get; set; }
        public DateTime Fecha_inscripcion { get; set; }
    }
}