using MediatR;
using Microsoft.AspNetCore.Mvc;
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

        #endregion

        #region builder Vehicle

        builder.Services.AddTransient<
            Core.Context.StarWars.UseCases.GetVehicles.Contracts.IRepository,
            Infra.Context.StarWars.UseCases.GetVehicles.Repository
        >();

        builder.Services.AddTransient<
            Core.Context.StarWars.UseCases.GetVehicleById.Contracts.IRepository,
            Infra.Context.StarWars.UseCases.GetVehicleById.Repository
        >();

        #endregion

        #region builder Spaceships
        builder.Services.AddTransient<
                       Core.Context.StarWars.UseCases.GetSpaceships.Contracts.IRepository,
                                  Infra.Context.StarWars.UseCases.GetSpaceships.Repository>();
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

        app.MapGet("api/v1/personagens", () => "personagens");

        #endregion

        #region EndPoint Planetas

        app.MapGet("api/v1/planetas", () => "planetas");

        #endregion

        #region EndPoint Vehicle

        app.MapGet("api/v1/veiculos", async (
            [AsParameters] Core.Context.StarWars.UseCases.GetVehicles.Request request,
            IRequestHandler<
                Core.Context.StarWars.UseCases.GetVehicles.Request,
                Core.Context.StarWars.UseCases.GetVehicles.Response> handler) =>
        {
            try
            {
                var result = await handler.Handle(request, new CancellationToken());
                if (!result.IsSuccess)
                    return Results.Json(result, statusCode: result.Status);

                if (result.Data is null)
                    return Results.Json(result, statusCode: 500);

                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return Results.Json(
                    new Core.Context.StarWars.UseCases.GetVehicles.Response(ex.Message, 500)
                );
            }

        });

        app.MapGet("api/v1/veiculos/{id:int}", async (
            [AsParameters] Core.Context.StarWars.UseCases.GetVehicleById.Request request,
            IRequestHandler<
                Core.Context.StarWars.UseCases.GetVehicleById.Request,
                Core.Context.StarWars.UseCases.GetVehicleById.Response> handler) =>
        {
            try
            {
                if (request.IsInvalid()) return Results.Json(
                    new Core.Context.StarWars.UseCases.GetVehicleById.Response("Invalid parameter", 422)
                 );
                var result = await handler.Handle(request, new CancellationToken());

                if (result.IsSuccess)
                    return Results.Ok(result);

                return Results.Json(result, statusCode: result.Status);
            }
            catch (Exception ex)
            {
                return Results.Json(
                    new Core.Context.StarWars.UseCases.GetVehicleById.Response(ex.Message, 500)
                );
            }

        });

        #endregion

        #region EndPoint Naves Estelares

        app.MapGet("api/v1/naves-estelares", async (IRequestHandler<Core.Context.StarWars.UseCases.GetSpaceships.Request, 
            Core.Context.StarWars.UseCases.GetSpaceships.Response> handler) =>
            {
                var request = new Core.Context.StarWars.UseCases.GetSpaceships.Request();
                var result = await handler.Handle(request, new CancellationToken());
                if (result.IsSuccess)
                    return Results.Ok(result);
                return Results.Json(result, statusCode: result.Status);
            }
        );

        #endregion
    }


}