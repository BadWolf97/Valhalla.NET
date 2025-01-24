// ----------------------------------------------------------------------------
// <copyright file="SignInformationElement.cs" company="Freie Programme Hohenstein">
// Copyright (c) Freie Programme Hohenstein.
// Licensed under Apache-2.0 license. See LICENSE file in the project root for full license information.
// </copyright>
// ----------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace FPH.ValhallaNET.Models
{
    /// <summary>
    /// A class to represent a sign element.
    /// </summary>
    public class SignInformationElement
    {
        /// <summary>
        /// Gets or sets the text of the element.
        /// </summary>
        [JsonPropertyName("text")]
        public required string Text { get; set; }

        /// <summary>
        /// Gets or sets the frequency of this sign element within a set a consecutive signs.
        /// </summary>
        [JsonPropertyName("consecutive_count")]
        public int? ConsecutiveCount { get; set; }
    }
}