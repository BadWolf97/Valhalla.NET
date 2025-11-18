// ----------------------------------------------------------------------------
// <copyright file="TimeDistance.cs" company="Freie Programme Hohenstein">
// Copyright (c) Freie Programme Hohenstein.
// Licensed under Apache-2.0 license. See LICENSE file in the project root for full license information.
// </copyright>
// ----------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace FPH.ValhallaNET.Responses
{
    /// <summary>
    /// A class to represent a time-distance element for the matrix response.
    /// </summary>
    public class TimeDistance
    {
        /// <summary>
        /// Gets or sets the time in seconds.
        /// </summary>
        [JsonPropertyName("time")]
        public double? Time { get; set; }

        /// <summary>
        /// Gets or sets the distance in meters.
        /// </summary>
        [JsonPropertyName("distance")]
        public double? Distance { get; set; }

        /// <summary>
        /// Gets or sets the location of the source in the original request.
        /// </summary>
        [JsonPropertyName("to_index")]
        public int ToIndex { get; set; }

        /// <summary>
        /// Gets or sets the location of the target in the original request.
        /// </summary>
        [JsonPropertyName("from_index")]
        public int FromIndex { get; set; }

        /// <summary>
        /// Gets or sets the date and time from the matrix request.
        /// </summary>
        [JsonPropertyName("date_time")]
        public string? DateTime { get; set; }

        /// <summary>
        /// Gets or sets the time zone offset.
        /// </summary>
        [JsonPropertyName("time_zone_offset")]
        public int TimeZoneOffset { get; set; }

        /// <summary>
        /// Gets or sets the time zone name.
        /// </summary>
        [JsonPropertyName("time_zone_name")]
        public string? TimeZoneName { get; set; }
    }
}
