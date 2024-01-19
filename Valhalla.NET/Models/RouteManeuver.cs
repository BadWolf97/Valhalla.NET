using System.Text.Json.Serialization;

namespace FPH.ValhallaNET.Models
{
    // A class to represent a maneuver of the leg
    public class RouteManeuver
    {
        [JsonPropertyName("begin_shape_index")]
        public int? BeginShapeIndex { get; set; } // The index of the first shape point of the maneuver

        [JsonPropertyName("distance")]
        public double? Distance { get; set; } // The distance of the maneuver in kilometers or miles

        [JsonPropertyName("instruction")]
        public string? Instruction { get; set; } // The instruction text for the maneuver

        [JsonPropertyName("end_shape_index")]
        public int? EndShapeIndex { get; set; } // The index of the last shape point of the maneuver

        [JsonPropertyName("time")]
        public double? Time { get; set; } // The time of the maneuver in seconds

        [JsonPropertyName("type")]
        public int? Type { get; set; } // The type of the maneuver

        [JsonPropertyName("street_names")]
        public string[]? StreetNames { get; set; } // The street names of the maneuver
    }
}
