using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using StarWars.Core.Context.StarWars.Mappings;
using StarWars.Core.Context.StarWars.UseCases.GetVehicles.Contracts;

namespace StarWars.Core.Context.StarWars.UseCases.GetVehicles;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly IRepository _repository;

    public Handler(IRepository repository) => _repository = repository;    

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        var vehiclesEntity = await _repository.GetVehicleAsync(cancellationToken);
        if (vehiclesEntity == null) return new Response("Vehicles not found",404);
        var vehiclesResponse = vehiclesEntity.Select(x => x.ConvertToResponse()).ToList();
        return new Response("Vehicles List", 200, vehiclesResponse);           
    }
}