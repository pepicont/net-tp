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
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Forms.Usuario
{
    public partial class FormUsuarioNoAdmin : Form
    {
        public FormUsuarioNoAdmin(string Id)
        {
            InitializeComponent();
            _id = Id;
        }
        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:5290")
        };
        private string _id;
        private Domain.model.Usuario _usuario;
        private async void ButtonModificar_Click(object sender, EventArgs e)
        {

            Form modal = new FormModificarUsuario(_usuario);

            // Mostrar como modal (bloquea la ventana padre)
            DialogResult result = modal.ShowDialog();

            // Procesar el resultado si es necesario
            if (result == DialogResult.OK)
            {
                
                // Recargar los datos en la grilla
                Domain.model.Usuario usuario = await _httpClient.GetFromJsonAsync<Domain.model.Usuario>($"usuarios/{_id}");
                Grilla.DataSource = new List<Domain.model.Usuario> { usuario };
                _usuario = usuario;
                
            }
            // Liberar recursos
            modal.Dispose();
        }
        private async void FormUsuarioNoAdmin_Load(object sender, EventArgs e)
        {
            Domain.model.Usuario usuario = await _httpClient.GetFromJsonAsync<Domain.model.Usuario>($"usuarios/{_id}");
            Grilla.DataSource = new List<Domain.model.Usuario> { usuario };
            _usuario = usuario;
        }
    }
}
