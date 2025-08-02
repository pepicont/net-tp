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
            if (string.IsNullOrWhiteSpace(textBoxBuscar.Text))
            {
                MessageBox.Show("Ingrese un ID para buscar.");
                textBoxBuscar.Focus();
                return;
            }

            if (int.TryParse(textBoxBuscar.Text, out int id))
            {
                try
                {
                    var response = await _httpClient.GetAsync($"planes/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        var plan = await response.Content.ReadFromJsonAsync<Plan>();
                        if (plan != null)
                        {
                            TextBoxId.Text = plan.Id.ToString();
                            richTextBoxDescripcion.Text = plan.Desc;

                            // Buscar la descripción de la especialidad
                            await CargarDescripcionEspecialidad(plan.Id_especialidad);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo cargar la información del plan.");
                            LimpiarCampos();
                        }
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        MessageBox.Show("No se encontró el plan.");
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show($"Ocurrió un error al buscar el plan. Código: {response.StatusCode}");
                        LimpiarCampos();
                    }
                }
                catch (HttpRequestException)
                {
                    MessageBox.Show("Error de conexión con el servidor.");
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}");
                    LimpiarCampos();
                }
            }
            else
            {
                MessageBox.Show("Ingrese un ID válido.");
                textBoxBuscar.Focus();
                LimpiarCampos();
            }
        }

        private async Task CargarDescripcionEspecialidad(int idEspecialidad)
        {
            try
            {
                // Cargar todas las especialidades
                var especialidades = await _httpClient.GetFromJsonAsync<IEnumerable<Especialidad>>("especialidades");
                if (especialidades != null)
                {
                    // Buscar la especialidad por ID
                    var especialidad = especialidades.FirstOrDefault(e => e.Id == idEspecialidad);
                    if (especialidad != null)
                    {
                        txtIdEspecialidad.Text = especialidad.Desc; // Mostrar descripción
                    }
                    else
                    {
                        txtIdEspecialidad.Text = $"ID: {idEspecialidad} (Especialidad no encontrada)";
                    }
                }
                else
                {
                    txtIdEspecialidad.Text = $"ID: {idEspecialidad} (Error al cargar especialidades)";
                }
            }
            catch (Exception ex)
            {
                txtIdEspecialidad.Text = $"ID: {idEspecialidad} (Error: {ex.Message})";
            }
        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxId.Text))
            {
                MessageBox.Show("Primero debe buscar y seleccionar un plan para eliminar.");
                textBoxBuscar.Focus();
                return;
            }

            if (!int.TryParse(TextBoxId.Text, out int id))
            {
                MessageBox.Show("El ID del plan no es válido.");
                LimpiarCampos();
                return;
            }

            try
            {
                var response = await _httpClient.DeleteAsync($"planes/{id}");
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Plan eliminado con éxito.");
                    LimpiarTodosCampos();
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    MessageBox.Show("El plan ya no existe o fue eliminado previamente.");
                    LimpiarTodosCampos();
                }
                else
                {
                    MessageBox.Show($"Error al eliminar el plan. Código: {response.StatusCode}");
                }
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Error de conexión con el servidor.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}");
            }
        }

        private void LimpiarCampos()
        {
            TextBoxId.Clear();
            richTextBoxDescripcion.Clear();
            txtIdEspecialidad.Clear();
        }

        private void LimpiarTodosCampos()
        {
            textBoxBuscar.Clear();
            TextBoxId.Clear();
            richTextBoxDescripcion.Clear();
            txtIdEspecialidad.Clear();
        }
    }
}