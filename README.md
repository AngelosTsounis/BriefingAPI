# Briefing API Documentation

The Briefing API provides an aggregated data response, pulling information from weather, news, jokes, and foreign exchange APIs to deliver a comprehensive briefing to clients. The API request and response structure, as well as validation and error handling details, are outlined below.

## Base URL

/api/briefing


## Endpoint

### GET `/api/briefing`

#### Description
The `GetBriefing` endpoint aggregates data from multiple external APIs (weather, news, jokes, forex) based on the request parameters provided by the client. The service will return the briefing details as a single response.

#### Request Parameters

| Parameter        | Type    | Required | Description                                                                                                     |
|------------------|---------|----------|-----------------------------------------------------------------------------------------------------------------|
| `City`           | string  | Optional | The city for the weather data. Cannot contain numbers or special characters.                                        |
| `Latitude`       | double  | Optional | The latitude for weather data. Must be between -90 and 90. Required if `Longitude` is provided.                |
| `Longitude`      | double  | Optional | The longitude for weather data. Must be between -180 and 180. Required if `Latitude` is provided.              |
| `NewsCount`      | int     | Yes      | Number of news articles to retrieve, between 1 and 20.                                                         |
| `JokeLanguage`   | string  | Yes      | Language of jokes; valid values are `"en"` (English) and `"de"` (German).                                       |
| `SourceCurrency` | string  | Yes      | Source currency for forex data, as a valid 3-letter currency code (e.g., USD, EUR).                            |
| `TargetCurrency` | string  | Yes      | Target currency for forex data, as a valid 3-letter currency code.                                              |

#### Sample Request

```http
GET /api/briefing?City=Berlin&NewsCount=5&JokeLanguage=en&SourceCurrency=USD&TargetCurrency=EUR
```
Response
The response is a JSON object containing aggregated data across weather, news, jokes, and forex.

Response Format

```json
{
  "Weather": {
    "Country": "string",
    "City": "string",
    "Longitude": "double",
    "Latitude": "double",
    "Temperature": "double",
    "Description": "string"
  },
  "News": [
    {
      "Type": "string",
      "Title": "string",
      "PublishedDate": "string",
      "Source": "string",
      "Url": "string"
    }
  ],
  "Forex": {
    "SourceCurrency": "string",
    "CurrencyRates": {
      "TargetCurrency": "double"
    }
  },
  "Jokes": {
    "Text": "string",
    "Source": "string"
  }
}
```

Sample Response
```json
{
  "Weather": {
    "Country": "Germany",
    "City": "Berlin",
    "Longitude": 13.405,
    "Latitude": 52.52,
    "Temperature": 18.0,
    "Description": "Partly cloudy"
  },
  "News": [
    {
      "Type": "Technology",
      "Title": "Tech Conference Highlights",
      "PublishedDate": "2024-11-01",
      "Source": "Tech Daily",
      "Url": "https://techdaily.com/conference-highlights"
    }
  ],
  "Forex": {
    "SourceCurrency": "USD",
    "CurrencyRates": {
      "EUR": 0.85
    }
  },
  "Jokes": {
    "Text": "Why did the developer go broke? Because they used up all their cache.",
    "Source": "JokesAPI"
  }
}

```

## Validation Errors
The API performs validation on request parameters to ensure data integrity and meaningful results. Validation errors are returned with 400 Bad Request and include the field name and error message.

Validation Rules
- City: If not null, must contain only alphabetic characters. If empty,Latitude and Longitude are required.
- Latitude: Required if City is not provided. Must be between -90 and 90.
- Longitude: Required if City is not provided. Must be between -180 and 180.
- NewsCount: Required. Must be an integer between 1 and 20.
- JokeLanguage: Required. Must be either "en" or "de".
- SourceCurrency: Required. Must be a valid 3-letter currency code (e.g., USD, EUR).
- TargetCurrency: Required. Must be a valid 3-letter currency code.

Sample Validation Error Response
```json
{
  "errors": [
    {
      "PropertyName": "City",
      "ErrorMessage": "City must be a valid name and cannot contain numbers or special characters."
    },
    {
      "PropertyName": "Latitude",
      "ErrorMessage": "Latitude must be between -90 and 90 degrees."
    }
  ]
}

```

## Error Handling
The API returns standardized error codes for easy troubleshooting.

|HTTP Code	|Reason	               |Description                                                 |
|-----------|----------------------|------------------------------------------------------------|
|200	    |OK	                   |Successful request and response.                            |
|400	    |Bad Request           |Request validation failed (invalid or missing parameters).  |
|500	    |Internal Server Error |An error occurred on the server.                            |

## Dependencies
The Briefing API consumes the following external services:

- [OpenWeatherMap API](https://openweathermap.org/api) : Retrieves weather data based on location (city, latitude, and longitude).

- [New York Times API](https://developer.nytimes.com/docs/most-popular-product/1/overview) : Provides a list of news articles based on the NewsCount parameter.
- [FreeForexAPI](https://freeforexapi.com/Home/Api) : Fetches exchange rate data between the SourceCurrency and TargetCurrency.
- [Random Useless Facts API](https://uselessfacts.jsph.pl/) : Supplies a joke in the specified language.

## Technologies
.NET 8
FluentValidation for request validation
ASP.NET Core for API creation
