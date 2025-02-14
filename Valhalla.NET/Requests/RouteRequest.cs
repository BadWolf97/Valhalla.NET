// ----------------------------------------------------------------------------
// <copyright file="RouteRequest.cs" company="Freie Programme Hohenstein">
// Copyright (c) Freie Programme Hohenstein.
// Licensed under Apache-2.0 license. See LICENSE file in the project root for full license information.
// </copyright>
// ----------------------------------------------------------------------------

using System.Text.Json;
using System.Text.Json.Serialization;
using FPH.ValhallaNET.Enums;
using FPH.ValhallaNET.Models;

namespace FPH.ValhallaNET.Requests
{
    /// <summary>
    /// A class to represent the request for a Valhalla route.
    /// </summary>
    public class RouteRequest
    {
        /// <summary>
        /// Gets the format of the request.
        /// </summary>
        public static readonly Format Format = Enums.Format.Json;

        /// <summary>
        /// Gets or sets the locations to visit on the route.
        /// </summary>
        [JsonPropertyName("locations")]
        public required Location[] Locations { get; set; }

        /// <summary>
        /// Gets or sets the costing model for the route.
        /// </summary>
        [JsonPropertyName("costing")]
        public required CostingModel Costing { get; set; }

        /// <summary>
        /// Gets or sets the costing options for the route.
        /// </summary>
        [JsonPropertyName("costing_options")]
        public KeyValuePair<CostingModel, CostingOptions>? CostingOptions { get; set; }

        /// <summary>
        /// Gets or sets additional costing options for the route.
        /// </summary>
        [JsonPropertyName("recostings")]
        public Dictionary<CostingModel, CostingOptions>? RecostingOptions { get; set; }

        /// <summary>
        /// Gets or sets the unit used in the route. Defaults to Kilometers.
        /// </summary>
        [JsonPropertyName("units")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Unit? Units { get; set; }

        /// <summary>
        /// Gets or sets the language code for the directions text. Defaults to English.
        /// </summary>
        [JsonPropertyName("language")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public LanguageTag? Language { get; set; }

        /// <summary>
        /// Gets or sets the verbosity of the route response. Defaults to Instructions.
        /// </summary>
        [JsonPropertyName("directions_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public DirectionsType? DirectionsType { get; set; }

        /// <summary>
        /// Gets or sets the number of alternative routes to generate.
        /// </summary>
        [JsonPropertyName("alternates")]
        public int? Alternates { get; set; }

        /// <summary>
        /// Gets or sets the locations to avoid on the route. The avoid_locations are mapped to the closest road or roads and these roads are excluded from the route path computation.
        /// </summary>
        [JsonPropertyName("exclude_locations")]
        public Location[]? AvoidLocations { get; set; }

        /// <summary>
        /// Gets or sets the polygons to avoid on the route. Roads intersecting these rings will be avoided during path finding. If you only need to avoid a few specific roads, it's much more efficient to use exclude_locations. Valhalla will close open rings (i.e. copy the first coordinate to the last position).
        /// </summary>
        [JsonPropertyName("exclude_polygons")]
        public Polygon[]? AvoidPolygons { get; set; }

        /// <summary>
        /// Gets or sets the date and time for time-dependent routing.
        /// </summary>
        [JsonPropertyName("date_time")]
        public DateTimeOptions? DateTime { get; set; }

        /// <summary>
        /// Gets or sets the Elevation interval (meters) for requesting elevation along the route. Valhalla data must have been generated with elevation data. If no elevation_interval is specified, no elevation will be returned for the route. An elevation interval of 30 meters is recommended when elevation along the route is desired, matching the default data source's resolution.
        /// </summary>
        [JsonPropertyName("elevation_interval")]
        public double? ElevationInterval { get; set; }

        /// <summary>
        /// Gets or sets the id of the route request. If id is specified, the naming will be sent thru to the response.
        /// </summary>
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets a boolean indicating whether exit instructions at roundabouts should be added to the output or not. Default is true.
        /// </summary>
        [JsonPropertyName("roundabout_exits")]
        public bool? RoundaboutExits { get; set; }

        /// <summary>
        /// Gets or sets if the successful route summary will include the two keys admins and admin_crossings. admins is an array of administrative regions the route lies within. admin_crossings is an array of objects that contain from_admin_index and to_admin_index, which are indices into the admins array. They also contain from_shape_index and to_shape_index, which are start and end indices of the edge along which an administrative boundary is crossed.
        /// </summary>
        [JsonPropertyName("admin_crossings")]
        public bool? AdminCrossings { get; set; }

        /// <summary>
        /// Gets the serialized route request to a JSON string.
        /// </summary>
        /// <returns>A Json String.</returns>
        public string ToJson()
        {
            var options = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            };
            return JsonSerializer.Serialize(this, options);
        }
    }
}
