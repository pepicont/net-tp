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
using Forms.Persona;

namespace Forms.Usuario
{
    public partial class FormUsuario : Form
    {

        public FormUsuario()
        {
            InitializeComponent();
        }
        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:5290")
        };

        private async void ButtonBuscar_Click(object sender, EventArgs e)
        {
            var usuarios = await _httpClient.GetFromJsonAsync<IEnumerable<Domain.model.Usuario>>("usuarios");

            string nombre_usuario = textBox1.Text;

            if (!string.IsNullOrEmpty(nombre_usuario))
            {
                if (usuarios != null)
                {
                    var personasNombreUsuarioParcial = usuarios
                        .Where(per => per.Nombre_usuario.ToString().Contains(nombre_usuario, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                    Grilla.DataSource = personasNombreUsuarioParcial;
                    if (!personasNombreUsuarioParcial.Any())
                    {
                        MessageBox.Show("No se encontraron usuarios con ese nombre de usuario parcial");
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron usuarios.");
                }
            }
            else
            {
                if (usuarios != null)
                {
                    Grilla.DataSource = usuarios;
                }
                else { MessageBox.Show("No se encontraron usuarios."); }
            }
        }
    

        private async void ButtonCrear_Click(object sender, EventArgs e)
        {
            Form modal = new FormAgregarUsuario();

            // Mostrar como modal (bloquea la ventana padre)
            DialogResult result = modal.ShowDialog();

            // Procesar el resultado si es necesario
            if (result == DialogResult.OK)
            {
                // Recargar los datos en la grilla
                var usuarios = await _httpClient.GetFromJsonAsync<IEnumerable<Domain.model.Usuario>>("usuarios");
                Grilla.DataSource = usuarios;
            }
            // Liberar recursos
            modal.Dispose();
        }

        private async void ButtonModificar_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un usuario a modificar primero",
                "Advertencia",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }
            else
            {
                int id = (int)Grilla.CurrentRow.Cells["Id"].Value;
                /*string nombreUsuario = Grilla.CurrentRow.Cells["Nombre_usuario"].Value.ToString();
                string nombre = Grilla.CurrentRow.Cells["Nombre"].Value.ToString();
                string apellido = Grilla.CurrentRow.Cells["Apellido"].Value.ToString();
                string clave = Grilla.CurrentRow.Cells["Clave"].Value.ToString();
                string email = Grilla.CurrentRow.Cells["Email"].Value.ToString();
                bool cambiaClave = (bool)Grilla.CurrentRow.Cells["Cambia_clave"].Value;
                bool habilitado = (bool)Grilla.CurrentRow.Cells["Habilitado"].Value;
                int idPersona = (int)Grilla.CurrentRow.Cells["Id_persona"].Value;

                Domain.model.Usuario usuario = new Domain.model.Usuario()
                {
                    Id = id,
                    Nombre_usuario = nombreUsuario,
                    Nombre = nombre,
                    Apellido = apellido,
                    Clave = clave,
                    Email = email,
                    Cambia_clave = cambiaClave,
                    Habilitado = habilitado,
                    Id_persona = idPersona

                };*/

                Form modal = new FormModificarUsuario(id.ToString()); /*usuario*/

                // Mostrar como modal (bloquea la ventana padre)
                DialogResult result = modal.ShowDialog();

                // Procesar el resultado si es necesario
                if (result == DialogResult.OK)
                {
                    // Recargar los datos en la grilla
                    var usuarios = await _httpClient.GetFromJsonAsync<IEnumerable<Domain.model.Usuario>>("usuarios");
                    Grilla.DataSource = usuarios;
                }
                // Liberar recursos
                modal.Dispose();
            }
        }

        private async void ButtonEliminar_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un usuario a borrar primero",
                "Advertencia",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }
            else
            {


                int idToDelete = (int)Grilla.CurrentRow.Cells["Id"].Value;

                Form modal = new FormDeleteUsuario();

                // Mostrar como modal (bloquea la ventana padre)
                DialogResult result = modal.ShowDialog();

                // Procesar el resultado si es necesario
                if (result == DialogResult.OK)
                {
                    // El usuario hizo clic en OK
                    var response = await _httpClient.DeleteAsync($"usuarios/{idToDelete}");
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Se eliminó el usuario");
                        var usuarios = await _httpClient.GetFromJsonAsync<IEnumerable<Domain.model.Usuario>>("usuarios");
                        Grilla.DataSource = usuarios;


                    }
                    else
                    {
                        MessageBox.Show("No se pudo borrar el usuario seleccionado",
                "Advertencia",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
                    }
                }

                // Liberar recursos
                modal.Dispose();


            }
        }
    }
}
