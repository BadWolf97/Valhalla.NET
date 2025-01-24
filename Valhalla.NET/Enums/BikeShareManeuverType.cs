// ----------------------------------------------------------------------------
// <copyright file="BikeShareManeuverType.cs" company="Freie Programme Hohenstein">
// Copyright (c) Freie Programme Hohenstein.
// Licensed under Apache-2.0 license. See LICENSE file in the project root for full license information.
// </copyright>
// ----------------------------------------------------------------------------

namespace FPH.ValhallaNET.Enums
{
    /// <summary>
    /// An enumeration to represent the type of bike sharing maneuver.
    /// </summary>
    public enum BikeShareManeuverType
    {
        /// <summary>
        /// No action.
        /// </summary>
        NoneAction,

        /// <summary>
        /// Rent a bike at a bike share station.
        /// </summary>
        RentBikeAtBikeShare,

        /// <summary>
        /// Return a bike at a bike share station.
        /// </summary>
        ReturnBikeAtBikeShare,
    }
}
