using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarWars.Core.Context.StarWars.Entities;
using StarWars.Core.Context.StarWars.UseCases.GetVehicles;

namespace StarWars.Core.Context.StarWars.Mappings;

public static class MappingEntityToResponse
{
    public  static Core.Context.StarWars.ViewObjets.Vehicle ConvertToResponse(this Vehicle vehicle) =>
        new Core.Context.StarWars.ViewObjets.Vehicle(){
            Id = vehicle.Id,
            Name = vehicle.Name,
            Model = vehicle.Model,
            Manufacturer = vehicle.Manufacturer,
            CostInCredits = vehicle.CostInCredits,
            Length = vehicle.Length,
            MaxSpeed = vehicle.MaxSpeed,
            Crew = vehicle.Crew,
            Passengers = vehicle.Passengers,
            CargoCapacity = vehicle.CargoCapacity,
            Consumables = vehicle.Consumables,
            Class = vehicle.Class,
            Films = vehicle.Films?.Select(x => x.ConvertToResponse()).ToList(),
        };                    

    public  static Core.Context.StarWars.ViewObjets.Film ConvertToResponse(this Film film) =>
        new Core.Context.StarWars.ViewObjets.Film(){             
            Id = film.Id,
            Title = film.Title,
            Episode = film.Episode,
            OpeningCrawl = film.OpeningCrawl,
            Director = film.Director,
            Producer = film.Producer,
            ReleaseDate = film.ReleaseDate 
        }; 
                  
}