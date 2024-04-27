using Microsoft.EntityFrameworkCore;
using StarWars.Core.Context.StarWars.Entities;
using StarWars.Core.Context.StarWars.UseCases.GetFilmById;
using StarWars.Core.Context.StarWars.UseCases.GetFilmById.Contract;
using StarWars.Infra.Data;

namespace StarWars.Infra.Context.StarWars.UseCases.GetFilmById;

public class Repository : IRepository
{
    private readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ResponseData?> GetFilmById(int id, CancellationToken cancellationToken)
    {
        return await _context.Films
            .AsNoTracking()
            .Include(x => x.Characters)
            .Include(x => x.Planets)
            .Include(x => x.Vehicles)
            .Include(x => x.Spaceships)
            .Where(x => x.Id == id)
            .Select<Film, ResponseData>(x => new ResponseData 
                {
                    Title = x.Title,
                    Episode = x.Episode,
                    OpeningCrawl = x.OpeningCrawl,
                    Director = x.Director,
                    Producer = x.Producer,
                    ReleaseDate = x.ReleaseDate,
                    Characters = x.Characters.Select(y => new { y.Id, y.Name }),
                    Planets = x.Planets.Select(y => new { y.Id, y.Name }),
                    Vehicles = x.Vehicles.Select(y => new { y.Id, y.Name }),
                    Spaceships = x.Spaceships.Select(y => new { y.Id, y.Name })
                }).FirstOrDefaultAsync();
    }
}