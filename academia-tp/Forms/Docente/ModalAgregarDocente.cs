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
    public partial class ModalAgregarDocente : Form
    {
        public ModalAgregarDocente()
        {
            InitializeComponent();
        }

        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:5290")
        };

        private async void buttonPost_Click(object sender, EventArgs e)
        {
            string cargo = txtCargo.Text;
            int id_docente = int.Parse(comboBox1.SelectedItem.ToString());
            int id_curso = int.Parse(comboBox2.SelectedItem.ToString());

            if (String.IsNullOrEmpty(cargo))
            {
                MessageBox.Show("Por favor, ingrese un cargo", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                Docente docente = new Docente(id_docente, id_curso, cargo);
                var response = await _httpClient.PostAsJsonAsync("docentes", docente);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Docente cargado con éxito");
                    this.Close();


                }
                else
                {
                    MessageBox.Show("Error al cargar Docente");

                }
            }
        }

        private async void ModalAgregarDocente_Load(object sender, EventArgs e)
        {
            var personas = await _httpClient.GetFromJsonAsync<IEnumerable<Domain.model.Persona>>("personas");
            if (personas != null)
            {
                comboBox1.DataSource = personas.ToList();
                comboBox1.DisplayMember = "Apellido";
                comboBox1.ValueMember = "Id";
            }
            var cursos = await _httpClient.GetFromJsonAsync<IEnumerable<Curso>>("cursos");
            if (cursos != null)
            {
                comboBox2.DataSource = cursos.ToList();
                comboBox2.DisplayMember = "Desc";
                comboBox2.ValueMember = "Id";
            }

        }
    }
}
