using System.Text.Json.Serialization;
using FPH.ValhallaNET.Enums;

namespace FPH.ValhallaNET.Models
{
    // A class to represent a location for routing
    public class Location
    {
        [JsonPropertyName("lat")]
        public required double Latitude { get; set; } // Latitude in degrees

        [JsonPropertyName("lon")]
        public required double Longitude { get; set; } // Longitude in degrees

        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public LocationType? Type { get; set; } // Type of location: break, through, via or break_through

        [JsonPropertyName("street")]
        public string? Street { get; set; } // Optional street name to improve navigation

        [JsonPropertyName("city")]
        public string? City { get; set; } // Optional city name to improve navigation

        [JsonPropertyName("state")]
        public string? State { get; set; } // Optional state name to improve navigation

        [JsonPropertyName("postal_code")]
        public string? PostalCode { get; set; } // Optional postal code to improve navigation

        [JsonPropertyName("country")]
        public string? Country { get; set; } // Optional country name to improve navigation

        [JsonPropertyName("date_time")]
        public string? DateTime { get; set; } // Optional date and time for time-dependent routing. Format: YYYY-MM-DDTHH:mm

        [JsonPropertyName("heading")]
        public double? Heading { get; set; } // Optional heading in degrees for the location. Used to influence the direction of travel.

        [JsonPropertyName("heading_tolerance")]
        public double? HeadingTolerance { get; set; } // Optional heading tolerance in degrees for the location. Used to influence the direction of travel.

        [JsonPropertyName("node_snap_tolerance")]
        public double? NodeSnapTolerance { get; set; } // Optional node snap tolerance in meters for the location. Used to snap to a nearby node.

        [JsonPropertyName("way_id")]
        public long? WayId { get; set; } // Optional way id for the location. Used to snap to a specific way.

        [JsonPropertyName("minimum_reachability")]
        public int? MinimumReachability { get; set; } // Optional minimum number of nodes reachable for the location. Used to validate the location.

        [JsonPropertyName("radius")]
        public double? Radius { get; set; } // Optional radius in meters for the location. Used to limit the search area.

        [JsonPropertyName("rank_candidates")]
        public bool? RankCandidates { get; set; } // Optional flag to rank the candidates for the location. Used to return the best match.

        [JsonPropertyName("preferred_side")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SideOfStreet? PreferredSide { get; set; } // Optional preferred side of street for the location. Used to influence the side of street.

        [JsonPropertyName("side_of_street")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SideOfStreet? SideOfStreet { get; set; } // Optional side of street for the location. Used to snap to a specific side of street.

        [JsonPropertyName("search_cutoff")]
        public int? SearchCutoff { get; set; } // Optional search cutoff in seconds for the location. Used to limit the search time.

        [JsonPropertyName("street_side_tolerance")]
        public double? StreetSideTolerance { get; set; } // Optional street side tolerance in meters for the location. Used to influence the side of street.

        [JsonPropertyName("search_filter")]
        public SearchFilter? SearchFilter { get; set; } // Optional search filter for the location. Used to filter the candidates by categories or attributes.
    }
}
