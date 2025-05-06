// ----------------------------------------------------------------------------
// <copyright file="ContourOptions.cs" company="Freie Programme Hohenstein">
// Copyright (c) Freie Programme Hohenstein.
// Licensed under Apache-2.0 license. See LICENSE file in the project root for full license information.
// </copyright>
// ----------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace FPH.ValhallaNET.Models
{
    /// <summary>
    /// A class to represent the options for a contour.
    /// </summary>
    public class ContourOptions
    {
        /// <summary>
        /// Gets or sets the time of the isochrone in minutes. Either time xor distance must be set.
        /// </summary>
        [JsonPropertyName("time")]
        public double? Time { get; set; }

        /// <summary>
        /// Gets or sets the distance of the isochrone in kilometers. Either time xor distance must be set.
        /// </summary>
        [JsonPropertyName("distance")]
        public double? Distance { get; set; }

        /// <summary>
        /// Gets or sets the color of the isochrone. Specify it as a Hex value, but without the #, such as "ff0000" for red. If no color is specified, the isochrone service will assign a default color to the output.
        /// </summary>
        [JsonPropertyName("color")]
        public string? Color { get; set; }
    }
}
