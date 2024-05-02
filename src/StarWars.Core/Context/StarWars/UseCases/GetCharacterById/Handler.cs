using MediatR;
using StarWars.Core.Context.StarWars.UseCases.GetCharacterById.Contracts;

namespace StarWars.Core.Context.StarWars.UseCases.GetCharacterById;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly IRepository _repository;

    public Handler(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        var data = await _repository.GetCharacterByIdAsync(request.Id, cancellationToken);

        if (data == null)
            return new Response(404, "Não foi encontrado nenhum personagem");

        return new Response(200, "Personagens", data);


        
    }
}
