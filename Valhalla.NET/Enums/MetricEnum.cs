// ----------------------------------------------------------------------------
// <copyright file="MetricEnum.cs" company="Freie Programme Hohenstein">
// Copyright (c) Freie Programme Hohenstein.
// Licensed under Apache-2.0 license. See LICENSE file in the project root for full license information.
// </copyright>
// ----------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace FPH.ValhallaNET.Enums
{
    /// <summary>
    /// Enumeration of different isochrone metrics.
    /// </summary>
    public enum MetricEnum
    {
        /// <summary>
        /// Represents a time isochrone algorithm.
        /// </summary>
        [JsonPropertyName("time")]
        Time,

        /// <summary>
        /// Represents a cost isochrone algorithm.
        /// </summary>
        [JsonPropertyName("distance")]
        Distance,
    }
}
