// ----------------------------------------------------------------------------
// <copyright file="TransitStop.cs" company="Freie Programme Hohenstein">
// Copyright (c) Freie Programme Hohenstein.
// Licensed under Apache-2.0 license. See LICENSE file in the project root for full license information.
// </copyright>
// ----------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace FPH.ValhallaNET.Models
{
    /// <summary>
    /// A class to represent a transit stop.
    /// </summary>
    public class TransitStop
    {
        /// <summary>
        /// Gets or sets the Type of stop (simple stop=0; station=1).
        /// </summary>
        [JsonPropertyName("type")]
        public int? Type { get; set; }

        /// <summary>
        /// Gets or sets the name of the stop or station. For example "14 St - Union Sq".
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the arrival date and time at the stop or station using the ISO 8601 format (YYYY-MM-DDThh:mm). For example, "2015-12-29T08:06".
        /// </summary>
        [JsonPropertyName("arrival_date_time")]
        public string? ArrivalDateTime { get; set; }

        /// <summary>
        /// Gets or sets the departure date and time at the stop or station using the ISO 8601 format (YYYY-MM-DDThh:mm). For example, "2015-12-29T08:06".
        /// </summary>
        [JsonPropertyName("departure_date_time")]
        public string? DepartureDateTime { get; set; }

        /// <summary>
        /// Gets or sets True if this stop is a marked as a parent stop.
        /// </summary>
        [JsonPropertyName("is_parent_stop")]
        public bool? IsParentStop { get; set; }

        /// <summary>
        /// Gets or sets True if the times are based on an assumed schedule because the actual schedule is not known.
        /// </summary>
        [JsonPropertyName("assumed_schedule")]
        public bool? AssumedSchedule { get; set; }

        /// <summary>
        /// Gets or sets the latitude of the stop or station in degrees.
        /// </summary>
        [JsonPropertyName("lat")]
        public double? Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude of the stop or station in degrees.
        /// </summary>
        [JsonPropertyName("lon")]
        public double? Longitude { get; set; }
    }
}