using Microsoft.EntityFrameworkCore;
using StarWars.Core.Context.StarWars.Entities;
using StarWars.Core.Context.StarWars.UseCases.GetCharacters;
using StarWars.Core.Context.StarWars.UseCases.GetCharacters.Contracts;
using StarWars.Infra.Data;

namespace StarWars.Infra.Context.StarWars.UseCases.GetCharacters
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ResponseData>> GetCharactersAsync(CancellationToken cancellationToken)
        {
            return await _context.Characters
                .AsNoTracking()
                .Include(x => x.Films)
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
                    Films = x.Films.Select(y => new { y.Id, y.Title })

                }).ToListAsync();
        }
    }
}

