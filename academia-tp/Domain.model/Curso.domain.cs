using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.model
{
    public class Curso
    {
        public int Id { get; set; }
        public int Id_materia { get; set; }
        public int Anio_calendario { get; set; }
        public int Cupo { get; set; }

        public Curso() { }

        public Curso( int idMateria, int anioCalendario, int cupo)
        {
            Id_materia = idMateria;
            Anio_calendario = anioCalendario;
            Cupo = cupo;
        }
    }
}
