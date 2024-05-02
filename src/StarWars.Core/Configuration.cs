using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Core;

public static class Configuration
{
    public static DatabaseConfiguration Database { get; set; } = new();
    public static CorsConfiguration Cors { get; set; } = new();
    
    public class DatabaseConfiguration
    {
        public string ConnectionString { get; set; } = string.Empty;
    }

    public class CorsConfiguration
    {
        public string CorsPolicyName { get; set; } = string.Empty;
        public string BackendUrl { get; set; } = string.Empty;
        public string FrontendUrl { get; set; } = string.Empty;
    }
}