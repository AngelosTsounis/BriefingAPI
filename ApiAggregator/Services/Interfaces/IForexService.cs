using ApiAggregator.Models;

namespace ApiAggregator.Services.Interfaces;

public interface IForexService
{
    Task<Forex> GetForexDataAsync(string sourceCurrency, string targetCurrency);
}
