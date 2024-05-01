using MediatR;

namespace StarWars.Core.Context.StarWars.UseCases.GetPlanetById;

public class Request : IRequest<Response>
{
    public int Id { get; set; }
}