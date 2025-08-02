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
        public Form3()
        {
            InitializeComponent();
        }

        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:5290")
        };


        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private async void buttonPost_Click(object sender, EventArgs e) //form post plan
        {
           

            string desc = txtDesc.Text;
            
            if (comboBoxIdEspecialidad.SelectedItem == null || string.IsNullOrEmpty(desc))
            {
                MessageBox.Show("Debe completar todos los campos antes de enviar el formulario.");
                return;
            }
            int id_especialidad = (int)comboBoxIdEspecialidad.SelectedItem;

            CreatePlanDTO plan = new CreatePlanDTO(desc, id_especialidad);
            var response = await _httpClient.PostAsJsonAsync("planes", plan);
            if (response.IsSuccessStatusCode)
            {
                txtDesc.Clear();
                comboBoxIdEspecialidad.SelectedItem = null; // Limpiar el ComboBox
                MessageBox.Show("Plan cargado con éxito");
            }
            else
            {
                MessageBox.Show("Error al cargar el plan");
            }
        }

        private async void buttonRefresh_Click(object sender, EventArgs e)
        {
            try
            {
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
        }
    }
}


