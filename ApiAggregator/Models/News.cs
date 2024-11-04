namespace ApiAggregator.Models;

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public partial class News
{
    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("copyright")]
    public string Copyright { get; set; }

    [JsonPropertyName("num_results")]
    public long NumResults { get; set; }

    [JsonPropertyName("results")]
    public List<Result> Results { get; set; }
}

public partial class Result
{
    [JsonPropertyName("uri")]
    public string Uri { get; set; }

    [JsonPropertyName("url")]
    public Uri Url { get; set; }

    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("asset_id")]
    public long AssetId { get; set; }

    [JsonPropertyName("source")]
    public string Source { get; set; }

    [JsonPropertyName("published_date")]
    public string PublishedDate { get; set; }

    [JsonPropertyName("updated")]
    public string Updated { get; set; }

    [JsonPropertyName("section")]
    public string Section { get; set; }

    [JsonPropertyName("subsection")]
    public string Subsection { get; set; }

    [JsonPropertyName("nytdsection")]
    public string Nytdsection { get; set; }

    [JsonPropertyName("adx_keywords")]
    public string AdxKeywords { get; set; }

    [JsonPropertyName("column")]
    public object Column { get; set; }

    [JsonPropertyName("byline")]
    public string Byline { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("abstract")]
    public string Abstract { get; set; }

    [JsonPropertyName("des_facet")]
    public List<string> DesFacet { get; set; }

    [JsonPropertyName("org_facet")]
    public List<object> OrgFacet { get; set; }

    [JsonPropertyName("per_facet")]
    public List<string> PerFacet { get; set; }

    [JsonPropertyName("geo_facet")]
    public List<string> GeoFacet { get; set; }

    [JsonPropertyName("media")]
    public List<Media> Media { get; set; }

    [JsonPropertyName("eta_id")]
    public long EtaId { get; set; }
}

public partial class Media
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("subtype")]
    public string Subtype { get; set; }

    [JsonPropertyName("caption")]
    public string Caption { get; set; }

    [JsonPropertyName("copyright")]
    public string Copyright { get; set; }

    [JsonPropertyName("approved_for_syndication")]
    public long ApprovedForSyndication { get; set; }

    [JsonPropertyName("media-metadata")]
    public List<MediaMetadatum> MediaMetadata { get; set; }
}

public partial class MediaMetadatum
{
    [JsonPropertyName("url")]
    public Uri Url { get; set; }

    [JsonPropertyName("format")]
    public string Format { get; set; }

    [JsonPropertyName("height")]
    public long Height { get; set; }

    [JsonPropertyName("width")]
    public long Width { get; set; }
}