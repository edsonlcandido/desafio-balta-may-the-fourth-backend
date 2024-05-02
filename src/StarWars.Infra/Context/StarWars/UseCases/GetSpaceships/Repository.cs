using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarWars.Core.Context.StarWars.Entities;
using StarWars.Core.Context.StarWars.UseCases.GetSpaceships;
using StarWars.Core.Context.StarWars.UseCases.GetSpaceships.Contracts;
using StarWars.Infra.Data;

namespace StarWars.Infra.Context.StarWars.UseCases.GetSpaceships
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<ResponseData>> GetStarshipsAsync(CancellationToken cancellationToken)
        {
            return await _context.Spaceships
                .AsNoTracking()
                .Include(x => x.Films)
                .Select<Spaceship, ResponseData>(x => new ResponseData
                {
                    Name = x.Name,
                    Model = x.Model,
                    Manufacturer = x.Manufacturer,
                    CostInCredits = x.CostInCredits,
                    Length = x.Length,
                    MaxSpeed = x.MaxSpeed,
                    Crew = x.Crew,
                    Passengers = x.Passengers,
                    CargoCapacity = x.CargoCapacity,
                    Consumables = x.Consumables,
                    HyperdriveRating = x.HyperdriveRating,
                    MGLT = x.MGLT,
                    Class = x.Class,
                    Movies = x.Films.Select(y=> new {y.Id, y.Title})
                }).ToListAsync();
        }
    }
}
