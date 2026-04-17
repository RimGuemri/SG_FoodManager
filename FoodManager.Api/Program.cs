using FoodManager.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var excelPath = builder.Configuration.GetValue<string>("PizzaSettings:ExcelPath");

// On dit : "Quand quelqu'un a besoin d'un IDataLoader, crée un ExcelDataLoader avec ce chemin"
builder.Services.AddScoped<IDataLoader>(sp => new ExcelDataLoader(excelPath));

var app = builder.Build();



// le code ci dessous a été créé automatiquement avec la création du project par console


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
