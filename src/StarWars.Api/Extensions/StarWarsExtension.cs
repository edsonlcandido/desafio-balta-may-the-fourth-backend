using MediatR;
using StarWars.Core.Context.StarWars.UseCases.GetFilmById;

namespace StarWars.Api.Extensions;

public static class StarWarsExtension
{
    public static void AddStarWarsContext(this WebApplicationBuilder builder)
    {
        #region Get Endpoint Filmes 

        // builder.Services.AddTransient<
        //     IRepository,
        //     Repository>();
        builder.Services.AddTransient<
            Core.Context.StarWars.UseCases.GetFilms.Contracts.IRepository,
            Infra.Context.StarWars.UseCases.GetFilms.Repository
        >();

        builder.Services.AddTransient<
            Core.Context.StarWars.UseCases.GetFilmById.Contract.IRepository,
            Infra.Context.StarWars.UseCases.GetFilmById.Repository
        >();

        builder.Services.AddTransient<
            Core.Context.StarWars.UseCases.GetCharacters.Contracts.IRepository,
            Infra.Context.StarWars.UseCases.GetCharacters.Repository
        >();

        #endregion
    }

    public static void MapStarWarsEndpoints(this WebApplication app)
    {
        #region EndPoint Filmes

        app.MapGet("api/v1/filmes", async (IRequestHandler<Core.Context.StarWars.UseCases.GetFilms.Request,
            Core.Context.StarWars.UseCases.GetFilms.Response> handler) => 
        {
            var request = new Core.Context.StarWars.UseCases.GetFilms.Request();

            var result = await handler.Handle(request, new CancellationToken());

            if (result.IsSuccess)
                return Results.Ok(result);

            return Results.Json(result, statusCode: result.Status);
        });

        app.MapGet("api/v1/filmes/{id:int}", async (int id, IRequestHandler<
            Core.Context.StarWars.UseCases.GetFilmById.Request,
            Core.Context.StarWars.UseCases.GetFilmById.Response> handler) => 
            {
                var request = new Core.Context.StarWars.UseCases.GetFilmById.Request 
                {
                    Id = id
                };
                var result = await handler.Handle(request, new CancellationToken());

                if (result.IsSuccess)
                    return Results.Ok(result);

                return Results.Json(result, statusCode: result.Status);
            });
        #endregion


        #region EndPoint Personagens

        app.MapGet("api/v1/personagens", async (IRequestHandler<Core.Context.StarWars.UseCases.GetCharacters.Request,
            Core.Context.StarWars.UseCases.GetCharacters.Response> handler) =>
        {
            var request = new Core.Context.StarWars.UseCases.GetCharacters.Request();

            var result = await handler.Handle(request, new CancellationToken());

            if (result.IsSuccess)
                return Results.Ok(result);

            return Results.Json(result,statusCode: result.Status);

        });

        #endregion

        #region EndPoint Planetas
        
        app.MapGet("api/v1/planetas", () => "planetas");
        
        #endregion

        #region EndPoint Veiculos

        app.MapGet("api/v1/veiculos", () => "veiculos");

        #endregion

        #region EndPoint Naves Estelares

        app.MapGet("api/v1/naves-estelares", () => "naves-estelares");

        #endregion
    }
    
    
}