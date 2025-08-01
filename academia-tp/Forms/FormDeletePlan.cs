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
    public partial class FormDeletePlan : Form
    {
        public FormDeletePlan()
        {
            InitializeComponent();
        }
        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:5290")
        };



        private async void button1_Click_1(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxBuscar.Text, out int id))
            {
                try
                {
                    var plan = await _httpClient.GetFromJsonAsync<Plan>($"planes/{id}");

                    if (plan != null)
                    {
                        TextBoxId.Text = plan.Id.ToString();
                        richTextBoxDescripcion.Text = plan.Desc;
                        txtIdEspecialidad.Text = plan.Id_especialidad.ToString();
                    }

                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show("No se encontró el plan.");
                    TextBoxId.Clear();
                    richTextBoxDescripcion.Clear();
                    txtIdEspecialidad.Clear();
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
            var response = await _httpClient.DeleteAsync($"planes/{id}");

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Plan borrado con éxito");
                this.richTextBoxDescripcion.Clear();
                this.TextBoxId.Clear();
                this.txtIdEspecialidad.Clear();
            }
            else
            {
                MessageBox.Show("Error al borrar Plan");
            }
        }
    }
}
