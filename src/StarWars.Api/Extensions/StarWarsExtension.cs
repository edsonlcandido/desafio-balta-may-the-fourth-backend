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
                                      Infra.Context.StarWars.UseCases.GetSpaceships.Repository>
                                      ();
            builder.Services.AddTransient<
                Core.Context.StarWars.UseCases.GetSpaceshipById.Contract.IRepository,
                Infra.Context.StarWars.UseCases.GetSpaceshipByid.Repository>();

        #endregion
    
  
        #region builder Character

              builder.Services.AddTransient<
                  Core.Context.StarWars.UseCases.GetCharacters.Contracts.IRepository,
                  Infra.Context.StarWars.UseCases.GetCharacters.Repository
              >();

              builder.Services.AddTransient<
                  Core.Context.StarWars.UseCases.GetCharacterById.Contracts.IRepository,
                  Infra.Context.StarWars.UseCases.GetCharacterById.Repository
              >();

        #endregion

        #region builder Planet

              builder.Services.AddTransient<
                  Core.Context.StarWars.UseCases.GetPlanets.Contracts.IRepository,
                  Infra.Context.StarWars.UseCases.GetPlanets.Repository
              >();

              builder.Services.AddTransient<
                  Core.Context.StarWars.UseCases.GetPlanetById.Contracts.IRepository,
                  Infra.Context.StarWars.UseCases.GetPlanetById.Repository
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

        app.MapGet("api/v1/personagens/", async (
            [AsParameters] Core.Context.StarWars.UseCases.GetCharacters.Request request,
            IRequestHandler<Core.Context.StarWars.UseCases.GetCharacters.Request,
            Core.Context.StarWars.UseCases.GetCharacters.Response> handler) =>
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

        app.MapGet("api/v1/personagens/{id:int}", async (
            int id, IRequestHandler<
            Core.Context.StarWars.UseCases.GetCharacterById.Request,
            Core.Context.StarWars.UseCases.GetCharacterById.Response> handler) =>
        {
            var request = new Core.Context.StarWars.UseCases.GetCharacterById.Request
            {
                Id = id
            };
            var result = await handler.Handle(request, new CancellationToken());

            if (result.IsSuccess)
                return Results.Ok(result);

            return Results.Json(result, statusCode: result.Status);

        });

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

        app.MapGet("api/v1/naves-estelares/{id:int}", async (int id, IRequestHandler<Core.Context.StarWars.UseCases.GetSpaceshipById.Request,
                       Core.Context.StarWars.UseCases.GetSpaceshipById.Response> handler) =>
        {
                var request = new Core.Context.StarWars.UseCases.GetSpaceshipById.Request
                {
                    Id = id
                };
                var result = await handler.Handle(request, new CancellationToken());
                if (result.IsSuccess)
                    return Results.Ok(result);
                return Results.Json(result, statusCode: result.Status);
            });

        #endregion


        #region EndPoint Planets

        app.MapGet("api/v1/planetas", async (IRequestHandler<Core.Context.StarWars.UseCases.GetPlanets.Request, 
            Core.Context.StarWars.UseCases.GetPlanets.Response> handler) =>
            {
                var request = new Core.Context.StarWars.UseCases.GetPlanets.Request();
                var result = await handler.Handle(request, new CancellationToken());
                if (result.IsSuccess)
                    return Results.Ok(result);
                return Results.Json(result, statusCode: result.Status);
            }
        );

        app.MapGet("api/v1/planetas/{id:int}", async (int id, IRequestHandler<Core.Context.StarWars.UseCases.GetPlanetById.Request,
                       Core.Context.StarWars.UseCases.GetPlanetById.Response> handler) =>
        {
            var request = new Core.Context.StarWars.UseCases.GetPlanetById.Request
            {
                Id = id
            };
                
            var result = await handler.Handle(request, new CancellationToken());
            if (result.IsSuccess)
                return Results.Ok(result);
                
            return Results.Json(result, statusCode: result.Status);
        });

        #endregion
    }


}