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

        private void buttonGetOne_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
