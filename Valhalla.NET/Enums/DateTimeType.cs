// ----------------------------------------------------------------------------
// <copyright file="DateTimeType.cs" company="Freie Programme Hohenstein">
// Copyright (c) Freie Programme Hohenstein.
// Licensed under Apache-2.0 license. See LICENSE file in the project root for full license information.
// </copyright>
// ----------------------------------------------------------------------------

namespace FPH.ValhallaNET.Enums
{
    /// <summary>
    /// An enumeration to represent the type of date and time for routing.
    /// </summary>
    public enum DateTimeType
    {
        /// <summary>
        /// Use the current date and time.
        /// </summary>
        Current,

        /// <summary>
        /// Use the specified date and time as the departure time.
        /// </summary>
        DepartAt,

        /// <summary>
        /// Use the specified date and time as the arrival time.
        /// </summary>
        ArriveBy,
    }
}
