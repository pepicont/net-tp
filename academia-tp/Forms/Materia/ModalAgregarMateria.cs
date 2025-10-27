using System.Net.Http.Json;
using Domain.model;
using DTOs;

namespace Forms
{
    public partial class ModalAgregarMateria : Form
    {
        public ModalAgregarMateria()
        {
            InitializeComponent();
        }

        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:5290")
        };


        private async void buttonPost_Click(object sender, EventArgs e)
        {
            int id_plan = (int)comboBox1.SelectedValue;
            string desc = RichTextBoxDescripcion.Text;
            string hs_semanales = txtBoxHsSemanales.Text;
            string hs_totales = txtBoxHsTotales.Text;

            if (String.IsNullOrEmpty(desc) || String.IsNullOrEmpty(hs_semanales) || String.IsNullOrEmpty(hs_totales))
            {
                MessageBox.Show("Por favor, ingrese una descripción horas semanales y horas totales", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Convert hs_semanales and hs_totales to integers
                if (int.TryParse(hs_semanales, out int hsSemanalesInt) && int.TryParse(hs_totales, out int hsTotalesInt))
                {
                    Materia materia = new()
                    {
                        Desc = desc,
                        Hs_semanales = hsSemanalesInt,
                        Hs_totales = hsTotalesInt,
                        Id_plan = id_plan
                    };

                    var response = await _httpClient.PostAsJsonAsync("materias", materia);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Materia cargada con éxito");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error al cargar la materia");
                    }
                }
                else
                {
                    MessageBox.Show("Horas semanales y totales deben ser números válidos", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void ModalAgregarMateria_Load(object sender, EventArgs e)
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
    }
}
