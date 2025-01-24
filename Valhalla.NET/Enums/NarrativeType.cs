// ----------------------------------------------------------------------------
// <copyright file="NarrativeType.cs" company="Freie Programme Hohenstein">
// Copyright (c) Freie Programme Hohenstein.
// Licensed under Apache-2.0 license. See LICENSE file in the project root for full license information.
// </copyright>
// ----------------------------------------------------------------------------

namespace FPH.ValhallaNET.Enums
{
    /// <summary>
    /// An enum to represent the type of narrative for the directions text.
    /// </summary>
    public enum NarrativeType
    {
        /// <summary>
        /// Plain text narrative.
        /// </summary>
        Text,

        /// <summary>
        /// Text narrative with HTML tags.
        /// </summary>
        TaggedText,

        /// <summary>
        /// No narrative.
        /// </summary>
        None,
    }
}
