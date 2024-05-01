using MediatR;
using StarWars.Core.Context.StarWars.UseCases.GetPlanetById.Contracts;

namespace StarWars.Core.Context.StarWars.UseCases.GetPlanetById;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly IRepository _repository;

    public Handler(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        try
        {
            var data = await _repository.GetPlanetByIdAsync(request.Id, cancellationToken);

            if (data == null)
                return new Response(404, "Não foi encontrado nenhum planeta com este id.");

            return new Response(200, "Dados do planeta.", data);
        }
        catch (Exception)
        {
            return new Response(500, "Erro ao buscar os dados no banco.");
        }
    }
}