using ApiAggregator.Contracts.Response;
using ApiAggregator.Models;

namespace ApiAggregator.Mappers;

public static class JokesResponseMapper
{
    public static JokesResponse MapToJokesResponse(Jokes jokes)
    {
        var jokesResponse = new JokesResponse()
        {
            Text = jokes.Text,
            Source = jokes.Permalink.ToString(),
        };

        return jokesResponse;
    }
}
