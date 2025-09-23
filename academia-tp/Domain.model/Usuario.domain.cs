namespace Domain.model
{
    public class Usuario
    {

        public int Id { get; set; }
        public string Nombre_usuario { get; set; }
        public string Clave { get; set; }
        public bool Habilitado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public bool Cambia_clave { get; set; }
        public int Id_persona { get; set; }

        public Usuario() { }

        public Usuario(
            int id, 
            string nombreUsuario, 
            string clave,
            bool habilitado,
            string nombre,
            string apellido,
            string email,
            bool cambia_clave,
            int idPersona)
        {
            this.Id = id;
            this.Nombre_usuario = nombreUsuario ;
            this.Clave = clave;
            this.Habilitado = habilitado;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Email = email;
            this.Cambia_clave = cambia_clave;
            this.Id_persona = idPersona;

        }


    }
}
