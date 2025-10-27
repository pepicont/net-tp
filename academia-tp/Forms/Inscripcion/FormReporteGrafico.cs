using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain.model;
using Domain.services;

namespace Forms.Inscripcion
{
    public partial class FormReporteGrafico : Form
    {
        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:5290")
        };
        private readonly ReporteServices _reporteService;

        public FormReporteGrafico()
        {
            InitializeComponent();
            _reporteService = new ReporteServices();
        }

        private async void FormReporteGrafico_Load(object sender, EventArgs e)
        {
            await CargarMaterias();
        }

        private async Task CargarMaterias()
        {
            try
            {
                var materias = await _httpClient.GetFromJsonAsync<IEnumerable<Materia>>("materias");
                comboBoxMateria.DataSource = materias?.ToList();
                comboBoxMateria.DisplayMember = "Desc";
                comboBoxMateria.ValueMember = "Id";
                comboBoxMateria.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar materias: {ex.Message}");
            }
        }

        private void btnGenerarGrafico_Click(object sender, EventArgs e)
        {
            if (!ValidarSelecciones()) return;

            try
            {
                int materiaId = Convert.ToInt32(comboBoxMateria.SelectedValue);
                int anio = Convert.ToInt32(numericUpDownAño.Value);

                
                byte[] pdfBytes = _reporteService.GenerarReporteGraficoAlumnos(materiaId, anio);

               
                string filePath = _reporteService.GuardarReporte(pdfBytes, "ReporteGraficoAlumnosPorCurso.pdf");

                MessageBox.Show($"Reporte gráfico generado correctamente en:\n{filePath}",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarSelecciones()
        {
            if (comboBoxMateria.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una materia.");
                return false;
            }
            if (numericUpDownAño.Value <= 0)
            {
                MessageBox.Show("Ingrese un año válido.");
                return false;
            }
            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}