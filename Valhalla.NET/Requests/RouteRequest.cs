using System.Text.Json.Serialization;
using System.Text.Json;
using FPH.ValhallaNET.Enums;
using FPH.ValhallaNET.Models;

namespace FPH.ValhallaNET.Requests
{
    // A class to represent the request for a Valhalla route
    public class RouteRequest
    {
        [JsonPropertyName("locations")]
        public required Location[] Locations { get; set; } // An array of locations to visit on the route

        [JsonPropertyName("costing")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public required CostingModel Costing { get; set; } // The costing model to use for routing

        [JsonPropertyName("costing_options")]
        public CostingOptions? CostingOptions { get; set; } // The options for the costing model

        [JsonPropertyName("units")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Unit? Units { get; set; } // The units to use for distance and speed

        [JsonPropertyName("id")]
        public string? Id { get; set; } // An optional name for the route request

        [JsonPropertyName("directions_options")]
        public DirectionsOptions? DirectionsOptions { get; set; } // The options for the directions output

        [JsonPropertyName("date_time")]
        public DateTimeOptions? DateTime { get; set; } // The options for time-dependent routing

        [JsonPropertyName("filters")]
        public FilterOptions? Filters { get; set; } // The options for filtering the route by attributes

        [JsonPropertyName("avoid_locations")]
        public Location[]? AvoidLocations { get; set; } // An array of locations to avoid on the route

        [JsonPropertyName("avoid_polygons")]
        public Polygon[]? AvoidPolygons { get; set; } // An array of polygons to avoid on the route

        [JsonPropertyName("alternates")]
        public int? Alternates { get; set; } // The number of alternate routes to return

        // A method to serialize the request to JSON
        public string ToJson()
        {
            var options = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
            return JsonSerializer.Serialize(this, options);
        }
    }
}
