using Domain.model;
using static System.Net.WebRequestMethods;

public class EspecialidadHttpService
{
    private readonly HttpClient _httpClient;

    public EspecialidadHttpService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("http://localhost:5290");
    }

    public async Task<List<Especialidad>> GetAllAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Especialidad>>("especialidades")
               ?? new List<Especialidad>();
    }
    public async Task CreateAsync(Especialidad especialidad)
    {
        var response = await _httpClient.PostAsJsonAsync("especialidades", especialidad);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateAsync(Especialidad especialidad)
    {
        var response = await _httpClient.PutAsJsonAsync($"especialidades/{especialidad.Id}", especialidad);
        response.EnsureSuccessStatusCode();
    }

    public async Task<ApiResponse?> DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"especialidades/{id}");

        if (!response.IsSuccessStatusCode)
            return null;

        var content = await response.Content.ReadFromJsonAsync<ApiResponse>();
        return content;
    }

    public class ApiResponse
    {
        public string? Message { get; set; }
    }
}
