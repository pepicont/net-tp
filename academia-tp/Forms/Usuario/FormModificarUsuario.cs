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
        public FormModificarUsuario(Domain.model.Usuario usuario)
        {
            InitializeComponent();
            _usuario = usuario;

            // Si el tipo de usuario es "Usuario", el campo txtLegajo y los radios serán solo lectura
            if (_usuario.Tipo == "Usuario")
            {
                txtLegajo.Enabled = false;
                radioSi.Enabled = false;
                radioNo.Enabled = false;
            }
        }

        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:5290")
        };
        private Domain.model.Usuario _usuario;

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

                    
                    if (!_usuario.Cambia_clave && clave != _usuario.Clave)
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
                        var response = await _httpClient.PutAsJsonAsync($"usuarios/{_usuario.Id.ToString()}", usuarioPut);

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
            txtNombreUsuario.Text = _usuario.Nombre_usuario;
            txtNombre.Text = _usuario.Nombre;
            txtApellido.Text = _usuario.Apellido;
            txtEmail.Text = _usuario.Email;
            txtLegajo.Text = _usuario.Id_persona.ToString();

            if (_usuario.Habilitado)
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
