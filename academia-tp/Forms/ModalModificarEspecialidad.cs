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
    public partial class ModalModificarEspecialidad : Form
    {
        public ModalModificarEspecialidad(Especialidad especialidad)
        {
            InitializeComponent();
            buttonPut.DialogResult = DialogResult.OK;
        }
        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:5290")
        };

      

        private bool ValidarCampos()
        {
            bool descripcionVacia = string.IsNullOrWhiteSpace(richTextBoxDescripcion.Text);

            if (descripcionVacia)
            {
                MessageBox.Show("El campo Descripción es obligatorio.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                richTextBoxDescripcion.Focus();
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
                TextBoxId.Text = especialidad.Id;
                string desc = richTextBoxDescripcion.Text;

                Especialidad especialidad = new Especialidad(id, desc);
                var response = await _httpClient.PutAsJsonAsync($"especialidades/{id}", especialidad);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Especialidad modificada con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

              
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

        private void ModalModificarEspecialidad_Load(object sender, EventArgs e)
        {

        }
    }
}
