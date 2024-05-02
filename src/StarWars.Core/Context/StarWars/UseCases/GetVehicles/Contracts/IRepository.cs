using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarWars.Core.Context.StarWars.Entities;

namespace StarWars.Core.Context.StarWars.UseCases.GetVehicles.Contracts;

public interface IRepository
{
    Task<List<Vehicle>> GetVehicleAsync(CancellationToken cancellationToken);
}