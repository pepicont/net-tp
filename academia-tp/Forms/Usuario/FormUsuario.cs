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
    

        private void ButtonCrear_Click(object sender, EventArgs e)
        {

        }

        private void ButtonModificar_Click(object sender, EventArgs e)
        {

        }

        private void ButtonEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
