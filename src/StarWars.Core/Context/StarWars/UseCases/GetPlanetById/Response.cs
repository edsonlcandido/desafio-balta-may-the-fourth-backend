namespace StarWars.Core.Context.StarWars.UseCases.GetPlanetById;

public class Response : Shared.UseCases.Response
{
    public ResponseData? Data { get; set; }

    public Response(int status, string message)
    {
        Status = status;
        Message = message;
    }

    public Response(int status, string message, ResponseData data)
    {
        Status = status;
        Message = message;
        Data = data;        
    }
}

public class ResponseData
{
    public string Name { get; set; } = string.Empty;
    public string RotationPeriod { get; set; } = string.Empty;        
    public string OrbitalPeriod { get; set; } = string.Empty;
    public string Diameter { get; set; } = string.Empty;
    public string Climate { get; set; } = string.Empty;
    public string Gravity { get; set; } = string.Empty;
    public string Terrain { get; set; } = string.Empty;
    public string SurfaceWater { get; set; } = string.Empty;
    public string Population { get; set; } = string.Empty;
    public IEnumerable<dynamic> Characters { get; set; } = [];
    public IEnumerable<dynamic> Movies { get; set; } = [];
}