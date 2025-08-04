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
    public partial class ModalModificarPlan : Form
    {
        public ModalModificarPlan(Plan plan)
        {
            InitializeComponent();
            _plan = plan;
        }
        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:5290")
        };
        private readonly Plan _plan;
        private async void ModalModificarPlan_Load(object sender, EventArgs e)
        {
            try
            {
                var especialidades = await _httpClient.GetFromJsonAsync<IEnumerable<Especialidad>>("especialidades");
                if (especialidades != null)
                {
                    comboBox1.DataSource = especialidades.ToList();
                    comboBox1.DisplayMember = "Desc";
                    comboBox1.ValueMember = "Id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar las especialidades: {ex.Message}");
            }
        }
        private bool ValidarCampos()
        {
            bool descripcionVacia = string.IsNullOrWhiteSpace(richTextBoxDescripcion.Text);
            bool especialidadSeleccionada = comboBox1.SelectedItem != null;

            if (descripcionVacia)
            {
                MessageBox.Show("El campo Descripción es obligatorio.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                richTextBoxDescripcion.Focus();
                return false;
            }
            if(!especialidadSeleccionada)
            {
                MessageBox.Show("Debe seleccionar una especialidad.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox1.Focus();
                return false;
            }

            return true;
        }
        private async void buttonPut_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                try
                {

                    string desc = richTextBoxDescripcion.Text;
                    int id_especialidad = (int)comboBox1.SelectedValue;
                    Plan plan = new Plan(_plan.Id, desc,id_especialidad);
                    int id = _plan.Id;
                    var response = await _httpClient.PutAsJsonAsync($"planes/{id}", plan);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Plan modificado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK; // Solo aquí
                        

                    }
                    else
                    {
                        MessageBox.Show($"Error al modificar el plan. Código de estado: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
