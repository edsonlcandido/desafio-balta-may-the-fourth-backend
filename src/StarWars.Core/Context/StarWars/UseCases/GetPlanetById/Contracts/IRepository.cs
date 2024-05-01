using StarWars.Core.Context.StarWars.UseCases.GetPlanetById;

namespace StarWars.Core.Context.StarWars.UseCases.GetPlanetById.Contracts;

public interface IRepository
{
    Task<ResponseData?> GetPlanetByIdAsync(int id, CancellationToken cancellationToken);
}