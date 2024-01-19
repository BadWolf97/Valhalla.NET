using System.Text.Json.Serialization;
using FPH.ValhallaNET.Enums;

namespace FPH.ValhallaNET.Models
{
    // A class to represent the trip information
    public class Trip
    {
        [JsonPropertyName("language")]
        public string? Language { get; set; } // The language code for the directions text

        [JsonPropertyName("status")]
        public int? Status { get; set; } // The status code for the route request: 0 - success, 1 - failure

        [JsonPropertyName("units")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Unit? Units { get; set; } // The units to use for distance and speed

        [JsonPropertyName("id")]
        public string? Id { get; set; } // The id of the route request

        [JsonPropertyName("locations")]
        public Location[]? Locations { get; set; } // The locations used for routing

        [JsonPropertyName("summary")]
        public RouteSummary? Summary { get; set; } // The summary of the route

        [JsonPropertyName("legs")]
        public RouteLeg[]? Legs { get; set; } // The legs of the route

        [JsonPropertyName("status_message")]
        public string? StatusMessage { get; set; } // The status message for the route request
    }
}
