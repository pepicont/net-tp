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
    public partial class FormPersona : Form
    {
        public FormPersona()
        {
            InitializeComponent();
        }
        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:5290")
        };

        private async void ButtonBuscar_Click(object sender, EventArgs e)
        {
            var personas = await _httpClient.GetFromJsonAsync<IEnumerable<Domain.model.Persona>>("personas");

            string legajo = textBox1.Text;

            if (!string.IsNullOrEmpty(legajo))
            {
                if (personas != null)
                { 
                    var personasDescParcial = personas
                        .Where(per => per.Legajo.ToString().Contains(legajo, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                    Grilla.DataSource = personasDescParcial;
                    if (!personasDescParcial.Any())
                    {
                        MessageBox.Show("No se encontraron personas con esa descripción parcial");
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron personas.");
                }
            }
            else
            {
                if (personas != null)
                {
                    Grilla.DataSource = personas;
                }
                else { MessageBox.Show("No se encontraron personas."); }
            }
        }

        private async void ButtonCrear_Click(object sender, EventArgs e)
        {
            Form modal = new ModalAgregarPersona();

            // Mostrar como modal (bloquea la ventana padre)
            DialogResult result = modal.ShowDialog();

            // Procesar el resultado si es necesario
            if (result == DialogResult.OK)
            {
                // Recargar los datos en la grilla
                var personas = await _httpClient.GetFromJsonAsync<IEnumerable<Domain.model.Persona>>("personas");
                Grilla.DataSource = personas;
            }
            // Liberar recursos
            modal.Dispose();
        }

        private void ButtonModificar_Click(object sender, EventArgs e)
        {

        }

        private void ButtonEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
