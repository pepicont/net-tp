using Domain.model;

public class UsuarioHttpService
{
    private readonly HttpClient _httpClient;

    public UsuarioHttpService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("http://localhost:5290");
    }

    public async Task<List<Usuario>> GetAllAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Usuario>>("usuarios")
               ?? new List<Usuario>();
    }

    public async Task<Usuario?> GetByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Usuario>($"usuarios/{id}");
    }

    public async Task CreateAsync(Usuario persona)
    {
        var response = await _httpClient.PostAsJsonAsync("usuarios", persona);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateAsync(Usuario persona)
    {
        var response = await _httpClient.PutAsJsonAsync($"usuarios/{persona.Id}", persona);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"usuarios/{id}");
        response.EnsureSuccessStatusCode();
    }
}