// ----------------------------------------------------------------------------
// <copyright file="ManeuverType.cs" company="Freie Programme Hohenstein">
// Copyright (c) Freie Programme Hohenstein.
// Licensed under Apache-2.0 license. See LICENSE file in the project root for full license information.
// </copyright>
// ----------------------------------------------------------------------------

namespace FPH.ValhallaNET.Enums
{
    /// <summary>
    /// Enumeration of different types of maneuvers.
    /// </summary>
    public enum ManeuverType
    {
        /// <summary>
        /// No maneuver.
        /// </summary>
        None = 0,

        /// <summary>
        /// Start maneuver.
        /// </summary>
        Start = 1,

        /// <summary>
        /// Start right maneuver.
        /// </summary>
        StartRight = 2,

        /// <summary>
        /// Start left maneuver.
        /// </summary>
        StartLeft = 3,

        /// <summary>
        /// Destination maneuver.
        /// </summary>
        Destination = 4,

        /// <summary>
        /// Destination right maneuver.
        /// </summary>
        DestinationRight = 5,

        /// <summary>
        /// Destination left maneuver.
        /// </summary>
        DestinationLeft = 6,

        /// <summary>
        /// Becomes maneuver.
        /// </summary>
        Becomes = 7,

        /// <summary>
        /// Continue maneuver.
        /// </summary>
        Continue = 8,

        /// <summary>
        /// Slight right maneuver.
        /// </summary>
        SlightRight = 9,

        /// <summary>
        /// Right maneuver.
        /// </summary>
        Right = 10,

        /// <summary>
        /// Sharp right maneuver.
        /// </summary>
        SharpRight = 11,

        /// <summary>
        /// U-turn right maneuver.
        /// </summary>
        UturnRight = 12,

        /// <summary>
        /// U-turn left maneuver.
        /// </summary>
        UturnLeft = 13,

        /// <summary>
        /// Sharp left maneuver.
        /// </summary>
        SharpLeft = 14,

        /// <summary>
        /// Left maneuver.
        /// </summary>
        Left = 15,

        /// <summary>
        /// Slight left maneuver.
        /// </summary>
        SlightLeft = 16,

        /// <summary>
        /// Ramp straight maneuver.
        /// </summary>
        RampStraight = 17,

        /// <summary>
        /// Ramp right maneuver.
        /// </summary>
        RampRight = 18,

        /// <summary>
        /// Ramp left maneuver.
        /// </summary>
        RampLeft = 19,

        /// <summary>
        /// Exit right maneuver.
        /// </summary>
        ExitRight = 20,

        /// <summary>
        /// Exit left maneuver.
        /// </summary>
        ExitLeft = 21,

        /// <summary>
        /// Stay straight maneuver.
        /// </summary>
        StayStraight = 22,

        /// <summary>
        /// Stay right maneuver.
        /// </summary>
        StayRight = 23,

        /// <summary>
        /// Stay left maneuver.
        /// </summary>
        StayLeft = 24,

        /// <summary>
        /// Merge maneuver.
        /// </summary>
        Merge = 25,

        /// <summary>
        /// Roundabout enter maneuver.
        /// </summary>
        RoundaboutEnter = 26,

        /// <summary>
        /// Roundabout exit maneuver.
        /// </summary>
        RoundaboutExit = 27,

        /// <summary>
        /// Ferry enter maneuver.
        /// </summary>
        FerryEnter = 28,

        /// <summary>
        /// Ferry exit maneuver.
        /// </summary>
        FerryExit = 29,

        /// <summary>
        /// Transit maneuver.
        /// </summary>
        Transit = 30,

        /// <summary>
        /// Transit transfer maneuver.
        /// </summary>
        TransitTransfer = 31,

        /// <summary>
        /// Transit remain on maneuver.
        /// </summary>
        TransitRemainOn = 32,

        /// <summary>
        /// Transit connection start maneuver.
        /// </summary>
        TransitConnectionStart = 33,

        /// <summary>
        /// Transit connection transfer maneuver.
        /// </summary>
        TransitConnectionTransfer = 34,

        /// <summary>
        /// Transit connection destination maneuver.
        /// </summary>
        TransitConnectionDestination = 35,

        /// <summary>
        /// Post transit connection destination maneuver.
        /// </summary>
        PostTransitConnectionDestination = 36,

        /// <summary>
        /// Merge right maneuver.
        /// </summary>
        MergeRight = 37,

        /// <summary>
        /// Merge left maneuver.
        /// </summary>
        MergeLeft = 38,

        /// <summary>
        /// Elevator enter maneuver.
        /// </summary>
        ElevatorEnter = 39,

        /// <summary>
        /// Steps enter maneuver.
        /// </summary>
        StepsEnter = 40,

        /// <summary>
        /// Escalator enter maneuver.
        /// </summary>
        EscalatorEnter = 41,

        /// <summary>
        /// Building enter maneuver.
        /// </summary>
        BuildingEnter = 42,

        /// <summary>
        /// Building exit maneuver.
        /// </summary>
        BuildingExit = 43,
    }
}
