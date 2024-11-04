using ApiAggregator.Contracts.Response;
using ApiAggregator.Models;

namespace ApiAggregator.Mappers;

public static class WeatherResponseMapper
{
    public static WeatherResponse MapToWeatherResponse(WeatherInfo weatherInfo)
    {
        var weatherResponse = new WeatherResponse()
        {
            Country = weatherInfo.Sys?.Country!,
            City = weatherInfo.Name,
            Longititude = weatherInfo.Coord?.Lon ?? 0.0,
            Latitude = weatherInfo.Coord?.Lat ?? 0.0,
            Temperature = weatherInfo.Main?.Temp ?? 0.0,
            Description = weatherInfo.Weather?.FirstOrDefault()?.Description!
        };

        return weatherResponse;
    }
}
