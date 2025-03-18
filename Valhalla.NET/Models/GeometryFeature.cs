// ----------------------------------------------------------------------------
// <copyright file="GeometryFeature.cs" company="Freie Programme Hohenstein">
// Copyright (c) Freie Programme Hohenstein.
// Licensed under Apache-2.0 license. See LICENSE file in the project root for full license information.
// </copyright>
// ----------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace FPH.ValhallaNET.Models
{
    /// <summary>
    /// A class to represent a geometry feature.
    /// </summary>
    public class GeometryFeature
    {
        /// <summary>
        /// Gets or sets the Geometries of the feature.
        /// </summary>
        [JsonPropertyName("geometry")]
        public required Geometry Geometry { get; set; }

        /// <summary>
        /// Gets or sets the properties of the feature.
        /// </summary>
        [JsonPropertyName("properties")]
        public required GeometryProperties Properties { get; set; }
    }
}
