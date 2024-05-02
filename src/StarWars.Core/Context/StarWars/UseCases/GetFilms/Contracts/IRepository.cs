namespace StarWars.Core.Context.StarWars.UseCases.GetFilms.Contracts;

public interface IRepository
{
    Task<List<ResponseData>> GetFilmsAsync(CancellationToken cancellationToken);
}