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
    public partial class ModalAgregarPlan : Form
    {
        public ModalAgregarPlan()
        {
            InitializeComponent();
        }
        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:5290")
        };
        private async void ModalAgregarPlan_Load(object sender, EventArgs e)
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

        private async void buttonPost_Click(object sender, EventArgs e)
        {
            string desc = RichTextBoxDescripcion.Text;
            if (String.IsNullOrEmpty(desc))
            {
                MessageBox.Show("Por favor, ingrese una descripción", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione una especialidad", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else

            {
                int id_especialidad = (int)comboBox1.SelectedValue;
                CreatePlanDTO planes = new CreatePlanDTO(desc,id_especialidad);
                var response = await _httpClient.PostAsJsonAsync("planes", planes);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Plan cargado con éxito");
                    this.DialogResult = DialogResult.OK; // Cerrar el modal con éxito


                }
                else
                {
                    MessageBox.Show("Error al cargar el plan");

                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
