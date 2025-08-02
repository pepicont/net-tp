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
    public partial class FormPutEspecialidad : Form
    {
        public FormPutEspecialidad()
        {
            InitializeComponent();
        }

        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:5290")
        };

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private bool ValidarCampos()
        {
            bool idVacio = string.IsNullOrWhiteSpace(TextBoxId.Text);
            bool descripcionVacia = string.IsNullOrWhiteSpace(richTextBoxDescripcion.Text);

            
            if (idVacio && descripcionVacia)
            {
                MessageBox.Show("Los campos ID y Descripción son obligatorios.", "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TextBoxId.Focus();
                return false;
            }
            if (idVacio)
            {
                MessageBox.Show("El campo ID es obligatorio.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TextBoxId.Focus();
                return false;
            }

            if (descripcionVacia)
            {
                MessageBox.Show("El campo Descripción es obligatorio.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                richTextBoxDescripcion.Focus();
                return false;
            }

            if (!int.TryParse(TextBoxId.Text, out int id))
            {
                MessageBox.Show("El ID debe ser un número válido.", "ID inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TextBoxId.Focus();
                return false;
            }

            return true;
        }

        private async void buttonPut_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return; 
            }

            try
            {
                int id = int.Parse(TextBoxId.Text);
                string desc = richTextBoxDescripcion.Text.Trim();

                Especialidad especialidad = new Especialidad(id, desc);
                var response = await _httpClient.PutAsJsonAsync($"especialidades/{id}", especialidad);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Especialidad modificada con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.richTextBoxDescripcion.Clear();
                    this.TextBoxId.Clear();
                }
                else
                {
                    MessageBox.Show($"Error al modificar la especialidad. Código de estado: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxBuscar.Text))
            {
                MessageBox.Show("Ingrese un ID para buscar.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxBuscar.Focus();
                return;
            }

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
                    else
                    {
                        MessageBox.Show("No se encontró la especialidad.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarCampos();
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show("No se encontró la especialidad.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un ID válido (debe ser un número).", "ID inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxBuscar.Focus();
            }
        }

     
        private void LimpiarCampos()
        {
            textBoxBuscar.Clear();
            TextBoxId.Clear();
            richTextBoxDescripcion.Clear();
        }
    }
}