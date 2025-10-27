using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain.services;

namespace Forms.Usuario
{
    public partial class FormAgregarUsuario : Form
    {
        public FormAgregarUsuario()
        {
            InitializeComponent();
        }
        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:5290")
        };

        private int? personaIdSeleccionada = null;
        private async void buttonPost_Click(object sender, EventArgs e)
        {
            try
            {
                string idToFind = txtLegajo.Text;
                Domain.model.Persona? persona = await _httpClient.GetFromJsonAsync<Domain.model.Persona>($"personas/{idToFind}");
                if (persona != null)
                {
                    txtLegajo.Text = persona.Legajo.ToString();
                    string nombreUsuario = txtNombreUsuario.Text;
                    string tipo = "Usuario";
                    string clave = txtClave.Text;
                    bool habilitado = true;
                    string nombre = txtNombre.Text;
                    string apellido = txtApellido.Text;
                    string email = txtEmail.Text;
                    bool cambiaClave = false;
                    int legajo = 0;
                    if (!int.TryParse(txtLegajo.Text, out legajo))
                    {
                        return;
                    }
                    if (String.IsNullOrEmpty(nombreUsuario) || String.IsNullOrEmpty(clave) || String.IsNullOrEmpty(nombre) || String.IsNullOrEmpty(apellido) || String.IsNullOrEmpty(email)
                         || legajo == 0)
                    {
                        MessageBox.Show("Por favor, ingrese todos los campos", "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else
                    {
                        Domain.model.Usuario usuario = new Domain.model.Usuario()
                        {
                            Nombre_usuario = nombreUsuario,
                            Nombre = nombre,
                            Apellido = apellido,
                            Clave = clave,
                            Email = email,
                            Habilitado = habilitado,
                            Cambia_clave = cambiaClave,
                            Id_persona = personaIdSeleccionada ?? 0,
                            Tipo = tipo
                        };

                        var response = await _httpClient.PostAsJsonAsync("usuarios", usuario);

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Usuario cargado con éxito");
                            this.Close();


                        }
                        else
                        {
                            MessageBox.Show("Error al cargar el usuario");

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar los usuarios.\nFavor de ingresar un legajo correcto");
            }
            
        }
        private void buttonVerificar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtLegajo.Text, out int legajo))
            {
                MessageBox.Show("Ingrese un legajo válido.");
                return;
            }

            var personaRepo = new Data.PersonaRepository();
            var persona = personaRepo.GetByLegajo(legajo);

            if (persona != null)
            {
                txtNombre.Text = persona.Nombre;
                txtApellido.Text = persona.Apellido;
                txtEmail.Text = persona.Email;
                this.personaIdSeleccionada = persona.Id; 
            }
            else
            {
                MessageBox.Show("No se encontró una persona con ese legajo.");
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtEmail.Text = "";
                this.personaIdSeleccionada = null;
            }
        }
        private void FormAgregarUsuario_Load(object sender, EventArgs e)
        {
            //está de más
        }
    }
}
