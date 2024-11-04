using ApiAggregator.Models;
using ApiAggregator.Services.Interfaces;
using System.Text.Json;

namespace ApiAggregator.Services;

public class ForexService : IForexService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string ApiKey;
    public ForexService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        ApiKey = configuration["ApiKeys:ForexApi"]!;
    }
    public async Task<Forex> GetForexDataAsync(string sourceCurrency, string targetCurrency)
    {
        var httpClient = _httpClientFactory.CreateClient("ForexApi");

        try
        {
            var response = await httpClient.GetAsync($"?access_key={ApiKey}&currencies={sourceCurrency}&source={targetCurrency}&format=4");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Forex>(content)!;

            return result;
        }
        catch (Exception ex) 
        {
            Console.WriteLine($"Error occured at GetForexDataAsync");
            throw ex;
        }
    }
}
