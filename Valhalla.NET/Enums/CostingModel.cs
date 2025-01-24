// ----------------------------------------------------------------------------
// <copyright file="CostingModel.cs" company="Freie Programme Hohenstein">
// Copyright (c) Freie Programme Hohenstein.
// Licensed under Apache-2.0 license. See LICENSE file in the project root for full license information.
// </copyright>
// ----------------------------------------------------------------------------

namespace FPH.ValhallaNET.Enums
{
#pragma warning disable SA1300 // Element should begin with upper-case letter
    /// <summary>
    /// An enumeration to represent the costing model.
    /// </summary>
    public enum CostingModel
    {
        /// <summary>
        /// No costing model.
        /// </summary>
        none,

        /// <summary>
        /// Automobile routing.
        /// </summary>
        auto,

        /// <summary>
        /// Bicycle routing.
        /// </summary>
        bicycle,

        /// <summary>
        /// Bus routing (like automobile, but checks access).
        /// </summary>
        bus,

        /// <summary>
        /// Bikeshare routing, change travelmode on bike share stations.
        /// </summary>
        bikeshare,

        /// <summary>
        /// Hov routing (like automobile, but checks access).
        /// </summary>
        truck,

        /// <summary>
        /// Taxi routing (like automobile, but prefers taxi lanes).
        /// </summary>
        taxi,

        /// <summary>
        /// Motor scooter routing.
        /// </summary>
        motor_scooter,

        /// <summary>
        /// Motorcycle routing.
        /// </summary>
        motorcycle,

        /// <summary>
        /// Multimodal routing (like pedestrian, but with public transit).
        /// </summary>
        multimodal,

        /// <summary>
        /// Pedestrian routing.
        /// </summary>
        pedestrian,
    }
#pragma warning restore SA1300 // Element should begin with upper-case letter
}
