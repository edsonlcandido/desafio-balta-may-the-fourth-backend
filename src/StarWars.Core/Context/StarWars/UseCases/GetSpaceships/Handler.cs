using MediatR;
using StarWars.Core.Context.StarWars.UseCases.GetSpaceships.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Core.Context.StarWars.UseCases.GetSpaceships
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
            var data = await _repository.GetStarshipsAsync(cancellationToken);

            if (data.Count == 0)
                return new Response(404, "Não foram encontradas naves estelares");

            return new Response(200, "Aqui estão as naves estelares", data);
        }
    }

}
