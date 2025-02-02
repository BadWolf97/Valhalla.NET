﻿// ----------------------------------------------------------------------------
// <copyright file="Polygon.cs" company="Freie Programme Hohenstein">
// Copyright (c) Freie Programme Hohenstein.
// Licensed under Apache-2.0 license. See LICENSE file in the project root for full license information.
// </copyright>
// ----------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace FPH.ValhallaNET.Models
{
    /// <summary>
    /// A class to represent a polygon to avoid on the route.
    /// </summary>
    public class Polygon
    {
        /// <summary>
        /// The type of the polygon, must be "Polygon".
        /// </summary>
        [JsonPropertyName("type")]
        public const string Type = "Polygon";

        /// <summary>
        /// Gets or sets the coordinates of the polygon vertices in the format [[[lon1, lat1], [lon2, lat2], ...]].
        /// </summary>
        [JsonPropertyName("coordinates")]
        public required double[][] Coordinates { get; set; }
    }
}
