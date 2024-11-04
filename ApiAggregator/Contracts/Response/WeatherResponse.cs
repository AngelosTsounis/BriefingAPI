namespace ApiAggregator.Contracts.Response;

public class WeatherResponse
{
    public string Country { get; set; }
    public string City { get; set; }
    public double Longititude { get; set; }
    public double Latitude { get; set; }
    public double Temperature { get; set; }
    public string Description { get; set; }
}
