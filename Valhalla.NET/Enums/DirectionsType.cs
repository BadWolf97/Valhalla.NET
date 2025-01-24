// ----------------------------------------------------------------------------
// <copyright file="DirectionsType.cs" company="Freie Programme Hohenstein">
// Copyright (c) Freie Programme Hohenstein.
// Licensed under Apache-2.0 license. See LICENSE file in the project root for full license information.
// </copyright>
// ----------------------------------------------------------------------------

namespace FPH.ValhallaNET.Enums
{
    /// <summary>
    /// An enumeration to represent the directions type, aka the verbosity of the return.
    /// </summary>
    public enum DirectionsType
    {
        /// <summary>
        /// Indicating no maneuvers or instructions should be returned.
        /// </summary>
        None = 0,

        /// <summary>
        /// Indicating only maneuvers should be returned.
        /// </summary>
        Manuevers = 1,

        /// <summary>
        /// Inidcating that Maneuvers with instructions should be returned.
        /// </summary>
        Instructions = 2,
    }
}
