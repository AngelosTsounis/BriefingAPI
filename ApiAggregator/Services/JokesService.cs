using ApiAggregator.Models;
using ApiAggregator.Services.Interfaces;
using System.Text.Json;

namespace ApiAggregator.Services;

public class JokesService : IJokesService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public JokesService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<Jokes> GetJokesDataAsync(string language)
    {
        var httpClient = _httpClientFactory.CreateClient("JokesApi");
        try
        {
            var response = await httpClient.GetAsync($"?language={language}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Jokes>(content);

            return result!;

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occured at GetJokesAsync");
            throw ex;
        }
    }
}
