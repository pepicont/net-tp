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
using Forms.Usuario;

namespace Forms.Persona
{
    public partial class FormPersonaNoAdmin : Form
    {
        public FormPersonaNoAdmin(string Id, string tipoUsuario)
        {
            InitializeComponent();
            _id = Id;
            _tipoUsuario = tipoUsuario;
        }
        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:5290")
        };
        private string _id;
        private Domain.model.Persona _persona;
        private string _tipoUsuario;

        private async void ButtonModificar_Click(object sender, EventArgs e)
        {
            Form modal = new FormModificarPersona(_persona, _tipoUsuario);

            // Mostrar como modal (bloquea la ventana padre)
            DialogResult result = modal.ShowDialog();

            // Procesar el resultado si es necesario
            if (result == DialogResult.OK)
            {

                // Recargar los datos en la grilla
                Domain.model.Persona persona = await _httpClient.GetFromJsonAsync<Domain.model.Persona>($"personas/{_id}");
                Grilla.DataSource = new List<Domain.model.Persona> { persona };
                _persona = persona;

            }
            // Liberar recursos
            modal.Dispose();
        }

        private async void FormPersonaNoAdmin_Load(object sender, EventArgs e)
        {
            Domain.model.Persona persona = await _httpClient.GetFromJsonAsync<Domain.model.Persona>($"personas/{_id}");
            Grilla.DataSource = new List<Domain.model.Persona> { persona };
            _persona = persona;
        }
    }
}
