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
    public partial class ModalAgregarCurso : Form
    {
        public ModalAgregarCurso()
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
                var materias = await _httpClient.GetFromJsonAsync<IEnumerable<Materia>>("materias");
                if (materias != null)
                {
                    comboBox1.DataSource = materias.ToList();
                    comboBox1.DisplayMember = "Desc";
                    comboBox1.ValueMember = "Id";
                }
                var coms = await _httpClient.GetFromJsonAsync<IEnumerable<Comision>>("comisiones");
                if (coms != null)
                {
                    comboBox2.DataSource = coms.ToList();
                    comboBox2.DisplayMember = "Desc";
                    comboBox2.ValueMember = "Id";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar los materias o comisiones: {ex.Message}");
            }
        }

        private async void buttonPost_Click(object sender, EventArgs e)
        {
            string anioCalenText = txtAnioEsp.Text;
            
            if (!int.TryParse(txtAnioEsp.Text, out int anio_esp))
            {
                MessageBox.Show("Por favor, ingrese un año válido", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un plan", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if( comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione una comision", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if( !int.TryParse(txtCupo.Text, out int cupo))
            {
                MessageBox.Show("Por favor, ingrese un cupo válido", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            else
            {
                int id_materia = (int)comboBox1.SelectedValue;
                int id_comision = (int)comboBox2.SelectedValue;
                Curso curso = new Curso
                {
                    Id_materia = id_materia,
                    Id_comision = id_comision,
                    Anio_calendario = anio_esp,
                    Cupo = cupo
                };
                var response = await _httpClient.PostAsJsonAsync("cursos", curso);
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
