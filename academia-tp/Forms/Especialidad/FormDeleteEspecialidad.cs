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

namespace Forms
{
    public partial class FormDeleteEspecialidad : Form
    {
        public FormDeleteEspecialidad()
        {
            InitializeComponent();
        }
        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:5290")
        };

        private async void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxBuscar.Text, out int id))
            {
                try
                {
                    var especialidad = await _httpClient.GetFromJsonAsync<Especialidad>($"especialidades/{id}");

                    if (especialidad != null)
                    {
                        TextBoxId.Text = especialidad.Id.ToString();
                        richTextBoxDescripcion.Text = especialidad.Desc;
                    }

                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show("No se encontró la especialidad.");
                    TextBoxId.Clear();
                    richTextBoxDescripcion.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error inesperado: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un ID válido.");
            }
        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.TextBoxId.Text);
            var response = await _httpClient.DeleteAsync($"especialidades/{id}");


            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Especialidad borrada con éxito");
                this.richTextBoxDescripcion.Clear();
                this.TextBoxId.Clear();
            }
            else
            {
                MessageBox.Show("Error al borrar la especialidad");
            }
        }

        private void richTextBoxDescripcion_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
