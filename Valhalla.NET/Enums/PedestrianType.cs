// ----------------------------------------------------------------------------
// <copyright file="PedestrianType.cs" company="Freie Programme Hohenstein">
// Copyright (c) Freie Programme Hohenstein.
// Licensed under Apache-2.0 license. See LICENSE file in the project root for full license information.
// </copyright>
// ----------------------------------------------------------------------------

namespace FPH.ValhallaNET.Enums
{
    /// <summary>
    /// An enumeration of the different types of pedestrians.
    /// </summary>
    public enum PedestrianType
    {
        /// <summary>
        /// Represents a pedestrian which is neither blind nor in a wheelchair.
        /// </summary>
        Foot,

        /// <summary>
        /// Represents a blind pedestrian.
        /// </summary>
        Blind,

        /// <summary>
        /// Represents a pedestrian in a wheelchair.
        /// </summary>
        Wheelchair,
    }
}
