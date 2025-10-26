using System;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms.Inscripcion
{
    public partial class formModificarInscripcion : Form
    {
        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:5290")
        };

        private int IdInscripcion { get; set; }
        private Domain.model.Inscripcion InscripcionActual { get; set; }

        public formModificarInscripcion(int idInscripcion)
        {
            InitializeComponent();
            IdInscripcion = idInscripcion;
            this.Load += formModificarInscripcion_Load;
            btnCancelar.Click += btnCancelar_Click;
        }

        private async void formModificarInscripcion_Load(object sender, EventArgs e)
        {
            comboBoxCondicion.Items.Clear();
            comboBoxCondicion.Items.AddRange(new[] { "Aprobado", "Regular", "Inscripto", "Libre" });

            InscripcionActual = await _httpClient.GetFromJsonAsync<Domain.model.Inscripcion>($"inscripciones/{IdInscripcion}");
            if (InscripcionActual != null)
            {
                comboBoxCondicion.SelectedItem = InscripcionActual.Condicion ?? "Inscripto";
                if (InscripcionActual.Nota.HasValue)
                {
                    numericUpDownNota.Value = (decimal)InscripcionActual.Nota.Value;
                }
                else
                {
                    numericUpDownNota.Value = numericUpDownNota.Minimum; // o deja el valor por defecto
                }
            }
            else
            {
                MessageBox.Show("No se pudo cargar la inscripción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (InscripcionActual == null)
                return;

            var nuevaCondicion = comboBoxCondicion.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(nuevaCondicion))
            {
                MessageBox.Show("Debe seleccionar una condición.");
                return;
            }

            // Si el valor es el mínimo, lo consideramos nulo (sin nota)
            float? nuevaNota = null;
            if (numericUpDownNota.Value != numericUpDownNota.Minimum)
            {
                nuevaNota = (float)numericUpDownNota.Value;
            }

            InscripcionActual.Condicion = nuevaCondicion;
            InscripcionActual.Nota = nuevaNota;

            var response = await _httpClient.PutAsJsonAsync($"inscripciones/{IdInscripcion}", InscripcionActual);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Inscripción modificada correctamente.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"Error al modificar la inscripción: {errorContent}");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}