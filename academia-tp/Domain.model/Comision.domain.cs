using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.model
{
    public class Comision
    {
        public int Id { get; set; }
        public string Desc { get; set; }
        
        public int Anio_especialidad { get; set; }
        public int Id_plan { get; set; }

        public Comision() { }

        public Comision( string descripcion, int anio_esp, int id_plan)
        {
            Desc = descripcion;
            Anio_especialidad = anio_esp;
            Id_plan = id_plan;
        }
    }
}
