using StarWars.Api.Extensions;
using StarWars.Core;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfiguration();
builder.AddDatabase();
builder.AddCorsConfiguration();
builder.AddStarWarsContext();
builder.AddMediator();
builder.AddSwaggerConfiguration();

var app = builder.Build();
app.UseCors(Configuration.Cors.CorsPolicyName);
app.UseHttpsRedirection();
app.MapStarWarsEndpoints();
app.MapGet("/", () => "Hello World!");

app.UseOpenApi();
    app.UseSwaggerUi(config =>
    {
        config.DocumentTitle = "StarWarsInfoApi";
        config.Path = "/swagger";
        config.DocumentPath = "/swagger/{documentName}/swagger.json";
        config.DocExpansion = "list";
    });

app.Run();
