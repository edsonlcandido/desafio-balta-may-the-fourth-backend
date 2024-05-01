using Microsoft.EntityFrameworkCore;
using StarWars.Core;
using StarWars.Infra.Data;

namespace StarWars.Api.Extensions;

public static class BuilderExtension
{
    public static void AddConfiguration(this WebApplicationBuilder builder)
    {
        Configuration.Database.ConnectionString =
            builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;

        Configuration.Cors.CorsPolicyName = 
            builder.Configuration.GetSection("Cors").GetValue<string>("CorsPolicyName") ?? string.Empty;

        Configuration.Cors.BackendUrl = 
            builder.Configuration.GetSection("Cors").GetValue<string>("BackendUrl") ?? string.Empty;

        Configuration.Cors.FrontendUrl = 
            builder.Configuration.GetSection("Cors").GetValue<string>("FrontendUrl") ?? string.Empty;
        
    }

    public static void AddDatabase(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(options => 
        {
            options.UseSqlite(Configuration.Database.ConnectionString, 
                opt => opt.MigrationsAssembly("StarWars.Api"));
        });
    }

    public static void AddMediator(this WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(x
            => x.RegisterServicesFromAssembly(typeof(Configuration).Assembly));
    }

    public static void AddCorsConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(
            x => x.AddPolicy(
                Configuration.Cors.CorsPolicyName,
                policy => policy
                .WithOrigins([Configuration.Cors.BackendUrl, Configuration.Cors.FrontendUrl])
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
            )
        );

    }

    public static void AddSwaggerConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddOpenApiDocument(config =>
        {
            config.DocumentName = "StarWarsInfoApi";
            config.Title = "StarWarsInfoApi v1";
            config.Version = "v1";
        });
    }
    
}