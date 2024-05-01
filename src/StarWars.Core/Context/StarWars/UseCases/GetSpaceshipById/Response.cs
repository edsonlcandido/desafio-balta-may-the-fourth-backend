using StarWars.Core.Context.StarWars.UseCases.GetFilmById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Core.Context.StarWars.UseCases.GetSpaceshipById
{
    public class Response : Shared.UseCases.Response
    {
        public ResponseData? Data { get; set; }
        public Response(int status, string message, ResponseData data)
        {
            Status = status;
            Message = message;
            Data = data;
        }

        public Response(int status, string message)
        {
            Status = status;
            Message = message;
        }
    }

    public class ResponseData
    {
        public string Name { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;
        public string CostInCredits { get; set; } = string.Empty;
        public string Length { get; set; } = string.Empty;
        public string MaxSpeed { get; set; } = string.Empty;
        public string Crew { get; set; } = string.Empty;
        public string Passengers { get; set; } = string.Empty;
        public string CargoCapacity { get; set; } = string.Empty;
        public string Consumables { get; set; } = string.Empty;
        public string HyperdriveRating { get; set; } = string.Empty;
        public string MGLT { get; set; } = string.Empty;
        public string Class { get; set; } = string.Empty;
        public IEnumerable<dynamic> Movies { get; set; } = [];
    }
}
