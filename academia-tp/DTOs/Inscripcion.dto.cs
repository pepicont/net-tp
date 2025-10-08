using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
    {
        public class InscripcionDTO
        {
            public int Id { get; set; }
            public int Id_alumno { get; set; }
            public int Id_curso { get; set; }
            public int LegajoAlumno { get; set; }
            public string NombreAlumno { get; set; }
            public string ApellidoAlumno { get; set; }
            public string DescMateria { get; set; }
            public string DescComision { get; set; }
            public int AnioCalendario { get; set; }
            public string Condicion { get; set; }
            public float? Nota { get; set; }
            public DateTime Fecha_inscripcion { get; set; }
        }
    }
