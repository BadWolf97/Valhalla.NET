// ----------------------------------------------------------------------------
// <copyright file="FilterAction.cs" company="Freie Programme Hohenstein">
// Copyright (c) Freie Programme Hohenstein.
// Licensed under Apache-2.0 license. See LICENSE file in the project root for full license information.
// </copyright>
// ----------------------------------------------------------------------------

namespace FPH.ValhallaNET.Enums
{
    /// <summary>
    /// An enum to represent the action to apply to the filtered route.
    /// </summary>
    public enum FilterAction
    {
        /// <summary>
        /// Exclude the edges that match the attributes from the route.
        /// </summary>
        Exclude,

        /// <summary>
        /// Include only the edges that match the attributes in the route.
        /// </summary>
        Include,
    }
}
