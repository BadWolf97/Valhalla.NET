// ----------------------------------------------------------------------------
// <copyright file="TravelType.cs" company="Freie Programme Hohenstein">
// Copyright (c) Freie Programme Hohenstein.
// Licensed under Apache-2.0 license. See LICENSE file in the project root for full license information.
// </copyright>
// ----------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace FPH.ValhallaNET.Enums
{
    /// <summary>
    /// An enumeration to represent the type of travel.
    /// </summary>
    public enum TravelType
    {
        /// <summary>
        /// The travel type is driving.
        /// </summary>
        Car,

        /// <summary>
        /// The travel type is walking.
        /// </summary>
        Foot,

        /// <summary>
        /// The travel type is cycling on a road-style bicycle.
        /// </summary>
        Road,

        /// <summary>
        /// The travel type is cycling on a hybrid/city-style bicycle. This is Valhalla's default
        /// bicycle type, so this value is returned unless bicycle_type was explicitly overridden.
        /// </summary>
        Hybrid,

        /// <summary>
        /// The travel type is cycling on a cyclo-cross bicycle.
        /// </summary>
        Cross,

        /// <summary>
        /// The travel type is cycling on a mountain bicycle.
        /// </summary>
        Mountain,

        /// <summary>
        /// The travel type is walking as a pedestrian using a wheelchair.
        /// </summary>
        Wheelchair,

        /// <summary>
        /// The travel type is walking as a blind pedestrian.
        /// </summary>
        Blind,

        /// <summary>
        /// The travel type is tram.
        /// </summary>
        Tram,

        /// <summary>
        /// The travel type is metro.
        /// </summary>
        Metro,

        /// <summary>
        /// The travel type is rail.
        /// </summary>
        Rail,

        /// <summary>
        /// The travel type is bus.
        /// </summary>
        Bus,

        /// <summary>
        /// The travel type is ferry.
        /// </summary>
        Ferry,

        /// <summary>
        /// The travel type is cable car.
        /// </summary>
        [JsonPropertyName("cable_car")]
        CableCar,

        /// <summary>
        /// The travel type is gondola.
        /// </summary>
        Gondola,

        /// <summary>
        /// The travel type is funicular.
        /// </summary>
        Funicular,
    }
}
