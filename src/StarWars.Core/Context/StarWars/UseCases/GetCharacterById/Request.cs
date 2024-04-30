using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Core.Context.StarWars.UseCases.GetCharacterById
{
    public class Request : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
