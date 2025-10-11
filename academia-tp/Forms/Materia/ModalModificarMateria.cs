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
    public partial class ModalModificarMateria : Form
    {
        public ModalModificarMateria(Materia materia)
        {
            InitializeComponent();
            _materia = materia;
            TextBoxId.Text = _materia.Id.ToString();
            richTextBoxDescripcion.Text = _materia.Desc;
            txtBoxHsSemanales.Text = _materia.Hs_semanales.ToString();
            txtBoxHsTotales.Text = _materia.Hs_totales.ToString();
        }
        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:5290")
        };
        private readonly Materia _materia;



        private bool ValidarCampos()
        {
            bool descripcionVacia = string.IsNullOrWhiteSpace(richTextBoxDescripcion.Text);

            if (descripcionVacia)  
            {
                MessageBox.Show("El campo Descripción es obligatorio.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                richTextBoxDescripcion.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtBoxHsSemanales.Text) || string.IsNullOrWhiteSpace(txtBoxHsTotales.Text))
            {
                MessageBox.Show("Por favor, ingrese horas semanales y horas totales.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBoxHsSemanales.Focus();
                return false;
            }

            if (!int.TryParse(txtBoxHsSemanales.Text, out int hs_semanales))
            {
                MessageBox.Show("Las horas semanales deben ser un número entero.", "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBoxHsSemanales.Focus();
                return false;
            }

            if (!int.TryParse(txtBoxHsTotales.Text, out int hs_totales))
            {
                MessageBox.Show("Las horas totales deben ser un número entero.", "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBoxHsTotales.Focus();
                return false;
            }

            return true;
        }
        private async void ModalModificarMateria_Load(object sender, EventArgs e)
        {
            try
            {
                var planes = await _httpClient.GetFromJsonAsync<IEnumerable<Plan>>("planes");
                if (planes != null)
                {
                    comboBox1.DataSource = planes.ToList();
                    comboBox1.DisplayMember = "Desc";
                    comboBox1.ValueMember = "Id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar las planes: {ex.Message}");
            }
        }

        private async void buttonPut_Click_1(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                try
                {
                    int id = int.Parse(TextBoxId.Text);
                    string desc = richTextBoxDescripcion.Text;
                    int hs_semanales = int.Parse(txtBoxHsSemanales.Text);
                    int hs_totales = int.Parse(txtBoxHsTotales.Text);
                    int id_plan = (int)comboBox1.SelectedValue;
                    Materia materia = new Materia(id,  desc, hs_semanales, hs_totales, id_plan);
                    var response = await _httpClient.PutAsJsonAsync($"materias/{id}", materia);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Materia modificada con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK; // Solo aquí
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show($"Error al modificar la materia. Código de estado: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
