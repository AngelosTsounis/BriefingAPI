namespace ApiAggregator.Contracts.Response;

public class BriefingResponse
{
    public WeatherResponse? Weather { get; set; }
    public List<NewsResponse?> News { get; set; }
    public ForexResponse? Forex { get; set; }
    public JokesResponse? Jokes { get; set; }
}