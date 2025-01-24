// ----------------------------------------------------------------------------
// <copyright file="RouteSummary.cs" company="Freie Programme Hohenstein">
// Copyright (c) Freie Programme Hohenstein.
// Licensed under Apache-2.0 license. See LICENSE file in the project root for full license information.
// </copyright>
// ----------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace FPH.ValhallaNET.Models
{
    /// <summary>
    /// A class to represent the summary of the route.
    /// </summary>
    public class RouteSummary
    {
        /// <summary>
        /// Gets or sets the total time of the route in seconds.
        /// </summary>
        [JsonPropertyName("time")]
        public double? Time { get; set; }

        /// <summary>
        /// Gets or sets the total length of the route in kilometers or miles.
        /// </summary>
        [JsonPropertyName("length")]
        public double? Length { get; set; }

        /// <summary>
        /// Gets or sets if the Path uses one or more toll segments.
        /// </summary>
        [JsonPropertyName("has_toll")]
        public bool? HasToll { get; set; }

        /// <summary>
        /// Gets or sets if the Path uses one or more highway segments.
        /// </summary>
        [JsonPropertyName("has_highway")]
        public bool? HasHighway { get; set; }

        /// <summary>
        /// Gets or sets if the Path uses one or more ferry segments.
        /// </summary>
        [JsonPropertyName("has_ferry")]
        public bool? HasFerry { get; set; }

        /// <summary>
        /// Gets or sets the minimum latitude of the route.
        /// </summary>
        [JsonPropertyName("min_lat")]
        public double? MinLat { get; set; }

        /// <summary>
        /// Gets or sets the minimum longitude of the route.
        /// </summary>
        [JsonPropertyName("min_lon")]
        public double? MinLon { get; set; }

        /// <summary>
        /// Gets or sets the maximum latitude of the route.
        /// </summary>
        [JsonPropertyName("max_lat")]
        public double? MaxLat { get; set; }

        /// <summary>
        /// Gets or sets the maximum longitude of the route.
        /// </summary>
        [JsonPropertyName("max_lon")]
        public double? MaxLon { get; set; }
    }
}
