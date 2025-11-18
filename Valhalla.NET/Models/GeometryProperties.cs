// ----------------------------------------------------------------------------
// <copyright file="GeometryProperties.cs" company="Freie Programme Hohenstein">
// Copyright (c) Freie Programme Hohenstein.
// Licensed under Apache-2.0 license. See LICENSE file in the project root for full license information.
// </copyright>
// ----------------------------------------------------------------------------

using System.Text.Json.Serialization;
using FPH.ValhallaNET.Enums;

namespace FPH.ValhallaNET.Models
{
    /// <summary>
    /// A class to represent the properties of a geometry.
    /// </summary>
    public class GeometryProperties
    {
        /// <summary>
        /// Gets or sets the fill opacity of the geometry.
        /// </summary>
        [JsonPropertyName("fill-opacity")]
        public float? FillOpacity { get; set; }

        /// <summary>
        /// Gets or sets the fill color of the geometry.
        /// </summary>
        [JsonPropertyName("fillColor")]
        public string? FillColor { get; set; }

        /// <summary>
        /// Gets or sets the stroke opacity of the geometry.
        /// </summary>
        [JsonPropertyName("opacity")]
        public float? Opacity { get; set; }

        /// <summary>
        /// Gets or sets the stroke width of the geometry.
        /// </summary>
        [JsonPropertyName("fill")]
        public string? Fill { get; set; }

        /// <summary>
        /// Gets or sets the stroke color of the geometry.
        /// </summary>
        [JsonPropertyName("color")]
        public string? Color { get; set; }

        /// <summary>
        /// Gets or sets the contour time or distance.
        /// </summary>
        [JsonPropertyName("contour")]
        public float Contour { get; set; }

        /// <summary>
        /// Gets or sets the metric of the contour.
        /// </summary>
        [JsonPropertyName("metric")]
        public MetricEnum Metric { get; set; }
    }
}
