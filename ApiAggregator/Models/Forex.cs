namespace ApiAggregator.Models;

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public partial class Forex
{
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("terms")]
    public Uri Terms { get; set; }

    [JsonPropertyName("privacy")]
    public Uri Privacy { get; set; }

    [JsonPropertyName("timestamp")]
    public long Timestamp { get; set; }

    [JsonPropertyName("source")]
    public string Source { get; set; }

    [JsonPropertyName("quotes")]
    public Dictionary<string, double> Quotes { get; set; }
}


