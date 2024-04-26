using Microsoft.EntityFrameworkCore;
using StarWars.Core.Context.StarWars.Entities;
using StarWars.Infra.Context.StarWars.Mappings;

namespace StarWars.Infra.Data;

public class AppDbContext : DbContext
{
    public DbSet<Film> Films { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<Planet> Planets { get; set; }
    public DbSet<Spaceship> Spaceships { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new FilmMap());
    }
}