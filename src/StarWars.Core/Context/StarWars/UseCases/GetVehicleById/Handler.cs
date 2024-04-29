using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using StarWars.Core.Context.StarWars.Mappings;
using StarWars.Core.Context.StarWars.UseCases.GetVehicleById.Contracts;

namespace StarWars.Core.Context.StarWars.UseCases.GetVehicleById;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly IRepository _repository;

    public Handler(IRepository repository) => _repository = repository;

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        var vehicleEntity = await _repository.GetVehicleById(request.Id, cancellationToken);
        if (vehicleEntity is null) return new Response("Vehicle not fount.", 404);
        var vehicleResponse = vehicleEntity.ConvertToResponse(); 
        return new Response($"Vehicle id: {request.Id}", 200, vehicleResponse);
    }

}