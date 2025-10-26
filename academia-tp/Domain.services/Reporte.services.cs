using DTOs;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SkiaSharp;
using System.ComponentModel;
using static System.Net.Mime.MediaTypeNames;

namespace Domain.services
{
    public class ReporteServices
    {
        private readonly InscripcionServices _inscripcionServices;
        private readonly CursoServices _cursoServices;

        public ReporteServices()
        {
            _inscripcionServices = new InscripcionServices();
            _cursoServices = new CursoServices();
        }

        public byte[] GenerarReporteAlumnosPorCurso(int idCurso, int anio)
        {
            var alumnos = _inscripcionServices.GetAlumnosPorCurso(idCurso, anio);

            if (alumnos == null || alumnos.Count == 0)
                throw new InvalidOperationException("No hay alumnos inscriptos.");

            var curso = _cursoServices.GetOne(idCurso);
            string nombreCurso = curso?.Nombre ?? "Desconocido";

            return GenerarPDFAlumnos(alumnos, nombreCurso);
        }

        public byte[] GenerarReporteGraficoAlumnos(int materiaId, int anio)
        {
            var datos = _inscripcionServices.GetCantidadAlumnosPorCurso(materiaId, anio).ToList();

            if (datos == null || datos.Count == 0)
                throw new InvalidOperationException("No hay datos para mostrar.");

            byte[] grafico = GenerarGraficoBarras(datos);
            return GenerarPDFConGrafico(datos, grafico);
        }

        public string GuardarReporte(byte[] pdfBytes, string nombreArchivo)
        {
            string projectRoot = AppDomain.CurrentDomain.BaseDirectory;

            while (!Directory.Exists(Path.Combine(projectRoot, "Reportes")) &&
                   Directory.GetParent(projectRoot) != null)
            {
                projectRoot = Directory.GetParent(projectRoot).FullName;
            }

            string reportFolder = Path.Combine(projectRoot, "Reportes");

            if (!Directory.Exists(reportFolder))
            {
                Directory.CreateDirectory(reportFolder);
            }

            string filePath = Path.Combine(reportFolder, nombreArchivo);
            File.WriteAllBytes(filePath, pdfBytes);

            return filePath;
        }

        private byte[] GenerarPDFAlumnos(List<AlumnoReporteDto> alumnos, string nombreCurso)
        {
            var reporte = new AlumnosPorCursoReport(alumnos, nombreCurso);
            using var stream = new MemoryStream();
            reporte.GeneratePdf(stream);
            return stream.ToArray();
        }

        private byte[] GenerarPDFConGrafico(List<CursoCantidadDto> datos, byte[] grafico)
        {
            var reporte = new AlumnosPorCursoGraficoReport(datos, grafico);
            using var stream = new MemoryStream();
            reporte.GeneratePdf(stream);
            return stream.ToArray();
        }

        private byte[] GenerarGraficoBarras(List<CursoCantidadDto> datos)
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

            using var ejePaint = new SKPaint { Color = SKColors.Black, StrokeWidth = 2 };
            canvas.DrawLine(margenIzq, 30, margenIzq, height - margenAbajo, ejePaint);
            canvas.DrawLine(margenIzq, height - margenAbajo, width - 30, height - margenAbajo, ejePaint);

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
    }

    // Clases para generar PDFs
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