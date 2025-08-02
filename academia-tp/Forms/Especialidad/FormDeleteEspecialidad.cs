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
            if (string.IsNullOrWhiteSpace(textBoxBuscar.Text))
            {
                MessageBox.Show("Por favor, ingrese un ID para buscar.", "Campo requerido",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxBuscar.Focus();
                return;
            }

            if (int.TryParse(textBoxBuscar.Text.Trim(), out int id))
            {
                try
                {
                    var especialidad = await _httpClient.GetFromJsonAsync<Especialidad>($"especialidades/{id}");
                    if (especialidad != null)
                    {
                        TextBoxId.Text = especialidad.Id.ToString();
                        richTextBoxDescripcion.Text = especialidad.Desc ?? string.Empty; // Manejar null
                    }
                    else
                    {
                        MessageBox.Show("No se encontró la especialidad con el ID especificado.",
                                       "Especialidad no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarCampos();
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show("No se encontró la especialidad o error de conexión.",
                                   "Error de búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}",
                                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LimpiarCampos();
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un ID numérico válido.",
                               "ID inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxBuscar.Focus();
                textBoxBuscar.SelectAll();
            }
        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxId.Text))
            {
                MessageBox.Show("Primero debe buscar y seleccionar una especialidad para eliminar.",
                               "No hay especialidad seleccionada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            if (int.TryParse(TextBoxId.Text, out int id))
            {
                try
                {
                    var response = await _httpClient.DeleteAsync($"especialidades/{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Especialidad eliminada con éxito.",
                                       "Eliminación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarCampos();
                        textBoxBuscar.Clear();
                        textBoxBuscar.Focus();
                    }
                    else
                    {
                        string errorMessage = response.StatusCode switch
                        {
                            System.Net.HttpStatusCode.NotFound => "La especialidad no existe o ya fue eliminada.",
                            System.Net.HttpStatusCode.Conflict => "No se puede eliminar la especialidad porque está en uso.",
                            _ => $"Error al eliminar la especialidad. Código: {response.StatusCode}"
                        };

                        MessageBox.Show(errorMessage, "Error al eliminar",
                                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show("Error de conexión con el servidor. Verifique que el servicio esté disponible.",
                                   "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}",
                                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("El ID no es válido.", "Error de validación",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarCampos();
            }
        }

        private void LimpiarCampos()
        {
            TextBoxId.Clear();
            richTextBoxDescripcion.Clear();
        }

        private void richTextBoxDescripcion_TextChanged(object sender, EventArgs e)
        {
        }
    }
}