namespace StarWars.Core.Context.StarWars.UseCases.GetPlanets.Contracts;

public interface IRepository
{
    Task<List<ResponseData>> GetPlanetsAsync(CancellationToken cancellationToken);
}