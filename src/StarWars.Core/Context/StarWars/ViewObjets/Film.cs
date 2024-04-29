using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarWars.Core.Context.Shared.ViewObjects;

namespace StarWars.Core.Context.StarWars.ViewObjets;

public class Film: ViewObjects
{
    public int Id { get; set; } = 0;
    public string Title { get; set; } = string.Empty;
    public string Episode { get; set; } = string.Empty;
    public string OpeningCrawl { get; set; } = string.Empty;
    public string Director { get; set; } = string.Empty;
    public string Producer { get; set; } = string.Empty;
    public string ReleaseDate { get; set; } = string.Empty;
}