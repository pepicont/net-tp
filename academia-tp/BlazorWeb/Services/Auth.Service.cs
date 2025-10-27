using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Domain.model;

public class AuthHttpService
{
    private readonly HttpClient _httpClient;

    public AuthHttpService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("http://localhost:5290");
    }

    public async Task<Usuario?> LoginAsync(string username, string password)
    {
        try
        {
            var response = await _httpClient.PostAsync(
                $"auth/login?username={username}&password={password}",
                null);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Usuario>();
            }

            return null;
        }
        catch
        {
            return null;
        }
    }
}