using StarWars.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfiguration();
builder.AddDatabase();
builder.AddStarWarsContext();
builder.AddMediator();

var app = builder.Build();
app.UseHttpsRedirection();
app.MapStarWarsEndpoints();
app.MapGet("/", () => "Hello World!");

app.Run();
