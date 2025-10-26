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
using SkiaSharp;
using QuestPDF.Helpers;

namespace Forms.Inscripcion
{
    public partial class FormReporteGrafico : Form
    {
        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:5290")
        };

        public FormReporteGrafico()
        {
            InitializeComponent();
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

        private async void btnGenerarGrafico_Click(object sender, EventArgs e)
        {
            if (!ValidarSelecciones()) return;

            try
            {
                var datos = await ObtenerDatosGrafico();
                if (datos == null || datos.Count == 0)
                {
                    MessageBox.Show("No hay datos para mostrar.");
                    return;
                }

                byte[] grafico = GenerarGraficoBarras(datos);
                GenerarReportePDF(datos, grafico);
                MessageBox.Show("Reporte con gráfico generado correctamente!");
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
            if (numericUpDownAño.Value <= 0)
            {
                MessageBox.Show("Ingrese un año válido.");
                return false;
            }
            return true;
        }

        private async Task<List<CursoCantidadDto>> ObtenerDatosGrafico()
        {
            int materiaId = Convert.ToInt32(comboBoxMateria.SelectedValue);
            int anio = Convert.ToInt32(numericUpDownAño.Value);

            return await _httpClient.GetFromJsonAsync<List<CursoCantidadDto>>(
                $"inscripciones/cantidad-por-curso?materiaId={materiaId}&anio={anio}");
        }

        private void GenerarReportePDF(List<CursoCantidadDto> datos, byte[] grafico)
        {
            string projectRoot = AppDomain.CurrentDomain.BaseDirectory;
            while (!System.IO.Directory.Exists(System.IO.Path.Combine(projectRoot, "Reportes")) &&
                   System.IO.Directory.GetParent(projectRoot) != null)
            {
                projectRoot = System.IO.Directory.GetParent(projectRoot).FullName;
            }
            string reportFolder = System.IO.Path.Combine(projectRoot, "Reportes");
            if (!System.IO.Directory.Exists(reportFolder))
                System.IO.Directory.CreateDirectory(reportFolder);

            string filePath = System.IO.Path.Combine(reportFolder, "ReporteGraficoAlumnosPorCurso.pdf");
            var reporte = new AlumnosPorCursoGraficoReport(datos, grafico);
            reporte.GeneratePdf(filePath);
        }

        private static byte[] GenerarGraficoBarras(List<CursoCantidadDto> datos)
        {
            int width = 600;
            int height = 400;
            using var bitmap = new SKBitmap(width, height);
            using var canvas = new SKCanvas(bitmap);
            canvas.Clear(SKColors.White);

            int margenIzq = 80;
            int margenAbajo = 60;
            int barWidth = 60;
            int espacio = 20;
            int maxY = datos.Max(d => d.CantidadAlumnos);
            if (maxY == 0) maxY = 1;

            // Ejes
            using var ejePaint = new SKPaint { Color = SKColors.Black, StrokeWidth = 2 };
            canvas.DrawLine(margenIzq, 30, margenIzq, height - margenAbajo, ejePaint);
            canvas.DrawLine(margenIzq, height - margenAbajo, width - 30, height - margenAbajo, ejePaint);

            // Etiquetas
            using var ejeXTextPaint = new SKPaint { Color = SKColors.Black, TextSize = 14, IsAntialias = true };
            canvas.DrawText("Cursos", width / 2 - 30, height - 20, ejeXTextPaint);
            using var ejeYTextPaint = new SKPaint { Color = SKColors.Black, TextSize = 14, IsAntialias = true };
            canvas.Save();
            canvas.RotateDegrees(-90, margenIzq / 2, height / 2);
            canvas.DrawText("Alumnos", margenIzq / 2, height / 2, ejeYTextPaint);
            canvas.Restore();

            using var barPaint = new SKPaint { Color = SKColors.SkyBlue };
            using var textPaint = new SKPaint { Color = SKColors.Black, TextSize = 12, IsAntialias = true };

            for (int i = 0; i < datos.Count; i++)
            {
                int x = margenIzq + 20 + i * (barWidth + espacio);
                int barHeight = (int)((height - margenAbajo - 50) * datos[i].CantidadAlumnos / (float)maxY);

                // Barra
                canvas.DrawRect(x, height - margenAbajo - barHeight, barWidth, barHeight, barPaint);

                // Nombre del curso debajo de la barra
                float textWidth = textPaint.MeasureText(datos[i].NombreCurso);
                float textX = x + (barWidth / 2) - (textWidth / 2);
                float textY = height - margenAbajo + 15;
                canvas.DrawText(datos[i].NombreCurso, textX, textY, textPaint);

                // Cantidad arriba de la barra
                string cantidad = datos[i].CantidadAlumnos.ToString();
                float cantidadWidth = textPaint.MeasureText(cantidad);
                float cantidadX = x + (barWidth / 2) - (cantidadWidth / 2);
                float cantidadY = height - margenAbajo - barHeight - 5;
                canvas.DrawText(cantidad, cantidadX, cantidadY, textPaint);
            }

            using var image = SKImage.FromBitmap(bitmap);
            using var data = image.Encode(SKEncodedImageFormat.Png, 100);
            return data.ToArray();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    // Clase para generar el PDF con gráfico
    public class AlumnosPorCursoGraficoReport : IDocument
    {
        private readonly List<CursoCantidadDto> datos;
        private readonly byte[] grafico;

        public AlumnosPorCursoGraficoReport(List<CursoCantidadDto> datos, byte[] grafico)
        {
            this.datos = datos;
            this.grafico = grafico;
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
                    col.Item().Text("Cantidad de Alumnos por Curso")
                        .FontSize(18).Bold().AlignCenter();
                    col.Item().PaddingVertical(10);

                    // Gráfico
                    col.Item().Image(grafico);
                    col.Item().PaddingVertical(10);

                    // Tabla resumen
                    col.Item().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });

                        table.Header(header =>
                        {
                            header.Cell().Element(CellStyle).Text("Curso").Bold();
                            header.Cell().Element(CellStyle).Text("Cantidad de Alumnos").Bold();
                            header.Cell().Element(CellStyle).Text("% Cupo Ocupado").Bold();
                        });

                        foreach (var d in datos)
                        {
                            table.Cell().Element(CellStyle).Text(d.NombreCurso);
                            table.Cell().Element(CellStyle).Text(d.CantidadAlumnos.ToString());
                            string porcentaje = d.Cupo > 0 ? $"{(d.CantidadAlumnos * 100 / d.Cupo)}%" : "-";
                            table.Cell().Element(CellStyle).Text(porcentaje);
                        }
                    });

                    col.Item().PaddingVertical(10);
                    col.Item().Text($"Total de alumnos: {datos.Sum(d => d.CantidadAlumnos)}")
                        .FontSize(12).Bold();
                });
            });
        }

        private IContainer CellStyle(IContainer container)
        {
            return container.Padding(5).BorderBottom(1).BorderColor(Colors.Grey.Lighten2);
        }
    }
}