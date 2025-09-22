namespace Domain.model
{
    public class Persona
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Fecha_nac { get; set; }
        public int Legajo { get; set; }
        public int Tipo_persona { get; set; }
        public int Id_plan { get; set; }

        public Persona(
            int id,
            string nombre,
            string apellido,
            string direccion,
            string email,
            string telefono,
            string fecha_nac,
            int legajo,
            int tipo_persona,
            int id_plan)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Direccion = direccion;
            this.Email = email;
            this.Telefono = telefono;
            this.Fecha_nac = fecha_nac;
            this.Legajo = legajo;
            this.Tipo_persona = tipo_persona;
            this.Id_plan = id_plan;
        }

    }
}
