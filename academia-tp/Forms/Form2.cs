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
using DTOs;

namespace Forms
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:5290")
        };

        private void label3_Click(object sender, EventArgs e)
        {
            //ignorar
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //ignorar
        }

        private async void buttonPut_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TextBoxId.Text);
            string desc = richTextBoxDescripcion.Text;
            Especialidad especialidad = new Especialidad(id, desc);
            var response = await _httpClient.PutAsJsonAsync($"especialidades/{id}",especialidad);    // TODO preguntar a porta que carajos pasa

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Especialidad modificada con éxito");
              
                // Limpiar los TextBox
                this.richTextBoxDescripcion.Clear();
                this.TextBoxId.Clear();
            }
            else
            {
                MessageBox.Show("Error al modificar la especialidad");
 
            }


        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //boton de buscar
            if (int.TryParse(textBoxBuscar.Text, out int id))
            {
                var especialidad = await _httpClient.GetFromJsonAsync<Especialidad>($"especialidades/{id}");

                if (especialidad != null)
                {
                    TextBoxId.Text = especialidad.Id.ToString();
                    richTextBoxDescripcion.Text = especialidad.Desc;
                }
                else
                {
                    MessageBox.Show("No se encontró la especialidad.");
                }

            }
            
        }
    }
}
