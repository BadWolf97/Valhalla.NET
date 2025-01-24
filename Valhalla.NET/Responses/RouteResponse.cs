// ----------------------------------------------------------------------------
// <copyright file="RouteResponse.cs" company="Freie Programme Hohenstein">
// Copyright (c) Freie Programme Hohenstein.
// Licensed under Apache-2.0 license. See LICENSE file in the project root for full license information.
// </copyright>
// ----------------------------------------------------------------------------

using System.Text.Json;
using System.Text.Json.Serialization;
using FPH.ValhallaNET.Models;

namespace FPH.ValhallaNET.Responses
{
    /// <summary>
    /// Represents the response for a route request.
    /// </summary>
    public class RouteResponse
    {
        /// <summary>
        /// Gets or sets the id of the route request if set.
        /// </summary>
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the trip information.
        /// </summary>
        [JsonPropertyName("trip")]
        public Trip? Trip { get; set; }

        /// <summary>
        /// Deserializes the response from JSON.
        /// </summary>
        /// <param name="json">The JSON string to deserialize.</param>
        /// <returns>The deserialized <see cref="RouteResponse"/> object.</returns>
        public static RouteResponse? FromJson(string json)
        {
            return JsonSerializer.Deserialize<RouteResponse>(json);
        }
    }
}
