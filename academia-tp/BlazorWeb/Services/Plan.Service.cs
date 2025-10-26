using Domain.model;

public class PlanHttpService
{
    private readonly HttpClient _httpClient;

    public PlanHttpService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("http://localhost:5290");
    }

    public async Task<List<Plan>> GetAllAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Plan>>("planes")
               ?? new List<Plan>();
    }

    public async Task CreateAsync(Plan plan)
    {
        var response = await _httpClient.PostAsJsonAsync("planes", plan);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateAsync(Plan plan)
    {
        var response = await _httpClient.PutAsJsonAsync($"planes/{plan.Id}", plan);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"planes/{id}");
        response.EnsureSuccessStatusCode();
    }
}
