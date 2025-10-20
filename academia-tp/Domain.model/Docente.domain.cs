using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.model
{
    public class Docente
    {
        public int Id { get; set; }
        public int Id_docente { get; set; }
        public int Id_curso { get; set; }
        public string Cargo { get; set; }

        public Docente()
        {
        }
        public Docente( int id_docente, int id_curso, string cargo)
        {
            Id_docente = id_docente;
            Id_curso = id_curso;
            Cargo = cargo;
        }
    }
}
