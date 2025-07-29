namespace Domain.model
{
    public class Especialidad
    {

        public int Id { get; set; }
        public string Desc { get; set; }


        public Especialidad(int id, string desc)
        {
            this.Id = id;
            this.Desc = desc;
        }

    }
}
 