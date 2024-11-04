using ApiAggregator.Contracts.Response;
using ApiAggregator.Models;

namespace ApiAggregator.Mappers;

public static class ForexResponseMapper
{
    public static ForexResponse MapToForexResponse(Forex forex)
    {
        var forexResponse = new ForexResponse()
        {
            SourceCurrency = forex.Source,
            CurrencyRates = forex.Quotes,
        };

        return forexResponse;
    }
}
