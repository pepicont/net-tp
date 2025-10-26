using Domain.model;
using DTOs;

public class InscripcionHttpService
{
    private readonly HttpClient _httpClient;

    public InscripcionHttpService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("http://localhost:5290");
    }

    public async Task<List<InscripcionDTO>> GetAllAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<InscripcionDTO>>("inscripciones/search")
               ?? new List<InscripcionDTO>();
    }
    public async Task CreateAsync(Inscripcion inscripcion)
    {
        var response = await _httpClient.PostAsJsonAsync("inscripciones", inscripcion);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateAsync(Especialidad especialidad)
    {
        /*var response = await _httpClient.PutAsJsonAsync($"especialidades/{especialidad.Id}", especialidad);
        response.EnsureSuccessStatusCode();*/
    }

    public async Task DeleteAsync(int id)
    {
        /*var response = await _httpClient.DeleteAsync($"especialidades/{id}");
        response.EnsureSuccessStatusCode();*/
    }
}
