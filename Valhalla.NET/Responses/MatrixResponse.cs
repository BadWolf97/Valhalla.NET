// ----------------------------------------------------------------------------
// <copyright file="MatrixResponse.cs" company="Freie Programme Hohenstein">
// Copyright (c) Freie Programme Hohenstein.
// Licensed under Apache-2.0 license. See LICENSE file in the project root for full license information.
// </copyright>
// ----------------------------------------------------------------------------

using System.Text.Json;
using System.Text.Json.Serialization;
using FPH.ValhallaNET.Enums;
using FPH.ValhallaNET.Models;

namespace FPH.ValhallaNET.Responses
{/// <summary>
 /// Represents the response of a matrix request.
 /// </summary>
    public class MatrixResponse
    {
        /// <summary>
        /// Gets or sets the sources of the matrix.
        /// </summary>
        [JsonPropertyName("sources")]
        public MatrixLocation[]? Sources { get; set; }

        /// <summary>
        /// Gets or sets the targets of the matrix.
        /// </summary>
        [JsonPropertyName("targets")]
        public MatrixLocation[]? Targets { get; set; }

        /// <summary>
        /// Gets or sets the time-distance matrix from sources to targets.
        /// </summary>
        [JsonPropertyName("sources_to_targets")]
        public TimeDistance[][]? Matrix { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the matrix response.
        /// </summary>
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the algorithm used to generate the matrix.
        /// </summary>
        [JsonPropertyName("algorithm")]
        public MatrixAlgorithm? Algorithm { get; set; }

        /// <summary>
        /// Gets or sets the unit of measurement used in the matrix.
        /// </summary>
        [JsonPropertyName("units")]
        public Unit? Unit { get; set; }

        /// <summary>
        /// Gets or sets the warnings associated with the matrix response.
        /// </summary>
        [JsonPropertyName("warnings")]
        public string[]? Warnings { get; set; }

        /// <summary>
        /// Deserializes the matrix response from a JSON string.
        /// </summary>
        /// <param name="json">The JSON string representing the matrix response.</param>
        /// <returns>The deserialized <see cref="MatrixResponse"/> object.</returns>
        public static MatrixResponse? FromJson(string json)
        {
            JsonSerializerOptions options = new()
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) },
            };
            return JsonSerializer.Deserialize<MatrixResponse>(json, options);
        }
    }
}
