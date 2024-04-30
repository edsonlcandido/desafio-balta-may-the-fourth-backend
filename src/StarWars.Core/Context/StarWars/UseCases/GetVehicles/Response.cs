using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Core.Context.StarWars.UseCases.GetVehicles;

public class Response : Shared.UseCases.Response
{

    protected Response() {}

    public Response(string message, int status,IEnumerable<Core.Context.StarWars.ViewObjets.Vehicle>? data = null )
    {
        Message = message;
        Status = status;
        Data = data;   
    }

    public IEnumerable<Context.StarWars.ViewObjets.Vehicle>? Data { get; set; } = [];
    
}
