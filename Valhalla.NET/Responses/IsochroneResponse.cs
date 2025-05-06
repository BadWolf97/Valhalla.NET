// ----------------------------------------------------------------------------
// <copyright file="IsochroneResponse.cs" company="Freie Programme Hohenstein">
// Copyright (c) Freie Programme Hohenstein.
// Licensed under Apache-2.0 license. See LICENSE file in the project root for full license information.
// </copyright>
// ----------------------------------------------------------------------------

using System.Text.Json;
using System.Text.Json.Serialization;
using FPH.ValhallaNET.Converters;
using FPH.ValhallaNET.Models;

namespace FPH.ValhallaNET.Responses
{
    /// <summary>
    /// Represents the response of an isochrone request.
    /// </summary>
    public class IsochroneResponse
    {
        /// <summary>
        /// Gets or sets the type of the response. This should be "FeatureCollection".
        /// </summary>
        [JsonPropertyName("type")]
        public required string Type { get; set; }

        /// <summary>
        /// Gets or sets the features of the isochrone.
        /// </summary>
        [JsonPropertyName("features")]
        public List<GeometryFeature>? Features { get; set; }

        /// <summary>
        /// Deserializes the response from JSON.
        /// </summary>
        /// <param name="json">The JSON string to deserialize.</param>
        /// <returns>The deserialized <see cref="IsochroneResponse"/> object.</returns>
        public static IsochroneResponse? FromJson(string json)
        {
            var options = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase), new GeometryJsonConverter() },
            };
            try
            {
                return JsonSerializer.Deserialize<IsochroneResponse>(json, options);
            }
            catch
            {
                throw;
            }
        }
    }
}
