using System.Text.Json.Serialization;

namespace FPH.ValhallaNET.Models
{
    // A class to represent the summary of the route
    public class RouteSummary
    {
        [JsonPropertyName("max_lon")]
        public double? MaxLon { get; set; } // The maximum longitude of the route

        [JsonPropertyName("max_lat")]
        public double? MaxLat { get; set; } // The maximum latitude of the route

        [JsonPropertyName("time")]
        public double? Time { get; set; } // The total time of the route in seconds

        [JsonPropertyName("length")]
        public double? Length { get; set; } // The total length of the route in kilometers or miles

        [JsonPropertyName("min_lat")]
        public double? MinLat { get; set; } // The minimum latitude of the route

        [JsonPropertyName("min_lon")]
        public double? MinLon { get; set; } // The minimum longitude of the route
    }
}
