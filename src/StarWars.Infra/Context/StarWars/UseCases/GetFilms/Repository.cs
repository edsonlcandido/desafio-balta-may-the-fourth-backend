using Microsoft.EntityFrameworkCore;
using StarWars.Core.Context.StarWars.Entities;
using StarWars.Core.Context.StarWars.UseCases.GetFilms;
using StarWars.Core.Context.StarWars.UseCases.GetFilms.Contracts;
using StarWars.Infra.Data;

namespace StarWars.Infra.Context.StarWars.UseCases.GetFilms
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ResponseData>> GetFilmsAsync(CancellationToken cancellationToken)
        {
            return await _context.Films
                .AsNoTracking()
                .Include(x => x.Characters)
                .Include(x => x.Planets)
                .Include(x => x.Vehicles)
                .Include(x => x.Spaceships)
                .Select<Film, ResponseData>(x => new ResponseData 
                {
                    Title = x.Title,
                    Episode = x.Episode,
                    OpeningCrawl = x.OpeningCrawl,
                    Director = x.Director,
                    Producer = x.Producer,
                    ReleaseDate = x.ReleaseDate,
                    Characters = x.Characters.Select(y => new { y.Id, y.Name }),
                    Planets = x.Planets.Select(y => new {Id = y.Id, Title = y.Name }),
                    Vehicles = x.Vehicles.Select(y => new { y.Id, y.Name }),
                    Starships = x.Spaceships.Select(y => new { y.Id, y.Name })
                }).ToListAsync();
        }
    }
}