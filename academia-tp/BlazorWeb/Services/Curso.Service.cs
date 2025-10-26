using Domain.model;

public class CursoHttpService
{
    private readonly HttpClient _httpClient;

    public CursoHttpService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("http://localhost:5290");
    }
    public async Task<List<Curso>> GetAllAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Curso>>("cursos")
               ?? new List<Curso>();
    }
    public async Task<List<Curso>> GetPorMateriaAsync(int materiaId)
    {
        return await _httpClient.GetFromJsonAsync<List<Curso>>($"cursos/materia/{materiaId}")
               ?? new List<Curso>();
    }
    public async Task<Curso?> GetByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Curso>($"cursos/{id}");
    }

    public async Task CreateAsync(Curso curso)
    {
        var response = await _httpClient.PostAsJsonAsync("cursos", curso);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateAsync(Curso curso)
    {
        var response = await _httpClient.PutAsJsonAsync($"cursos/{curso.Id}", curso);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"cursos/{id}");
        response.EnsureSuccessStatusCode();
    }

}