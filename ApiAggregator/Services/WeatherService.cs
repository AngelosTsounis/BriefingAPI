using ApiAggregator.Models;
using ApiAggregator.Services.Interfaces;
using System.Text.Json;

namespace ApiAggregator.Services;

public class WeatherService : IWeatherService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string ApiKey;

    public WeatherService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        ApiKey = configuration["ApiKeys:OpenWeatherMap"]!;
    }

    public async Task<WeatherInfo> GetWeatherDataAsync(string city, double? latitude, double? longitude)
    {
        var httpClient = _httpClientFactory.CreateClient("OpenWeatherMap");
        var apiUrl = CreateUrlBasedOnRequestParameters(city, latitude, longitude);

        try
        {
            var response = await httpClient.GetAsync($"?APPID={ApiKey}&{apiUrl}&units=metric");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<WeatherInfo>(content)!;

            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred at GetWeatherDataAsync: {ex.Message}");
            throw;
        }
    }

    private string CreateUrlBasedOnRequestParameters(string city, double? latitude, double? longitude)
    {
        if (!string.IsNullOrWhiteSpace(city))
        {
            return $"q={city}";
        }
        else
        {
            return $"lat={latitude}&lon={longitude}";
        }
    }
}
