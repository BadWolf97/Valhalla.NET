// ----------------------------------------------------------------------------
// <copyright file="Geometry.cs" company="Freie Programme Hohenstein">
// Copyright (c) Freie Programme Hohenstein.
// Licensed under Apache-2.0 license. See LICENSE file in the project root for full license information.
// </copyright>
// ----------------------------------------------------------------------------

using System.Text.Json;
using System.Text.Json.Serialization;
using FPH.ValhallaNET.Enums;

namespace FPH.ValhallaNET.Models
{
    /// <summary>
    /// A class to represent a geometry.
    /// </summary>
    public class Geometry
    {
        /// <summary>
        /// Gets or sets the type of the geometry. Can be "LineString", "Polygon", or "MultiPolygon".
        /// </summary>
        [JsonPropertyName("type")]
        public required GeometryType Type { get; set; }

        /// <summary>
        /// Gets or sets the coordinates of the polygon vertices. The first and last coordinates must be the same to close the polygon. The coordinates are in the format [[[lon1, lat1], [lon2, lat2], ...]].
        /// </summary>
        [JsonPropertyName("coordinates")]
        public required List<List<List<double[]>>> Coordinates { get; set; }
    }
}
