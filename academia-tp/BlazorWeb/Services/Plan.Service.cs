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
}
