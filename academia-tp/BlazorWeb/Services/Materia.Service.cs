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
    /*public async Task CreateAsync(Especialidad especialidad)
    {
        var response = await _httpClient.PostAsJsonAsync("especialidades", especialidad);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateAsync(Especialidad especialidad)
    {
        var response = await _httpClient.PutAsJsonAsync($"especialidades/{especialidad.Id}", especialidad);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"especialidades/{id}");
        response.EnsureSuccessStatusCode();
    }*/
}
