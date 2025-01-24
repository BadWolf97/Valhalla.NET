// ----------------------------------------------------------------------------
// <copyright file="SignInformation.cs" company="Freie Programme Hohenstein">
// Copyright (c) Freie Programme Hohenstein.
// Licensed under Apache-2.0 license. See LICENSE file in the project root for full license information.
// </copyright>
// ----------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace FPH.ValhallaNET.Models
{
    /// <summary>
    /// A class to represent a sign.
    /// </summary>
    public class SignInformation
    {
        /// <summary>
        /// Gets or sets the list of exit number elements. If an exit number element exists, it is typically just one value. Example: "91B".
        /// </summary>
        [JsonPropertyName("exit_number_elements")]
        public SignInformationElement[]? ExitNumberElements { get; set; }

        /// <summary>
        /// Gets or sets the list of exit branch elements. The exit branch element text is the subsequent road name or route number after the sign. Example: "I 95 North".
        /// </summary>
        [JsonPropertyName("exit_branch_elements")]
        public SignInformationElement[]? ExitBranchElements { get; set; }

        /// <summary>
        /// Gets or sets the list of exit toward elements. The exit toward element text is the location where the road ahead goes - the location is typically a control city, but may also be a future road name or route number. Example: "Richmond".
        /// </summary>
        [JsonPropertyName("exit_toward_elements")]
        public SignInformationElement[]? ExitTowardElements { get; set; }

        /// <summary>
        /// Gets or sets the list of exit name elements. The exit name element is the interchange identifier - typically not used in the US. Example: "Gettysburg Pike".
        /// </summary>
        [JsonPropertyName("exit_name_elements")]
        public SignInformationElement[]? ExitNameElements { get; set; }
    }
}
