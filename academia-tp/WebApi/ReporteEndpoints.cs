using Domain.services;
using Microsoft.AspNetCore.Mvc;

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
                    ReporteServices reporteService = new ReporteServices();

                    byte[] pdfBytes = reporteService.GenerarReporteAlumnosPorCurso(idCurso, anio);

                    // Guardar en carpeta Reportes
                    string filePath = reporteService.GuardarReporte(pdfBytes, "ReporteAlumnosPorCurso.pdf");

                    // Devolver el PDF al cliente para descarga
                    return Results.File(pdfBytes, "application/pdf", "ReporteAlumnosPorCurso.pdf");
                }
                catch (InvalidOperationException ex)
                {
                    return Results.NotFound(ex.Message);
                }
                catch (Exception ex)
                {
                    return Results.Problem($"Error al generar reporte: {ex.Message}");
                }
            });

            // Reporte 2: Gráfico de alumnos por curso
            group.MapGet("/grafico-alumnos", (int materiaId, int anio) =>
            {
                try
                {
                    ReporteServices reporteService = new ReporteServices();

                    byte[] pdfBytes = reporteService.GenerarReporteGraficoAlumnos(materiaId, anio);

                    // Guardar en carpeta Reportes
                    string filePath = reporteService.GuardarReporte(pdfBytes, "ReporteGraficoAlumnosPorCurso.pdf");

                    // Devolver el PDF al cliente
                    return Results.File(pdfBytes, "application/pdf", "ReporteGraficoAlumnosPorCurso.pdf");
                }
                catch (InvalidOperationException ex)
                {
                    return Results.NotFound(ex.Message);
                }
                catch (Exception ex)
                {
                    return Results.Problem($"Error al generar reporte: {ex.Message}");
                }
            });
        }
    }
}