
using StarWars.Core.Context.StarWars.Entities;

namespace StarWars.Core.Context.StarWars.UseCases.GetCharacterById.Contracts;

public interface IRepository
{
    Task<ResponseData?> GetCharacterByIdAsync(int id, CancellationToken cancellationToken);
}