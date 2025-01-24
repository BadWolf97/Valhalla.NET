// ----------------------------------------------------------------------------
// <copyright file="TransitInfo.cs" company="Freie Programme Hohenstein">
// Copyright (c) Freie Programme Hohenstein.
// Licensed under Apache-2.0 license. See LICENSE file in the project root for full license information.
// </copyright>
// ----------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace FPH.ValhallaNET.Models
{
    /// <summary>
    /// A class to represent the transit information.
    /// </summary>
    public class TransitInfo
    {
        /// <summary>
        /// Gets or sets the Global transit route identifier.
        /// </summary>
        [JsonPropertyName("onestop_id")]
        public string? OnestopId { get; set; }

        /// <summary>
        /// Gets or sets the short name describing the transit route. For example "N".
        /// </summary>
        [JsonPropertyName("short_name")]
        public string? ShortName { get; set; }

        /// <summary>
        /// Gets or sets the long name describing the transit route. For example "Broadway Express".
        /// </summary>
        [JsonPropertyName("long_name")]
        public string? LongName { get; set; }

        /// <summary>
        /// Gets or sets the sign on a public transport vehicle that identifies the route destination to passengers. For example "ASTORIA - DITMARS BLVD".
        /// </summary>
        [JsonPropertyName("headsign")]
        public string? Headsign { get; set; }

        /// <summary>
        /// Gets or sets the numeric color value associated with a transit route.
        /// </summary>
        [JsonPropertyName("color")]
        public int? Color { get; set; }

        /// <summary>
        /// Gets or sets the numeric color value associated with the text of a transit route.
        /// </summary>
        [JsonPropertyName("text_color")]
        public int? TextColor { get; set; }

        /// <summary>
        /// Gets or sets the description of the transit route. For example "Trains operate from Ditmars Boulevard, Queens, to Stillwell Avenue, Brooklyn, at all times. N trains in Manhattan operate along Broadway and across the Manhattan Bridge to and from Brooklyn. Trains in Brooklyn operate along 4th Avenue, then through Borough Park to Gravesend. Trains typically operate local in Queens, and either express or local in Manhattan and Brooklyn, depending on the time. Late night trains operate via Whitehall Street, Manhattan. Late night service is local".
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the Global operator/agency identifier.
        /// </summary>
        [JsonPropertyName("operator_onestop_id")]
        public string? OperatorOnestopId { get; set; }

        /// <summary>
        /// Gets or sets the Operator/agency name. For example, "BART", "King County Marine Division", and so on. Short name is used over long name.
        /// </summary>
        [JsonPropertyName("operator_name")]
        public string? OperatorName { get; set; }

        /// <summary>
        /// Gets or sets the Operator/agency URL. For example, "http://web.mta.info/".
        /// </summary>
        [JsonPropertyName("operator_url")]
        public string? OperatorUrl { get; set; }

        /// <summary>
        /// Gets or sets a list of the stops/stations associated with a specific transit route. See below for details.
        /// </summary>
        [JsonPropertyName("transit_stops")]
        public TransitStop[]? TransitStops { get; set; }
    }
}