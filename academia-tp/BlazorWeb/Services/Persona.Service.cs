using Domain.model;

public class PersonaHttpService
{
    private readonly HttpClient _httpClient;

    public PersonaHttpService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("http://localhost:5290");
    }

    public async Task<List<Persona>> GetAllAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Persona>>("personas")
               ?? new List<Persona>();
    }

    public async Task DeleteAsync(int legajo)
    {
        await _httpClient.DeleteAsync($"personas/{legajo}");
    }
}