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

        private async void comboBoxMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMateria.SelectedValue is int materiaId)
            {
                await CargarCursosPorMateria(materiaId);
                comboBoxCurso.Enabled = true;
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
                    var cursosDisplay = cursos.Select(c => new
                    {
                        Id = c.Id,
                        Display = $"Año {c.Anio_calendario} - Cupo: {c.Cupo}"
                    }).ToList();

                    comboBoxCurso.DataSource = cursosDisplay;
                    comboBoxCurso.DisplayMember = "Display";
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
            var reporte = new AlumnosPorCursoReport(alumnos);
            reporte.GeneratePdf("ReporteAlumnosPorCurso.pdf");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    // Clase para generar el PDF con QuestPDF
    public class AlumnosPorCursoReport : IDocument
    {
        private readonly List<AlumnoReporteDto> alumnos;

        public AlumnosPorCursoReport(List<AlumnoReporteDto> alumnos)
        {
            this.alumnos = alumnos;
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
                    // Título - SIN Unit.Point, solo el valor numérico
                    col.Item().Text("Listado de Alumnos por Curso")
                        .FontSize(18).Bold().AlignCenter();

                    col.Item().PaddingVertical(10); // Espacio después del título

                    // Información del curso
                    if (alumnos.Any())
                    {
                        var primer = alumnos.First();

                        col.Item().Text($"Materia: {primer.DescMateria}")
                            .FontSize(12);
                        col.Item().PaddingVertical(3);

                        col.Item().PaddingVertical(3);

                        col.Item().Text($"Año: {primer.AnioCalendario}")
                            .FontSize(12);
                        col.Item().PaddingVertical(10);
                    }

                    // Tabla de alumnos
                    col.Item().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.ConstantColumn(60);  // Legajo
                            columns.RelativeColumn(2);   // Nombre
                            columns.RelativeColumn(2);   // Apellido
                            columns.ConstantColumn(80);  // Condición
                            columns.ConstantColumn(60);  // Nota
                            columns.ConstantColumn(80);  // Fecha Inscripción
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