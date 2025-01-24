// ----------------------------------------------------------------------------
// <copyright file="BicycleType.cs" company="Freie Programme Hohenstein">
// Copyright (c) Freie Programme Hohenstein.
// Licensed under Apache-2.0 license. See LICENSE file in the project root for full license information.
// </copyright>
// ----------------------------------------------------------------------------

namespace FPH.ValhallaNET.Enums
{
    /// <summary>
    /// An enumeration of the different types of bicycles.
    /// </summary>
    public enum BicycleType
    {
        /// <summary>
        /// A bicycle made mostly for city riding or casual riding on roads and paths with good surfaces.
        /// </summary>
        Hybrid,

        /// <summary>
        /// A road-style bicycle with narrow tires that is generally lightweight and designed for speed on paved surfaces.
        /// </summary>
        Road,

        /// <summary>
        /// A bicycle made mostly for city riding or casual riding on roads and paths with good surfaces.
        /// </summary>
        City,

        /// <summary>
        /// A cyclo-cross bicycle, which is similar to a road bicycle but with wider tires suitable to rougher surfaces.
        /// </summary>
        Cross,

        /// <summary>
        /// A mountain bicycle suitable for most surfaces but generally heavier and slower on paved surfaces.
        /// </summary>
        Mountain,
    }
}
