using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Core.Context.StarWars.UseCases.GetSpaceshipById.Contract
{
    public interface IRepository
    {
        Task<ResponseData?> GetStarshipByIdAsync(int id, CancellationToken cancellationToken);
    }
}
