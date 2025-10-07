using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.model
{
    public class Inscripcion
    {
        public int Id { get; set; }
        public int Id_alumno { get; set; }

        public int Id_curso { get; set; }

        public string Condicion { get; set; }

        public float? Nota { get; set; }

    

    public Inscripcion(int id_alumno, int id_curso, string condicion, float? nota)
        {
            Id_alumno = id_alumno;
            Id_curso = id_curso;
            Condicion = condicion;
            Nota = nota;
        }
    } 

}
