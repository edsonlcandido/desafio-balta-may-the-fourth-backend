using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarWars.Core.Context.StarWars.UseCases.GetVehicles;

namespace StarWars.Core.Context.StarWars.UseCases.GetVehicleById;

public class Response : Shared.UseCases.Response
{

    protected Response() {}

    public Response(string message, int status, Core.Context.StarWars.ViewObjets.Vehicle? data = null )
    {
        Message = message;
        Status = status;
        Data = data;   
    }

    public Core.Context.StarWars.ViewObjets.Vehicle? Data { get; set; }

}