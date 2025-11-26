// ----------------------------------------------------------------------------
// <copyright file="SearchFilter.cs" company="Freie Programme Hohenstein">
// Copyright (c) Freie Programme Hohenstein.
// Licensed under Apache-2.0 license. See LICENSE file in the project root for full license information.
// </copyright>
// ----------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace FPH.ValhallaNET.Models
{
    /// <summary>
    /// A class to represent the search filter for the candidates.
    /// </summary>
    public class SearchFilter
    {
        /// <summary>
        /// Gets or sets whether to exclude roads marked as tunnels. Defaults to false.
        /// </summary>
        [JsonPropertyName("exclude_tunnel")]
        public bool? ExcludeTunnel { get; set; }

        /// <summary>
        /// Gets or sets whether to exclude roads marked as bridges. Defaults to false.
        /// </summary>
        [JsonPropertyName("exclude_bridge")]
        public bool? ExcludeBridge { get; set; }

        /// <summary>
        /// Gets or sets whether to exclude roads marked as toll roads. Defaults to false.
        /// </summary>
        [JsonPropertyName("exclude_toll")]
        public bool? ExcludeToll { get; set; }

        /// <summary>
        /// Gets or sets whether to exclude ferries. Defaults to false.
        /// </summary>
        [JsonPropertyName("exclude_ferry")]
        public bool? ExcludeFerry { get; set; }

        /// <summary>
        /// Gets or sets whether to exclude link roads marked as ramps, note that some turn channels are also marked as ramps. Defaults to false.
        /// </summary>
        [JsonPropertyName("exclude_ramp")]
        public bool? ExcludeRamp { get; set; }

        /// <summary>
        /// Gets or sets wheather to exclude roads considered closed due to live traffic closure. Defaults to true.
        /// </summary>
        /// <remarks>This option cannot be set if costing_options.{costing}.ignore_closures is also specified. An error is returned if both options are specified.\nIgnoring closures at destination and source locations does NOT work for date_time type 0/1 + 2 respectively.</remarks>
        [JsonPropertyName("exclude_closures")]
        public bool? ExcludeClosures { get; set; }

        /// <summary>
        /// Gets or sets the minimum road class to consider when filtering the candidates. Defaults to "service_other".
        /// </summary>
        /// <remarks>Road classes from highest to lowest are: motorway, trunk, primary, secondary, tertiary, unclassified, residential, service_other.</remarks>
        [JsonPropertyName("min_road_class")]
        public string? MinRoadClass { get; set; }

        /// <summary>
        /// Gets or sets the maximum road class to consider when filtering the candidates. Defaults to "motorway".
        /// </summary>
        /// <remarks>Road classes from highest to lowest are: motorway, trunk, primary, secondary, tertiary, unclassified, residential, service_other.</remarks>
        [JsonPropertyName("max_road_class")]
        public string? MaxRoadClass { get; set; }

        /// <summary>
        /// Gets or sets, if specified, will only consider edges that are on or traverse the passed floor level. It will set search_cutoff to a default value of 300 meters if no cutoff value is passed. Additionally, if a search_cutoff is passed, it will be clamped to 1000 meters.
        /// </summary>
        [JsonPropertyName("level")]
        public float? Level { get; set; }
    }
}
