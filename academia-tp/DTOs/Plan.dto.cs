using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class CreatePlanDTO
    {
        public string Desc { get; set; }

        public int Id_especialidad { get; set; }

        public CreatePlanDTO(string desc, int id_especialidad)
        {
            this.Desc = desc;
            this.Id_especialidad = id_especialidad;
        }
    }

    public class UpdatePlanDTO
    {
        public string? Desc { get; set; }
        public int? Id_especialidad { get; set; }

        public UpdatePlanDTO(string? desc = "", int? id_especialidad = 0)
        {
            Desc = desc;
            Id_especialidad = id_especialidad;
        }
    }
    
}


