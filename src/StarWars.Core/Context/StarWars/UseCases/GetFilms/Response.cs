namespace StarWars.Core.Context.StarWars.UseCases.GetFilms;

public class Response : Shared.UseCases.Response
{
    public List<ResponseData> Data { get; set; } = [];

    public Response(int status, string message, List<ResponseData> data)
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
    public string Title { get; set; } = string.Empty;
    public string Episode { get; set; } = string.Empty;
    public string OpeningCrawl { get; set; } = string.Empty;
    public string Director { get; set; } = string.Empty;
    public string Producer { get; set; } = string.Empty;
    public string ReleaseDate { get; set; } = string.Empty;
    public IEnumerable<dynamic> Characters { get; set;} = [];
    public IEnumerable<dynamic> Planets { get; set; } = [];
    public IEnumerable<dynamic> Vehicles { get; set; } = [];
    public IEnumerable<dynamic> Spaceships { get; set; } = [];
}