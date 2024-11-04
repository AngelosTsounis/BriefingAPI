namespace ApiAggregator.Contracts.Response;

public class ForexResponse
{
    public string SourceCurrency { get; set; }
    public Dictionary<string, double> CurrencyRates { get; set; }
}
