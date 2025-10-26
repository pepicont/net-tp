using Domain.model;

public class MateriaHttpService
{
    private readonly HttpClient _httpClient;

    public MateriaHttpService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("http://localhost:5290");
    }

    public async Task<List<Materia>> GetAllAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Materia>>("materias")
               ?? new List<Materia>();
    }
    public async Task CreateAsync(Materia materia)
    {
        var response = await _httpClient.PostAsJsonAsync("materias", materia);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateAsync(Materia materia)
    {
        var response = await _httpClient.PutAsJsonAsync($"materias/{materia.Id}", materia);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"materias/{id}");
        response.EnsureSuccessStatusCode();
    }
}
