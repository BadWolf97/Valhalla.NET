// ----------------------------------------------------------------------------
// <copyright file="IsochroneRequest.cs" company="Freie Programme Hohenstein">
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
    /// A class to represent the request for an isochrone.
    /// </summary>
    public class IsochroneRequest
    {
        /// <summary>
        /// Gets or sets the locations of the isochrone request.
        /// </summary>
        [JsonPropertyName("locations")]
        public required List<Location> Locations { get; set; }

        /// <summary>
        /// Gets or sets the costing options for the route.
        /// </summary>
        [JsonPropertyName("costing")]
        public required CostingModel Costing { get; set; }

        /// <summary>
        /// Gets or sets the costing options for the route.
        /// </summary>
        [JsonPropertyName("costing_options")]
        public Dictionary<CostingModel, CostingOptions>? CostingOptions { get; set; }

        /// <summary>
        /// Gets or sets the date and time for time-dependent routing.
        /// </summary>
        [JsonPropertyName("date_time")]
        public DateTimeOptions? DateTimeOptions { get; set; }

        /// <summary>
        /// Gets or sets the contour options for the isochrone request.
        /// </summary>
        [JsonPropertyName("contours")]
        public required List<ContourOptions> Contours { get; set; }

        /// <summary>
        /// Gets or Sets a value indicating whether to return geojson polygons or linestrings as the contours. The default is false, which returns lines; when true, polygons are returned. Note: When polygons is true, a feature's geometry type can be either Polygon or MultiPolygon, depending on the number of exterior rings formed for a given interval.
        /// </summary>
        [JsonPropertyName("polygons")]
        public bool? Polygons { get; set; }

        /// <summary>
        /// Gets or Sets a floating point value from 0 to 1 (default of 1) which can be used to remove smaller contours. A value of 1 will only return the largest contour for a given time value. A value of 0.5 drops any contours that are less than half the area of the largest contour in the set of contours for that same time value.
        /// </summary>
        [JsonPropertyName("denoise")]
        public float? Denoise { get; set; }

        /// <summary>
        /// Gets or Sets a floating point value in meters used as the tolerance for Douglas-Peucker generalization. Note: Generalization of contours can lead to self-intersections, as well as intersections of adjacent contours.
        /// </summary>
        [JsonPropertyName("generalize")]
        public float? Generalize { get; set; }

        /// <summary>
        /// Gets or Sets a value indicating whether the input locations should be returned as MultiPoint features: one feature for the exact input coordinates and one feature for the coordinates of the network node it snapped to. Default false.
        /// </summary>
        [JsonPropertyName("show_locations")]
        public bool? ShowLocations { get; set; }

        /// <summary>
        /// Gets or Sets a value indicating whether to do inverse expansion of the isochrone. The reverse isochrone will show from which area the given location can be reached within the given time.
        /// </summary>
        [JsonPropertyName("reverse")]
        public bool? Reverse { get; set; }

        /// <summary>
        /// Serializes the isochrone request to a JSON string.
        /// </summary>
        /// <returns>A Json String.</returns>
        public string ToJson()
        {
            JsonSerializerOptions options = new()
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            };
            return JsonSerializer.Serialize(this, options);
        }
    }
}
