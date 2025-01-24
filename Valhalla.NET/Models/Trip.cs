// ----------------------------------------------------------------------------
// <copyright file="Trip.cs" company="Freie Programme Hohenstein">
// Copyright (c) Freie Programme Hohenstein.
// Licensed under Apache-2.0 license. See LICENSE file in the project root for full license information.
// </copyright>
// ----------------------------------------------------------------------------

using System.Text.Json.Serialization;
using FPH.ValhallaNET.Enums;

namespace FPH.ValhallaNET.Models
{
    /// <summary>
    /// A class to represent the trip information.
    /// </summary>
    public class Trip
    {
        /// <summary>
        /// Gets or sets the status of the route request.
        /// </summary>
        [JsonPropertyName("status")]
        public int? Status { get; set; }

        /// <summary>
        /// Gets or sets the status message of the route request.
        /// </summary>
        [JsonPropertyName("status_message")]
        public string? StatusMessage { get; set; }

        /// <summary>
        /// Gets or sets the specified units of length.
        /// </summary>
        [JsonPropertyName("units")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Unit? Units { get; set; }

        /// <summary>
        /// Gets or sets the language of the narration instructions. If the user specified a language in the directions options and the specified language was supported - this returned value will be equal to the specified value. Otherwise, this value will be the default (en-US) language.
        /// </summary>
        [JsonPropertyName("language")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public LanguageTag? Language { get; set; }

        /// <summary>
        /// Gets or sets the Id of the route request if set.
        /// </summary>
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the locations used for routing. Location information is returned in the same form as it is entered with additional fields to indicate the side of the street.
        /// </summary>
        [JsonPropertyName("locations")]
        public Location[]? Locations { get; set; }

        /// <summary>
        /// Gets or sets the summary of the route.
        /// </summary>
        [JsonPropertyName("summary")]
        public RouteSummary? Summary { get; set; }

        /// <summary>
        /// Gets or sets the legs of the route.
        /// </summary>
        [JsonPropertyName("legs")]
        public RouteLeg[]? Legs { get; set; }
    }
}
