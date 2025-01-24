// ----------------------------------------------------------------------------
// <copyright file="DateTimeOptions.cs" company="Freie Programme Hohenstein">
// Copyright (c) Freie Programme Hohenstein.
// Licensed under Apache-2.0 license. See LICENSE file in the project root for full license information.
// </copyright>
// ----------------------------------------------------------------------------

using System.Text.Json.Serialization;
using FPH.ValhallaNET.Enums;

namespace FPH.ValhallaNET.Models
{
    /// <summary>
    /// A class to represent the options for time-dependent routing.
    /// </summary>
    public class DateTimeOptions
    {
        /// <summary>
        /// Gets or sets the type of date and time for routing.
        /// </summary>
        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public DateTimeType Type { get; set; }

        /// <summary>
        /// Gets or sets the date and time value in the format YYYY-MM-DDTHH:mm in the local time zone of departure or arrival.
        /// </summary>
        [JsonPropertyName("value")]
        public string? Value { get; set; }
    }
}
