
namespace StarWars.Core.Context.StarWars.UseCases.GetCharacters.Contracts;

public interface IRepository
{
    Task<List<ResponseData>> GetCharactersAsync(CancellationToken cancellationToken);
}