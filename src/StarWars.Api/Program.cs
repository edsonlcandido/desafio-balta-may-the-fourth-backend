using StarWars.Api.Extensions;
using StarWars.Core;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfiguration();
builder.AddDatabase();
builder.AddCorsConfiguration();
builder.AddStarWarsContext();
builder.AddMediator();

var app = builder.Build();
app.UseCors(Configuration.Cors.CorsPolicyName);
app.UseHttpsRedirection();
app.MapStarWarsEndpoints();
app.MapGet("/", () => "Hello World!");

app.Run();
