using Domain.services;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SkiaSharp;

namespace WebApi
{
    public static class ReporteEndpoints
    {
        public static void MapReporteEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/reportes");

            // Reporte 1: Alumnos por curso (PDF simple)
            group.MapGet("/alumnos-por-curso", (int idCurso, int anio) =>
            {
                try
                {
                    InscripcionServices inscripcionService = new InscripcionServices();
                    CursoServices cursoService = new CursoServices();

                    var alumnos = inscripcionService.GetAlumnosPorCurso(idCurso, anio);

                    if (alumnos == null || alumnos.Count == 0)
                        return Results.NotFound("No hay alumnos inscriptos.");

                    var curso = cursoService.GetOne(idCurso);
                    string nombreCurso = curso?.Nombre ?? "Desconocido";

                    Console.WriteLine($"Generando PDF para {alumnos.Count} alumnos..."); // ⬅️ DEBUG

                    // Generar PDF
                    byte[] pdfBytes = GenerarPDFAlumnos(alumnos, nombreCurso);

                    Console.WriteLine($"PDF generado: {pdfBytes.Length} bytes"); // ⬅️ DEBUG

                    // Guardar en carpeta Reportes
                    string filePath = GuardarReporte(pdfBytes, "ReporteAlumnosPorCurso.pdf");

                    Console.WriteLine($"PDF guardado en: {filePath}"); // ⬅️ DEBUG

                    // Devolver el PDF al cliente para descarga
                    return Results.File(pdfBytes, "application/pdf", "ReporteAlumnosPorCurso.pdf");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR DETALLADO: {ex}"); // ⬅️ Ver el stack trace completo
                    return Results.Problem($"Error al generar reporte: {ex.Message}\n\nStack trace: {ex.StackTrace}");
                }
            });

            // Reporte 2: Gráfico de alumnos por curso
            group.MapGet("/grafico-alumnos", (int materiaId, int anio) =>
            {
                try
                {
                    InscripcionServices inscripcionService = new InscripcionServices();

                    var datos = inscripcionService.GetCantidadAlumnosPorCurso(materiaId, anio).ToList();

                    if (datos == null || datos.Count == 0)
                        return Results.NotFound("No hay datos para mostrar.");

                    // Generar gráfico
                    byte[] grafico = GenerarGraficoBarras(datos);

                    // Generar PDF con gráfico
                    byte[] pdfBytes = GenerarPDFConGrafico(datos, grafico);

                    // Guardar en carpeta Reportes
                    string filePath = GuardarReporte(pdfBytes, "ReporteGraficoAlumnosPorCurso.pdf");

                    // Devolver el PDF al cliente
                    return Results.File(pdfBytes, "application/pdf", "ReporteGraficoAlumnosPorCurso.pdf");
                }
                catch (Exception ex)
                {
                    return Results.Problem($"Error al generar reporte: {ex.Message}");
                }
            });
        }

        private static byte[] GenerarPDFAlumnos(List<AlumnoReporteDto> alumnos, string nombreCurso)
        {
            var reporte = new AlumnosPorCursoReport(alumnos, nombreCurso);
            using var stream = new MemoryStream();
            reporte.GeneratePdf(stream);
            return stream.ToArray();
        }

        private static byte[] GenerarPDFConGrafico(List<CursoCantidadDto> datos, byte[] grafico)
        {
            var reporte = new AlumnosPorCursoGraficoReport(datos, grafico);
            using var stream = new MemoryStream();
            reporte.GeneratePdf(stream);
            return stream.ToArray();
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

                canvas.DrawRect(x, height - margenAbajo - barHeight, barWidth, barHeight, barPaint);

                float textWidth = textPaint.MeasureText(datos[i].NombreCurso);
                float textX = x + (barWidth / 2) - (textWidth / 2);
                float textY = height - margenAbajo + 15;
                canvas.DrawText(datos[i].NombreCurso, textX, textY, textPaint);

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

        private static string GuardarReporte(byte[] pdfBytes, string nombreArchivo)
        {
            try
            {
                string projectRoot = AppDomain.CurrentDomain.BaseDirectory;
                Console.WriteLine($"Base directory: {projectRoot}"); // ⬅️ DEBUG

                // Buscar la carpeta Reportes
                while (!Directory.Exists(Path.Combine(projectRoot, "Reportes")) &&
                       Directory.GetParent(projectRoot) != null)
                {
                    projectRoot = Directory.GetParent(projectRoot).FullName;
                }

                string reportFolder = Path.Combine(projectRoot, "Reportes");
                Console.WriteLine($"Report folder: {reportFolder}"); // ⬅️ DEBUG

                if (!Directory.Exists(reportFolder))
                {
                    Console.WriteLine("Creando carpeta Reportes..."); // ⬅️ DEBUG
                    Directory.CreateDirectory(reportFolder);
                }

                string filePath = Path.Combine(reportFolder, nombreArchivo);
                Console.WriteLine($"Guardando en: {filePath}"); // ⬅️ DEBUG

                File.WriteAllBytes(filePath, pdfBytes);
                Console.WriteLine("Archivo guardado exitosamente"); // ⬅️ DEBUG

                return filePath;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR al guardar archivo: {ex}"); // ⬅️ DEBUG
                throw;
            }
        }
    }

    // Clases para generar PDFs (copia de Forms)
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

                    if (alumnos.Any())
                    {
                        var primer = alumnos.First();
                        col.Item().Text($"Materia: {primer.DescMateria}").FontSize(12);
                        col.Item().PaddingVertical(3);
                        col.Item().Text($"Curso: {nombreCurso}").FontSize(12);
                        col.Item().PaddingVertical(3);
                        col.Item().Text($"Año: {primer.AnioCalendario}").FontSize(12);
                        col.Item().PaddingVertical(10);
                    }

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

                        table.Header(header =>
                        {
                            header.Cell().Element(CellStyle).Text("Legajo").Bold();
                            header.Cell().Element(CellStyle).Text("Nombre").Bold();
                            header.Cell().Element(CellStyle).Text("Apellido").Bold();
                            header.Cell().Element(CellStyle).Text("Condición").Bold();
                            header.Cell().Element(CellStyle).Text("Nota").Bold();
                            header.Cell().Element(CellStyle).Text("Fecha Insc.").Bold();
                        });

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

                    col.Item().PaddingVertical(15);
                    col.Item().Text($"Total de alumnos: {alumnos.Count}").FontSize(12).Bold();
                });
            });
        }

        private QuestPDF.Infrastructure.IContainer CellStyle(QuestPDF.Infrastructure.IContainer container)
        {
            return container.Padding(5).BorderBottom(1).BorderColor(Colors.Grey.Lighten2);
        }
    }

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

                    col.Item().Image(grafico);
                    col.Item().PaddingVertical(10);

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

        private QuestPDF.Infrastructure.IContainer CellStyle(QuestPDF.Infrastructure.IContainer container)
        {
            return container.Padding(5).BorderBottom(1).BorderColor(Colors.Grey.Lighten2);
        }
    }
}