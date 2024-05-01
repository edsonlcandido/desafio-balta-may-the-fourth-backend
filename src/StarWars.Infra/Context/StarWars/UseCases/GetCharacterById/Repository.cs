using Microsoft.EntityFrameworkCore;
using StarWars.Core.Context.StarWars.Entities;
using StarWars.Core.Context.StarWars.UseCases.GetCharacterById;
using StarWars.Core.Context.StarWars.UseCases.GetCharacterById.Contracts;
using StarWars.Infra.Data;

namespace StarWars.Infra.Context.StarWars.UseCases.GetCharacterById
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseData?> GetCharacterByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Characters
                .AsNoTracking()
                .Include(x => x.Films)
                .Include(x => x.Planet)
                .Where(x => x.Id == id)
                .Select<Character, ResponseData>(x => new ResponseData
                {
                    BirthYear = x.BirthYear,
                    EyeColor = x.EyeColor,
                    Gender = x.Gender,
                    HairColor = x.HairColor,
                    Height = x.Height,
                    Name = x.Name,
                    SkinColor = x.SkinColor,
                    Weight = x.Weight,
                    Planet = new { Id = x.Planet.Id, Name = x.Planet.Name },
                    Movies = x.Films.Select(y => new { y.Id, y.Title })

                }).FirstOrDefaultAsync();
        }
    }
}

