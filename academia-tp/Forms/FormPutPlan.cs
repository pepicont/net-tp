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

                        try
                        {
                            var especialidades = await _httpClient.GetFromJsonAsync<IEnumerable<Especialidad>>("especialidades");
                            if (especialidades != null)
                            {
                                comboBoxIdEspecialidad.DataSource = especialidades.ToList();
                                comboBoxIdEspecialidad.DisplayMember = "Desc";  // Muestra la descripción
                                comboBoxIdEspecialidad.ValueMember = "Id";      // Usa el ID como valor
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al consultar las especialidades: {ex.Message}");
                        }

                        if (plan != null)
                        {
                            TextBoxId.Text = plan.Id.ToString();
                            richTextBoxDescripcion.Text = plan.Desc;
                            comboBoxIdEspecialidad.SelectedValue = plan.Id_especialidad; // Usar SelectedValue
                        }
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        MessageBox.Show("No se encontró el plan.");
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al buscar el plan. Código: " + response.StatusCode);
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show($"Error al consultar el plan: {ex.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al consultar el plan: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Ingrese un ID válido.");
                textBoxBuscar.Focus();
                LimpiarCampos();
            }
        }

        private bool ValidarCampos()
        {
            bool idVacio = string.IsNullOrWhiteSpace(TextBoxId.Text);
            bool descripcionVacia = string.IsNullOrWhiteSpace(richTextBoxDescripcion.Text);
            bool especialidadVacia = comboBoxIdEspecialidad.SelectedValue == null;

            if (idVacio && descripcionVacia && especialidadVacia)
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                TextBoxId.Focus();
                return false;
            }

            if (idVacio)
            {
                MessageBox.Show("El campo ID es obligatorio.");
                TextBoxId.Focus();
                return false;
            }

            if (descripcionVacia)
            {
                MessageBox.Show("El campo Descripción es obligatorio.");
                richTextBoxDescripcion.Focus();
                return false;
            }

            if (especialidadVacia)
            {
                MessageBox.Show("Debe seleccionar una especialidad.");
                comboBoxIdEspecialidad.Focus();
                return false;
            }

            if (!int.TryParse(TextBoxId.Text, out int id))
            {
                MessageBox.Show("El ID debe ser un número válido.");
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
                int id_especialidad = (int)comboBoxIdEspecialidad.SelectedValue; // Usar SelectedValue

                Plan plan = new Plan(id, desc, id_especialidad);
                var response = await _httpClient.PutAsJsonAsync($"planes/{id}", plan);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Plan modificado con éxito");
                    LimpiarTodosCampos();
                }
                else
                {
                    MessageBox.Show($"Error al modificar el plan. Código: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}");
            }
        }

        private void LimpiarCampos()
        {
            TextBoxId.Clear();
            richTextBoxDescripcion.Clear();
            comboBoxIdEspecialidad.DataSource = null;
        }

        private void LimpiarTodosCampos()
        {
            textBoxBuscar.Clear();
            TextBoxId.Clear();
            richTextBoxDescripcion.Clear();
            comboBoxIdEspecialidad.DataSource = null;
        }
    }
}