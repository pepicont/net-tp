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
    public partial class ModalModificarCurso : Form
    {
        public ModalModificarCurso(int id,Curso curso)
        {
            InitializeComponent();
            _curso = curso;
            _curso.Id = id;
        }
        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:5290")
        };
        private readonly Curso _curso;
        private async void ModalModificarComision_Load_1(object sender, EventArgs e)
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
                MessageBox.Show($"Error al consultar los planes: {ex.Message}");
            }
            TextBoxId.Text = _curso.Id.ToString();
            txtAnioEsp.Text = _curso.Anio_calendario.ToString();
            txtCupo.Text = _curso.Cupo.ToString();
            

        }

        private async void buttonPut_Click(object sender, EventArgs e)
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
            else if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione una comision", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!int.TryParse(txtCupo.Text, out int cupo))
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
                var response = await _httpClient.PutAsJsonAsync("cursos", curso);
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
