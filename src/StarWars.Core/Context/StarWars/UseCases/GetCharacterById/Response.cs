using StarWars.Core.Context.StarWars.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Core.Context.StarWars.UseCases.GetCharacterById
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
        public string Height { get; set; } = string.Empty;
        public string Weight { get; set; } = string.Empty;
        public string HairColor { get; set; } = string.Empty;
        public string SkinColor { get; set; } = string.Empty;
        public string EyeColor { get; set; } = string.Empty;
        public string BirthYear { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        //public int PlanetId { get; set; }
        //public Planet Planet { get; set; } = null!;

        //public dynamic Planet { get; set; } = null!;
        public IEnumerable<dynamic> Films { get; set; } = [];




    }
}
