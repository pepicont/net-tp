using System.Net.Http.Json;

    public class ReporteHttpService
    {
        private readonly HttpClient _httpClient;

        public ReporteHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5290");
        }

        // Generar reporte de alumnos por curso
        public async Task<byte[]?> GenerarReporteAlumnosPorCursoAsync(int idCurso, int anio)
        {
            try
            {
                var response = await _httpClient.GetAsync(
                    $"reportes/alumnos-por-curso?idCurso={idCurso}&anio={anio}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsByteArrayAsync();
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al generar reporte: {ex.Message}");
                return null;
            }
        }

        // Generar reporte gráfico de alumnos por materia
        public async Task<byte[]?> GenerarReporteGraficoAsync(int materiaId, int anio)
        {
            try
            {
                var response = await _httpClient.GetAsync(
                    $"reportes/grafico-alumnos?materiaId={materiaId}&anio={anio}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsByteArrayAsync();
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al generar reporte gráfico: {ex.Message}");
                return null;
            }
        }
    }

