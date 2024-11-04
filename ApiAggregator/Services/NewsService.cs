using ApiAggregator.Models;
using ApiAggregator.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace ApiAggregator.Services;

public class NewsService : INewsService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string ApiKey;

    public NewsService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        ApiKey = configuration["ApiKeys:NewsApi"]!;
    }

    public async Task<News> GetNewsDataAsync()
    {
        var httpClient = _httpClientFactory.CreateClient("NewsApi");
        try
        {
            var response = await httpClient.GetAsync($"?api-key={ApiKey}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<News>(content);

            return result!;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred at GetNewsDataAsync: {ex.Message}");
            throw;
        }
    }
}
