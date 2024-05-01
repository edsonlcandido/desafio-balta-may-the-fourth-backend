using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Core.Context.StarWars.UseCases.GetSpaceships.Contracts;

public interface IRepository
{
    Task<List<ResponseData>> GetStarshipsAsync(CancellationToken cancellationToken);
}