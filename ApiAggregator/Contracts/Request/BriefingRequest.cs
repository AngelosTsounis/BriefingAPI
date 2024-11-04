namespace ApiAggregator.Contracts.Request;

public class BriefingRequest
{
    public string? City { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public int NewsCount { get; set; }
    public string JokeLanguage { get; set; }
    public string SourceCurrency { get; set; }
    public string TargetCurrency { get; set; }

}