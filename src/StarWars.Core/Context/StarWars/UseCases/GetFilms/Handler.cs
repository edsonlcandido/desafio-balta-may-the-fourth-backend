using MediatR;
using StarWars.Core.Context.StarWars.UseCases.GetFilms.Contracts;

namespace StarWars.Core.Context.StarWars.UseCases.GetFilms;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly IRepository _repository;

    public Handler(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        var data = await _repository.GetFilmsAsync(cancellationToken);

        if (data.Count == 0)
            return new Response(404, "Não foram encontrados nenhum filme");

        return new Response(200, "Aqui estão os filmes", data);
    }
}