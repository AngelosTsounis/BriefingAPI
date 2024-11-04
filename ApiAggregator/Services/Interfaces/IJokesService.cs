using ApiAggregator.Contracts.Request;
using ApiAggregator.Models;

namespace ApiAggregator.Services.Interfaces;

public interface IJokesService
{
    Task<Jokes> GetJokesDataAsync(string language);
}
