using System.Net.Http.Headers;
using System.Net.Http.Json;
using Domain.model;



namespace API.Controllers
{
        public class PlanApiClient
        {
            private static HttpClient client = new HttpClient();
            static PlanApiClient()
            {
                client.BaseAddress = new Uri("http://localhost:5290/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            }

            public static async Task<IEnumerable<Plan>> GetAllAsync()
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync("paises");

                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadFromJsonAsync<IEnumerable<Plan>>();
                    }
                    else
                    {
                        string errorContent = await response.Content.ReadAsStringAsync();
                        throw new Exception($"Error al obtener lista de planes. Status: {response.StatusCode}, Detalle: {errorContent}");
                    }
                }
                catch (HttpRequestException ex)
                {
                    throw new Exception($"Error de conexión al obtener lista de planes: {ex.Message}", ex);
                }
                catch (TaskCanceledException ex)
                {
                    throw new Exception($"Timeout al obtener lista de planes: {ex.Message}", ex);
                }
            }
        }
}


