using System.Text.Json.Serialization;

namespace ApiAggregator.Models;

public class Jokes
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("source")]
    public string Source { get; set; }

    [JsonPropertyName("source_url")]
    public Uri SourceUrl { get; set; }

    [JsonPropertyName("language")]
    public string Language { get; set; }

    [JsonPropertyName("permalink")]
    public Uri Permalink { get; set; }
}
