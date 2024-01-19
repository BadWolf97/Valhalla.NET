using System.Text.Json.Serialization;

namespace FPH.ValhallaNET.Models
{
    // A class to represent a polygon to avoid on the route
    public class Polygon
    {
        [JsonPropertyName("type")]
        public const string Type = "Polygon"; // The type of the polygon, must be "Polygon"

        [JsonPropertyName("coordinates")]
        public required double[][] Coordinates { get; set; } // The coordinates of the polygon vertices in the format [[[lon1, lat1], [lon2, lat2], ...]]
    }
}
