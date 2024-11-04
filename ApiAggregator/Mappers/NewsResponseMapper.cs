using ApiAggregator.Contracts.Response;
using ApiAggregator.Models;

namespace ApiAggregator.Mappers;

public static class NewsResponseMapper
{
    public static List<NewsResponse> MapToNewsResponse(News news, int newsCount)
    {
        return news.Results
              .Take(newsCount)
              .Select(newsResult => new NewsResponse
              {
                  Type = newsResult.Type,
                  Title = newsResult.Title,
                  PublishedDate = newsResult.PublishedDate,
                  Source = newsResult.Source,
                  Url = newsResult.Url?.ToString()!
              })
              .ToList();
    }
}
