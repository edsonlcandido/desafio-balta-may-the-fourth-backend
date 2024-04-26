using StarWars.Core.Context.Shared.Entities;

namespace StarWars.Core.Context.StarWars.Entities;

public class Film : Entity
{
    public string Title { get; set; } = string.Empty;
    public string Episode { get; set; } = string.Empty;
    public string OpeningCrawl { get; set; } = string.Empty;
    public string Director { get; set; } = string.Empty;
    public string Producer { get; set; } = string.Empty;
    public string ReleaseDate { get; set; } = string.Empty;
    public List<Character> Characters { get; set; } = new();
    public List<Planet> Planets { get; set; } = new();
    public List<Vehicle> Vehicles { get; set; } = new();
    public List<Spaceship> Spaceships { get; set; } = new();
}