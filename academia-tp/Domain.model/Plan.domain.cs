using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.model
{
    public class Plan
    {

        public int Id { get; set; }

        public string Desc { get; set; }

        public int Id_especialidad { get; set; }

        public Plan(int id_plan, string desc, int id_especialidad)
        {
            this.Id = id_plan;
            this.Desc = desc;
            this.Id_especialidad = id_especialidad;
        }
    }
}
