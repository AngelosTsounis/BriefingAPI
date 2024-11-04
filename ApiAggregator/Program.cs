using ApiAggregator.Contracts.Request;
using ApiAggregator.Services;
using ApiAggregator.Services.Interfaces;
using ApiAggregator.Validators;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddUserSecrets<Program>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Client Urls
builder.Services.AddHttpClient("OpenWeatherMap", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/weather");
});

builder.Services.AddHttpClient("NewsApi", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://api.nytimes.com/svc/mostpopular/v2/viewed/1.json");
});

builder.Services.AddHttpClient("JokesApi", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://uselessfacts.jsph.pl/api/v2/facts/random");
});

builder.Services.AddHttpClient("ForexApi", httpClient =>
{
    httpClient.BaseAddress = new Uri("http://apilayer.net/api/live");
});

builder.Services.AddSingleton<IWeatherService, WeatherService>();
builder.Services.AddSingleton<INewsService, NewsService>();
builder.Services.AddSingleton<IJokesService, JokesService>();
builder.Services.AddSingleton<IForexService, ForexService>();
builder.Services.AddSingleton<IBriefingService, BriefingService>();

builder.Services.AddScoped<IValidator<BriefingRequest>, BriefingRequestValidator>();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
