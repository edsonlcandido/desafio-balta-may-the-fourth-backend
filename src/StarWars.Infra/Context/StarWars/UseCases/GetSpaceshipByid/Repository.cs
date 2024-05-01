using Microsoft.EntityFrameworkCore;
using StarWars.Core.Context.StarWars.Entities;
using StarWars.Core.Context.StarWars.UseCases.GetSpaceshipById;
using StarWars.Core.Context.StarWars.UseCases.GetSpaceshipById.Contract;
using StarWars.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Infra.Context.StarWars.UseCases.GetSpaceshipByid
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseData?> GetStarshipByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Spaceships
                .AsNoTracking()
                .Include(x => x.Films)
                .Where(x => x.Id == id)
                .Select<Spaceship, ResponseData>(x=> new ResponseData
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
                    Films = x.Films.Select(y => new { y.Id, y.Title})
                }).FirstOrDefaultAsync();
        }
    }
}
