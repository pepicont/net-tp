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
    public partial class ModalModificarDocente : Form
    {
        public ModalModificarDocente(int id, Docente docente)
        {
            InitializeComponent();
            _docente = docente;
            TextBoxId.Text = id.ToString();
            txtCargo.Text = _docente.Cargo;
            comboBox1.SelectedItem = _docente.Id_docente.ToString();
            comboBox2.SelectedItem = _docente.Id_curso.ToString();
        }
        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:5290")
        };
        private readonly Docente _docente;



        private bool ValidarCampos()
        {
            bool cargo = string.IsNullOrWhiteSpace(txtCargo.Text);

            if (cargo)
            {
                MessageBox.Show("El campo Cargo es obligatorio.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCargo.Focus();
                return false;
            }

            return true;
        }


        private async void buttonPut_Click_1(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                try
                {

                    string cargo = txtCargo.Text;
                    int id_docente = int.Parse(comboBox1.SelectedItem.ToString());
                    int id_curso = int.Parse(comboBox2.SelectedItem.ToString());
                    Docente docente = new Docente(id_docente, id_curso, cargo);
                    int id = _docente.Id;
                    var response = await _httpClient.PutAsJsonAsync($"docentees/{id}", docente);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Docente modificado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK; // Solo aquí
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show($"Error al modificar docente. Código de estado: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void ModalModificarDocente_Load(object sender, EventArgs e)
        {
            txtCargo.Text = _docente.Cargo;
            
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

            comboBox1.SelectedItem = _docente.Id_docente.ToString();
            comboBox2.SelectedItem = _docente.Id_curso.ToString();
        }
    }
}
