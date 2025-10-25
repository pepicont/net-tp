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

    public async Task<Persona?> GetByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Persona>($"personas/{id}");
    }

    public async Task CreateAsync(Persona persona)
    {
        var response = await _httpClient.PostAsJsonAsync("personas", persona);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateAsync(Persona persona)
    {
        var response = await _httpClient.PutAsJsonAsync($"personas/{persona.Id}", persona);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"personas/{id}");
        response.EnsureSuccessStatusCode();
    }
}