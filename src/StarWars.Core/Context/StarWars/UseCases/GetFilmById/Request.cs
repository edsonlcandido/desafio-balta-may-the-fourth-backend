using MediatR;

namespace StarWars.Core.Context.StarWars.UseCases.GetFilmById;

public class Request : IRequest<Response>
{
    public int Id { get; set; }
}