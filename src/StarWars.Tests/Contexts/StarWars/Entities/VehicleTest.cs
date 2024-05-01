using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using StarWars.Core.Context.StarWars.Entities;
using StarWars.Core.Context.StarWars.Mappings;
using Xunit;

namespace StarWars.Tests.Contexts.StarWars.Entities
{
    public class VehicleTest
    {
        private Vehicle vehicle = new Vehicle {
                Id= 1,
                Name= "Sand Crawler",
                Model= "Digger Crawler",
                Manufacturer= "Corellia Mining Corporation",
                CostInCredits= "150000",
                Length= "36.8 ",
                MaxSpeed= "30",
                Crew= "46",
                Passengers= "30",
                CargoCapacity= "50000",
                Consumables= "2 months",
                Class= "wheeled",
                Films = new List<Film> () { new Film {
                    Id = 1,
                    Title = "A New Hope",
                    Episode = "4",
                    OpeningCrawl = "It is a period of civil war...",
                    Director = "George Lucas",
                    Producer = "Gary Kurtz, Rick McCallum",
                    ReleaseDate = "1977-05-25"}},       
            };

        [Fact]
        public void Deve_ter_id_igual_1()
        {
            Assert.Equal(1, vehicle.Id);
        }

        [Fact]
        public void Deve_ter_Um_filme()
        {
            Assert.Equal(1, vehicle.Films?.FirstOrDefault()?.Id);
        }

        [Fact]
        public void Deve_conseguir_converter_para_ViewObject()
        {
            var response = vehicle.ConvertToResponse();
            Assert.IsType<Core.Context.StarWars.ViewObjets.Vehicle>(response);
        }

         [Fact]
        public void Deve_conseguir_converter_os_objetos_referenciados()
        {
            var response = vehicle.ConvertToResponse();
            var filmes = response?.Movies?.FirstOrDefault();
            Assert.IsType<Core.Context.StarWars.ViewObjets.Film>(filmes);
        }
    }
}