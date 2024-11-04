using ApiAggregator.Models;

namespace ApiAggregator.Services.Interfaces;

public interface IWeatherService
{
    Task<WeatherInfo> GetWeatherDataAsync(string city, double? latitude, double? longitude);
}