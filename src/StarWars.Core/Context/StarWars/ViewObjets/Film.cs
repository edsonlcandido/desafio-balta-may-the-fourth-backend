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
}