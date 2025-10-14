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
    public partial class ModalAgregarComision : Form
    {
        public ModalAgregarComision()
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
                var plan = await _httpClient.GetFromJsonAsync<IEnumerable<Plan>>("planes");
                if (plan != null)
                {
                    comboBox1.DataSource = plan.ToList();
                    comboBox1.DisplayMember = "Desc";
                    comboBox1.ValueMember = "Id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar los planes: {ex.Message}");
            }
        }

        private async void buttonPost_Click(object sender, EventArgs e)
        {
            string desc = RichTextBoxDescripcion.Text;
            string anioEspText = txtAnioEsp.Text;
            
            if (!int.TryParse(txtAnioEsp.Text, out int anio_esp))
            {
                MessageBox.Show("Por favor, ingrese un año válido", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (String.IsNullOrEmpty(desc))
            {
                MessageBox.Show("Por favor, ingrese una descripción", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un plan", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int id_plan = (int)comboBox1.SelectedValue;
                Comision comision = new Comision
                {
                    Desc = desc,
                    Anio_especialidad = anio_esp,
                    Id_plan = id_plan
                };
                var response = await _httpClient.PostAsJsonAsync("comisiones", comision);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Comision cargada con éxito");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al cargar el plan");
                }
            }
        }

       

        
    }
}
