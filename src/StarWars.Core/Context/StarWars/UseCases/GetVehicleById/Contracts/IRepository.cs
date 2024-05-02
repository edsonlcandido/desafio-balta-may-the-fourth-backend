using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarWars.Core.Context.StarWars.Entities;

namespace StarWars.Core.Context.StarWars.UseCases.GetVehicleById.Contracts;

public interface IRepository
{
    Task<Vehicle?> GetVehicleById(int id, CancellationToken cancellationToken);
}