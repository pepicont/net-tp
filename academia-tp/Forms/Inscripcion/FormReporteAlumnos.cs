using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTOs;
using Domain.model;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestPDF.Helpers;

namespace Forms.Inscripcion
{
    public partial class FormReporteAlumnos : Form
    {
        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:5290")
        };

        public FormReporteAlumnos()
        {
            InitializeComponent();
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
                await CargarCursosPorMateria(materiaId);
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

        private async void btnCrearReporte_Click(object sender, EventArgs e)
        {
            if (!ValidarSelecciones()) return;

            try
            {
                int idCurso = (int)comboBoxCurso.SelectedValue;
                int anio = (int)numericUpDownAño.Value;

                var alumnos = await _httpClient.GetFromJsonAsync<List<AlumnoReporteDto>>(
                    $"inscripciones/alumnos-por-curso?idCurso={idCurso}&anio={anio}");

                if (alumnos == null || alumnos.Count == 0)
                {
                    MessageBox.Show("No hay alumnos inscriptos para los filtros seleccionados.");
                    return;
                }

                GenerarReportePDF(alumnos);
                MessageBox.Show("Reporte generado correctamente en 'ReporteAlumnosPorCurso.pdf'");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}");
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


        private void GenerarReportePDF(List<AlumnoReporteDto> alumnos)
        {
            string nombreCurso = comboBoxCurso.SelectedItem is Curso curso ? curso.Nombre : comboBoxCurso.Text;
            string projectRoot = AppDomain.CurrentDomain.BaseDirectory;
            while (!System.IO.Directory.Exists(System.IO.Path.Combine(projectRoot, "Reportes")) &&
                   System.IO.Directory.GetParent(projectRoot) != null)
            {
                projectRoot = System.IO.Directory.GetParent(projectRoot).FullName;
        }
            string reportFolder = System.IO.Path.Combine(projectRoot, "Reportes");
            if (!System.IO.Directory.Exists(reportFolder))
                System.IO.Directory.CreateDirectory(reportFolder);

            string filePath = System.IO.Path.Combine(reportFolder, "ReporteAlumnosPorCurso.pdf");
            // Instancia el reporte y genera el PDF
            var reporte = new AlumnosPorCursoReport(alumnos, nombreCurso);
            reporte.GeneratePdf(filePath);
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

        private async void buttonCrearReporte_Click(object sender, EventArgs e)
        {
            if (!ValidarSelecciones()) return;

            try
            {
                int idCurso = (int)comboBoxCurso.SelectedValue;
                int anio = (int)numericUpDownAño.Value;

                var alumnos = await _httpClient.GetFromJsonAsync<List<AlumnoReporteDto>>(
                    $"inscripciones/alumnos-por-curso?idCurso={idCurso}&anio={anio}");

                if (alumnos == null || alumnos.Count == 0)
                {
                    MessageBox.Show("No hay alumnos inscriptos para los filtros seleccionados.");
                    return;
                }

                GenerarReportePDF(alumnos);
                MessageBox.Show("Reporte generado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}");
            }
        }
    }
}

// Modifica la clase AlumnosPorCursoReport para recibir el nombre del curso y mostrarlo en el PDF

    public class AlumnosPorCursoReport : IDocument
    {
        private readonly List<AlumnoReporteDto> alumnos;
    private readonly string nombreCurso;

    public AlumnosPorCursoReport(List<AlumnoReporteDto> alumnos, string nombreCurso)
        {
            this.alumnos = alumnos;
        this.nombreCurso = nombreCurso;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Margin(30);
                page.Size(PageSizes.A4);
                page.Content().Column(col =>
                {
                col.Item().Text("Listado de Alumnos por Curso").FontSize(18).Bold().AlignCenter();
                col.Item().PaddingVertical(10);

                    // Información del curso
                    if (alumnos.Any())
                    {
                        var primer = alumnos.First();
                    col.Item().Text($"Materia: {primer.DescMateria}").FontSize(12);
                        col.Item().PaddingVertical(3);
                    col.Item().Text($"Curso: {nombreCurso}").FontSize(12); // <-- Aquí aparece el nombre
                        col.Item().PaddingVertical(3);
                    col.Item().Text($"Año: {primer.AnioCalendario}").FontSize(12);
                        col.Item().PaddingVertical(10);
                    }

                    // Tabla de alumnos
                    col.Item().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                        columns.ConstantColumn(60);
                        columns.RelativeColumn(2);
                        columns.RelativeColumn(2);
                        columns.ConstantColumn(80);
                        columns.ConstantColumn(60);
                        columns.ConstantColumn(80);
                        });

                        // Encabezado
                        table.Header(header =>
                        {
                            header.Cell().Element(CellStyle).Text("Legajo").Bold();
                            header.Cell().Element(CellStyle).Text("Nombre").Bold();
                            header.Cell().Element(CellStyle).Text("Apellido").Bold();
                            header.Cell().Element(CellStyle).Text("Condición").Bold();
                            header.Cell().Element(CellStyle).Text("Nota").Bold();
                            header.Cell().Element(CellStyle).Text("Fecha Insc.").Bold();
                        });

                        // Filas de datos
                        foreach (var alumno in alumnos.OrderBy(a => a.Apellido).ThenBy(a => a.Nombre))
                        {
                            table.Cell().Element(CellStyle).Text(alumno.Legajo.ToString());
                            table.Cell().Element(CellStyle).Text(alumno.Nombre ?? "");
                            table.Cell().Element(CellStyle).Text(alumno.Apellido ?? "");
                            table.Cell().Element(CellStyle).Text(alumno.Condicion ?? "");
                            table.Cell().Element(CellStyle).Text(alumno.Nota?.ToString() ?? "-");
                            table.Cell().Element(CellStyle).Text(alumno.Fecha_inscripcion.ToString("dd/MM/yyyy"));
                        }
                    });

                    // Totales
                    col.Item().PaddingVertical(15);
                    col.Item().Text($"Total de alumnos: {alumnos.Count}")
                        .FontSize(12).Bold();
                });
            });
        }

        // Método auxiliar para estilo de celdas
        private IContainer CellStyle(IContainer container)
        {
            return container
                .Padding(5)
                .BorderBottom(1)
                .BorderColor(Colors.Grey.Lighten2);
        }
    }
}