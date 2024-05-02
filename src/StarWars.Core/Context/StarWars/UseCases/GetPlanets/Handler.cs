using MediatR;
using StarWars.Core.Context.StarWars.UseCases.GetPlanets.Contracts;

namespace StarWars.Core.Context.StarWars.UseCases.GetPlanets
{
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
                var data = await _repository.GetPlanetsAsync(cancellationToken);

                if (data.Count == 0)
                    return new Response(404, "Nenhum planeta foi encontrado.");

                return new Response(200, "Planetas encontrados.", data);
            }
            catch (Exception) 
            {
                return new Response(500, "Erro ao buscar os dados no banco.");
            }
        }
    }
}