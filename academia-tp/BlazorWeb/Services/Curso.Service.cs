using Domain.model;

public class CursoHttpService
{
    private readonly HttpClient _httpClient;

    public CursoHttpService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("http://localhost:5290");
    }

    public async Task<List<Curso>> GetPorMateriaAsync(int materiaId)
    {
        return await _httpClient.GetFromJsonAsync<List<Curso>>($"cursos/materia/{materiaId}")
               ?? new List<Curso>();
    }
}