using MediatR;
using StarWars.Core.Context.StarWars.UseCases.GetSpaceshipById.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Core.Context.StarWars.UseCases.GetSpaceshipById
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
            var data = await _repository.GetStarshipByIdAsync(request.Id, cancellationToken);

            if (data == null)
            {
                return new Response(404, "Nave estelar não encontrada.");
            }
            return new Response(200, "Nave estelar encontrada", data);
        }
    }
}
