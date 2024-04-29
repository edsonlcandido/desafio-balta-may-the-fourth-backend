using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace StarWars.Core.Context.StarWars.UseCases.GetVehicleById;

public class Request : IRequest<Response>
{
    public int Id { get; set; }

    public bool IsInvalid() => this.Id <= 0;
}