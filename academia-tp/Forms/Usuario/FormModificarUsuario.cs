using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain.model;

namespace Forms.Usuario
{
    public partial class FormModificarUsuario : Form
    {
        public FormModificarUsuario(string id)
        {
            InitializeComponent();
            _id = id;
            
        }
        private readonly string _id;

        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:5290")
        };

        private async void buttonPut_Click(object sender, EventArgs e)
        {
            try
            {
                string idToFind = txtLegajo.Text;
                Domain.model.Persona? persona = await _httpClient.GetFromJsonAsync<Domain.model.Persona>($"personas/{idToFind}");
                if (persona != null)
                {
                    string nombreUsuario = txtNombreUsuario.Text;
                    string clave = txtClave.Text;
                    bool habilitado = true;
                    if (radioNo.Checked)
                    {
                        habilitado = false;
                    }
                    string nombre = txtNombre.Text;
                    string apellido = txtApellido.Text;
                    string email = txtEmail.Text;
                    bool cambiaClave = false;

                    Domain.model.Usuario usuario = await _httpClient.GetFromJsonAsync<Domain.model.Usuario>($"usuarios/{_id}");
                    if (!usuario.Cambia_clave && clave != usuario.Clave)
                    {
                        cambiaClave = true;
                    }
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
                        Domain.model.Usuario usuarioPut = new Domain.model.Usuario()
                        {
                            Nombre_usuario = nombreUsuario,
                            Nombre = nombre,
                            Apellido = apellido,
                            Clave = clave,
                            Email = email,
                            Habilitado = habilitado,
                            Cambia_clave = cambiaClave,
                            Id_persona = legajo,
                        };
                        var response = await _httpClient.PutAsJsonAsync($"usuarios/{usuario.Id.ToString()}", usuarioPut);

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Usuario modificado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK; // Solo aquí
                        }
                        else
                        {
                            MessageBox.Show($"Error al modificar el usuario. Código de estado: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar las personas.\nFavor de ingresar un legajo correcto");
            }
        }

        private async void FormModificarUsuario_Load(object sender, EventArgs e)
        {
            Domain.model.Usuario usuario = await _httpClient.GetFromJsonAsync<Domain.model.Usuario>($"usuarios/{_id}");
            txtNombreUsuario.Text = usuario.Nombre;
            txtNombre.Text = usuario.Nombre;
            txtApellido.Text = usuario.Apellido;
            txtEmail.Text = usuario.Email;
            txtLegajo.Text = usuario.Id_persona.ToString();

            if (usuario.Habilitado)
            {
                radioSi.Checked = true;
                radioNo.Checked = false;
            }
            else
            {
                radioSi.Checked = false;
                radioNo.Checked = true;
            }
        }
    }
}
