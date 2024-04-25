using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace StarWars.Api.Extensions;

public static class StarWarsExtension
{
    public static void AddStarWarsContext(this WebApplicationBuilder builder)
    {
        #region Get Endpoint Filmes 

        // builder.Services.AddTransient<
        //     IRepository,
        //     Repository>();

        #endregion
    }

    public static void MapStarWarsEndpoints(this WebApplication app)
    {
        #region EndPoint Filmes

        app.MapGet("api/v1/filmes", () => "Filmes");

        #endregion


        #region EndPoint Personagens

        app.MapGet("api/v1/personagens", () => "personagens");

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