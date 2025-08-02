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
    public partial class Form3 : Form
    {
        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:5290")
        };

        public Form3()
        {
            InitializeComponent();
        }

        private async void Form3_Load(object sender, EventArgs e)
        {
            await CargarEspecialidades();
        }

        private async Task CargarEspecialidades()
        {
            try
            {
                var especialidades = await _httpClient.GetFromJsonAsync<IEnumerable<Especialidad>>("especialidades");
                if (especialidades != null && especialidades.Any())
                {
                    comboBoxIdEspecialidad.DataSource = especialidades.ToList();
                    comboBoxIdEspecialidad.DisplayMember = "Desc";  // Muestra la descripción
                    comboBoxIdEspecialidad.ValueMember = "Id";      // Usa el ID como valor
                    comboBoxIdEspecialidad.SelectedIndex = -1;      // No seleccionar nada inicialmente
                }
                else
                {
                    MessageBox.Show("No se encontraron especialidades disponibles.");
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error al consultar las especialidades: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}");
            }
        }

        private async void buttonPost_Click(object sender, EventArgs e)
        {
            string desc = txtDesc.Text;
            if (comboBoxIdEspecialidad.SelectedItem == null || string.IsNullOrEmpty(desc))
            {
                MessageBox.Show("Debe completar todos los campos antes de enviar el formulario.");
                return;
            }

            int id_especialidad = (int)comboBoxIdEspecialidad.SelectedValue; // Usar SelectedValue en lugar de SelectedItem
            CreatePlanDTO plan = new CreatePlanDTO(desc, id_especialidad);

            try
            {
                var response = await _httpClient.PostAsJsonAsync("planes", plan);
                if (response.IsSuccessStatusCode)
                {
                    txtDesc.Clear();
                    comboBoxIdEspecialidad.SelectedIndex = -1; // Usar SelectedIndex = -1 para limpiar
                    MessageBox.Show("Plan cargado con éxito");
                }
                else
                {
                    MessageBox.Show($"Error al cargar el plan. Código: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el plan: {ex.Message}");
            }
        }

        private async void buttonRefresh_Click(object sender, EventArgs e)
        {
            await CargarEspecialidades();
        }

        private void comboBoxIdEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }
    }
}