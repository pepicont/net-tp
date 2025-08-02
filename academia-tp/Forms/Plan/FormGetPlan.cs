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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Forms
{
    public partial class FormGetPlan : Form
    {
        public FormGetPlan()
        {
            InitializeComponent();
        }

        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:5290")
        };

        private async void buttonGetAll_Click_1(object sender, EventArgs e)
        {
            try
            {
                var planes = await _httpClient.GetFromJsonAsync<IEnumerable<Plan>>("planes");
                if (planes != null && planes.Any())
                {
                    dataGridView1.DataSource = planes.ToList();
                }
                else
                {
                    MessageBox.Show("No se encontraron planes.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los planes: {ex.Message}");
            }
        }

        private async void buttonGetOne_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int id))
            {
                try
                {
                    var plan = await _httpClient.GetFromJsonAsync<Plan>($"planes/{id}");

                    if (plan != null)
                    {
                        dataGridView1.DataSource = new List<Plan> { plan };
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el plan.");
                    }
                }
                catch (HttpRequestException ex) when (ex.Message.Contains("404"))
                {
                    MessageBox.Show("No se encontró el plan.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al consultar el plan: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Ingrese un ID válido.");
            }
        }
    }
}