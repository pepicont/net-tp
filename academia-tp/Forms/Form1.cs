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
                    var response = await _httpClient.GetAsync($"especialidades/{id}");

                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        MessageBox.Show("No se encontró la especialidad.");
                        dataGridView1.DataSource = null;
                        return;
                    }

                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"Error al consultar la especialidad. Código: {response.StatusCode}");
                        dataGridView1.DataSource = null;
                        return;
                    }

                    var especialidad = await response.Content.ReadFromJsonAsync<Especialidad>();

                    if (especialidad != null && especialidad.Id != 0)
                    {
                        dataGridView1.DataSource = new List<Especialidad> { especialidad };
                    }
                    else
                    {
                        MessageBox.Show("No se encontró la especialidad.");
                        dataGridView1.DataSource = null;
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show($"Error de conexión al consultar la especialidad: {ex.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error inesperado: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Ingrese un ID válido.");
                dataGridView1.DataSource = null;
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
