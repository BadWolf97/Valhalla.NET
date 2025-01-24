// ----------------------------------------------------------------------------
// <copyright file="LocationType.cs" company="Freie Programme Hohenstein">
// Copyright (c) Freie Programme Hohenstein.
// Licensed under Apache-2.0 license. See LICENSE file in the project root for full license information.
// </copyright>
// ----------------------------------------------------------------------------

namespace FPH.ValhallaNET.Enums
{
    /// <summary>
    /// An enum to represent the type of location.
    /// </summary>
    public enum LocationType
    {
        /// <summary>
        /// A location that allows u-turns and generates legs and maneuvers.
        /// </summary>
        Break,

        /// <summary>
        /// A location that does not allow u-turns or generate legs or maneuvers.
        /// </summary>
        Through,

        /// <summary>
        /// A location that allows u-turns but does not generate legs or maneuvers.
        /// </summary>
        Via,

        /// <summary>
        /// A location that does not allow u-turns but generates legs and maneuvers.
        /// </summary>
        Break_Through,
    }
}
