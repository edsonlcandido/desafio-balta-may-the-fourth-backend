namespace StarWars.Core.Context.StarWars.UseCases.GetFilmById.Contract;

public interface IRepository
{
    Task<ResponseData?> GetFilmById(int id, CancellationToken cancellationToken);    
}