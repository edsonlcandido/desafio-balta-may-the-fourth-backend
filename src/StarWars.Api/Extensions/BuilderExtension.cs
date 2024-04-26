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
    
}