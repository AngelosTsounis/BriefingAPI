using ApiAggregator.Contracts.Request;
using ApiAggregator.Contracts.Response;
using ApiAggregator.Mappers;
using ApiAggregator.Services.Interfaces;

namespace ApiAggregator.Services;

public class BriefingService : IBriefingService
{
    private readonly IWeatherService _weatherService;
    private readonly INewsService _newsService;
    private readonly IJokesService _jokesService;
    private readonly IForexService _forexService;

    public BriefingService(
        IWeatherService weatherService, 
        INewsService newsService, 
        IJokesService jokesService, 
        IForexService forexService)
    {
        _weatherService = weatherService;
        _newsService = newsService;
        _jokesService = jokesService;
        _forexService = forexService;
    }

    public async Task<BriefingResponse> GetBriefing(BriefingRequest request)
    {
        // Execute service calls in parallel
        var weatherTask = _weatherService.GetWeatherDataAsync(request.City!, request.Latitude, request.Longitude);
        var newsTask = _newsService.GetNewsDataAsync();
        var jokesTask = _jokesService.GetJokesDataAsync(request.JokeLanguage);
        var forexTask = _forexService.GetForexDataAsync(request.SourceCurrency, request.TargetCurrency);

        await Task.WhenAll(weatherTask, newsTask, jokesTask, forexTask);

        // Extract results
        var weatherData = await weatherTask;
        var newsData = await newsTask;
        var jokesData = await jokesTask;
        var forexData = await forexTask;

        // Map responses to DTOs
        var weatherResponse = WeatherResponseMapper.MapToWeatherResponse(weatherData);
        var newsResponse = NewsResponseMapper.MapToNewsResponse(newsData, request.NewsCount);
        var jokesResponse = JokesResponseMapper.MapToJokesResponse(jokesData);
        var forexResponse = ForexResponseMapper.MapToForexResponse(forexData);

        // Prepare the aggregate response
        var aggregateResponse = new BriefingResponse
        {
            Weather = weatherResponse,
            News = newsResponse!,
            Jokes = jokesResponse,
            Forex = forexResponse
        };

        return aggregateResponse;
    }
}
