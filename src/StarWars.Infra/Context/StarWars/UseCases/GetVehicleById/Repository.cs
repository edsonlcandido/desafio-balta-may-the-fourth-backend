using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarWars.Core.Context.StarWars.Entities;
using StarWars.Core.Context.StarWars.UseCases.GetVehicleById.Contracts;
using StarWars.Infra.Data;

namespace StarWars.Infra.Context.StarWars.UseCases.GetVehicleById;

public class Repository : IRepository
{
    private readonly AppDbContext _context;
    public Repository(AppDbContext context) => _context = context;
    
    public async Task<Vehicle?> GetVehicleById(int id, CancellationToken cancellationToken) =>
        await _context.Vehicles.AsNoTracking().Include(x => x.Films).Where(x => x.Id == id).FirstOrDefaultAsync();        
}