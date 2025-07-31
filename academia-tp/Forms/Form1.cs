using System.Collections;
using System.Net.Http.Json;
using Domain.model;

namespace Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:5290") 
        };

        private async void buttonGetAll_Click(object sender, EventArgs e)
        {
            var especialidades = await _httpClient.GetFromJsonAsync<IEnumerable<Especialidad>>("especialidades");

            if (especialidades != null)
            {
                dataGridView1.DataSource = especialidades;
            }
            else
            {
                MessageBox.Show("No se encontraron especialidades.");
            }

        }

        private async void buttonGetOne_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int id))
            {
                try
                {
                    var especialidad = await _httpClient.GetFromJsonAsync<Especialidad>($"especialidades/{id}");

                    if (especialidad != null)
                    {
                        dataGridView1.DataSource = new List<Especialidad> { especialidad };
                    }
                    else
                    {
                        MessageBox.Show("No se encontró la especialidad."); //nunca entra
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show($"Error al consultar la especialidad: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Ingrese un ID válido."); //bueno para implementar en los otros
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
