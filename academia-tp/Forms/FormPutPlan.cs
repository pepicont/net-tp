using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain.model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Forms
{
    public partial class FormPutPlan : Form
    {
        public FormPutPlan()
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
                    var plan = await _httpClient.GetFromJsonAsync<Plan>($"planes/{id}");
                    try {
                        var especialidades = await _httpClient.GetFromJsonAsync<IEnumerable<Especialidad>>("especialidades");
                        if (especialidades != null)
                        {
                            // Obtener la lista de IDs de las especialidades
                            var listaIdsEspecialidades = especialidades.Select(e => e.Id).ToList();
                            comboBoxIdEspecialidad.DataSource = listaIdsEspecialidades;
                        }
                        
                    }
                    catch (HttpRequestException ex)
                    {
                        MessageBox.Show($"Error al consultar las especialidades disponibles: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al consultar las especialidades disponibles: {ex.Message}");
                    }
                    if (plan != null)
                    {
                        TextBoxId.Text = plan.Id.ToString();
                        richTextBoxDescripcion.Text = plan.Desc;
                        comboBoxIdEspecialidad.SelectedItem = plan.Id_especialidad;

                    }
                    else
                    {
                        MessageBox.Show("No se encontró el plan."); //nunca entra
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show($"Error al consultar el plan: {ex.Message}");
                }
                catch (Exception ex) {
                    MessageBox.Show($"Error al consultar el plan: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Ingrese un ID válido."); //bueno para implementar en los otros
            }
        }

        private async void buttonPut_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TextBoxId.Text);
            string desc = richTextBoxDescripcion.Text;
            int id_especialidad = (int)comboBoxIdEspecialidad.SelectedItem; // no puede ser null
            Plan plan = new Plan(id, desc, id_especialidad);
            var response = await _httpClient.PutAsJsonAsync($"planes/{id}", plan);    // TODO preguntar a porta que carajos pasa

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Plan modificado con éxito");

                // Limpiar los TextBox
                this.richTextBoxDescripcion.Clear();
                this.TextBoxId.Clear();
                this.comboBoxIdEspecialidad.SelectedIndex= -1; // Limpiar el comboBox
            }
            else
            {
                MessageBox.Show("Error al modificar el plan");

            }
        }
    }
}
