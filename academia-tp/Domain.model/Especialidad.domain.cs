namespace Domain.model
{
    public class Especialidad
    {

        public int Id { get; set; }
        public string Desc { get; set; }


        public Especialidad(int id_especialidad, string desc_especialidad)
        {
            this.Id = id_especialidad;
            this.Desc = desc_especialidad;
        }

    }
}
 