// ----------------------------------------------------------------------------
// <copyright file="MatrixRequest.cs" company="Freie Programme Hohenstein">
// Copyright (c) Freie Programme Hohenstein.
// Licensed under Apache-2.0 license. See LICENSE file in the project root for full license information.
// </copyright>
// ----------------------------------------------------------------------------

using System.Text.Json;
using System.Text.Json.Serialization;
using FPH.ValhallaNET.Enums;
using FPH.ValhallaNET.Models;

namespace FPH.ValhallaNET.Requests
{
    /// <summary>
    /// A class to represent the request for a Valhalla matrix.
    /// </summary>
    public class MatrixRequest
    {
        /// <summary>
        /// Gets or Sets the Sources of the Matrix request.
        /// </summary>
        [JsonPropertyName("sources")]
        public required MatrixLocation[] Sources { get; set; }

        /// <summary>
        /// Gets or Sets the Targets of the Matrix request.
        /// </summary>
        [JsonPropertyName("targets")]
        public required MatrixLocation[] Targets { get; set; }

        /// <summary>
        /// Gets or sets the costing options for the route.
        /// </summary>
        [JsonPropertyName("costing")]
        public required CostingModel Costing { get; set; }

        /// <summary>
        /// Gets or sets the costing options for the route.
        /// </summary>
        [JsonPropertyName("costing_options")]
        public Dictionary<CostingModel, CostingOptions>? CostingOptions { get; set; }

        /// <summary>
        /// Gets or sets the date and time for time-dependent routing.
        /// </summary>
        [JsonPropertyName("date_time")]
        public DateTimeOptions? DateTimeOptions { get; set; }

        /// <summary>
        /// Serializes the matrix request to a JSON string.
        /// </summary>
        /// <returns>A Json String.</returns>
        public string ToJson()
        {
            var options = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            };
            return JsonSerializer.Serialize(this, options);
        }
    }
}
