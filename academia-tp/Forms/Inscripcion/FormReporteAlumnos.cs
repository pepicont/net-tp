using Domain.model;
using Domain.services;
using DTOs;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms.Inscripcion
{
    public partial class FormReporteAlumnos : Form
    {
        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:5290")
        };
        private readonly ReporteServices _reporteService;
        public FormReporteAlumnos()
        {
            InitializeComponent();
            _reporteService = new ReporteServices();
        }

        private async void FormReporteAlumnos_Load(object sender, EventArgs e)
        {
            comboBoxCurso.Enabled = false;
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

        private async void comboBoxMateria_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBoxMateria.SelectedValue is int materiaId)
            {
                comboBoxCurso.Enabled = true;
                await CargarCursosPorMateria(materiaId);
            }
            else
            {
                comboBoxCurso.DataSource = null;
                comboBoxCurso.Enabled = false;
            }
        }

        private async Task CargarCursosPorMateria(int materiaId)
        {
            try
            {
                var cursos = await _httpClient.GetFromJsonAsync<IEnumerable<Curso>>($"cursos/materia/{materiaId}");

                if (cursos?.Any() == true)
                {
                    comboBoxCurso.DataSource = cursos.ToList();
                    comboBoxCurso.DisplayMember = "Nombre"; 
                    comboBoxCurso.ValueMember = "Id";
                    comboBoxCurso.SelectedIndex = -1;
                }
                else
                {
                    comboBoxCurso.DataSource = null;
                    MessageBox.Show("No hay cursos disponibles para esta materia.");
                }
            }
            catch (Exception ex)
            {
                comboBoxCurso.DataSource = null;
                MessageBox.Show($"Error al cargar cursos: {ex.Message}");
            }
        }

        private bool ValidarSelecciones()
        {
            if (comboBoxMateria.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una materia.");
                return false;
            }
            if (comboBoxCurso.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un curso.");
                return false;
            }
            if (numericUpDownAño.Value <= 0)
            {
                MessageBox.Show("Ingrese un año válido.");
                return false;
            }
            return true;
        }
        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void comboBoxMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMateria.SelectedValue is int materiaId)
            {
                comboBoxCurso.Enabled = true;
                await CargarCursosPorMateria(materiaId);
            }
            else
            {
                comboBoxCurso.DataSource = null;
                comboBoxCurso.Enabled = false;
            }
    }

        private void buttonCrearReporte_Click(object sender, EventArgs e)
        {
            if (!ValidarSelecciones()) return;

            try
            {
                int idCurso = (int)comboBoxCurso.SelectedValue;
                int anio = (int)numericUpDownAño.Value;


                byte[] pdfBytes = _reporteService.GenerarReporteAlumnosPorCurso(idCurso, anio);


                string filePath = _reporteService.GuardarReporte(pdfBytes, "ReporteAlumnosPorCurso.pdf");

                MessageBox.Show($"Reporte generado correctamente en:\n{filePath}",
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


    }
}