using MediatR;
using StarWars.Core.Context.StarWars.UseCases.GetFilmById.Contract;

namespace StarWars.Core.Context.StarWars.UseCases.GetFilmById;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly IRepository _repository;

    public Handler(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        var data = await _repository.GetFilmById(request.Id, cancellationToken);

        if (data == null)
            return new Response(404, "Filme não encontrado.");

        return new Response(200, "Filme encontrado", data);
    }
}