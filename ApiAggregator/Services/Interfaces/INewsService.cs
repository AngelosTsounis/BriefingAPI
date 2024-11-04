using ApiAggregator.Models;

namespace ApiAggregator.Services.Interfaces;

public interface INewsService
{
    Task<News> GetNewsDataAsync();
}
