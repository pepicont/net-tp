using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.model
{
    public class Materia
    {
        public int Id { get; set; }
        public string Desc { get; set; }
        public int Hs_semanales { get; set; }
        public int Hs_totales { get; set; }
        public int Id_plan { get; set; }

        public Materia() { }

        public Materia( string descripcion, int hs_semanales, int hs_totales, int id_plan)
        {
            Desc = descripcion;
            Hs_semanales = hs_semanales;
            Hs_totales = hs_totales;
            Id_plan = id_plan;
        }
    }
}
