// ----------------------------------------------------------------------------
// <copyright file="RouteManeuver.cs" company="Freie Programme Hohenstein">
// Copyright (c) Freie Programme Hohenstein.
// Licensed under Apache-2.0 license. See LICENSE file in the project root for full license information.
// </copyright>
// ----------------------------------------------------------------------------

using System.Text.Json.Serialization;
using FPH.ValhallaNET.Enums;

namespace FPH.ValhallaNET.Models
{
    /// <summary>
    /// A class to represent a maneuver of the leg.
    /// </summary>
    public class RouteManeuver
    {
        /// <summary>
        /// Gets or sets the type of the maneuver.
        /// </summary>
        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonNumberEnumConverter<ManeuverType>))]
        public ManeuverType Type { get; set; }

        /// <summary>
        /// Gets or sets the written maneuver instruction. Describes the maneuver, such as "Turn right onto Main Street".
        /// </summary>
        [JsonPropertyName("instruction")]
        public string? Instruction { get; set; }

        /// <summary>
        /// Gets or sets a Text suitable for use as a verbal alert in a navigation application. The transition alert instruction will prepare the user for the forthcoming transition. For example: "Turn right onto North Prince Street".
        /// </summary>
        [JsonPropertyName("verbal_transition_alert_instruction")]
        public string? VerbalTransitionAlertInstruction { get; set; }

        /// <summary>
        /// Gets or sets a Text suitable for use as a verbal message immediately prior to the maneuver transition. For example "Turn right onto North Prince Street, U.S. 2 22".
        /// </summary>
        [JsonPropertyName("verbal_pre_transition_instruction")]
        public string? VerbalPreTransitionInstruction { get; set; }

        /// <summary>
        /// Gets or sets a Text suitable for use as a verbal message immediately after the maneuver transition. For example "Continue on U.S. 2 22 for 3.9 miles".
        /// </summary>
        [JsonPropertyName("verbal_post_transition_instruction")]
        public string? VerbalPostTransitionInstruction { get; set; }

        /// <summary>
        /// Gets or sets a List of street names that are consistent along the entire nonobvious maneuver.
        /// </summary>
        [JsonPropertyName("street_names")]
        public string[]? StreetNames { get; set; }

        /// <summary>
        /// Gets or sets the street names at the beginning (transition point) of the nonobvious maneuver (if they are different than the names that are consistent along the entire nonobvious maneuver).
        /// </summary>
        [JsonPropertyName("begin_street_names")]
        public string[]? BeginStreetNames { get; set; }

        /// <summary>
        /// Gets or sets the estimated time along the maneuver in seconds.
        /// </summary>
        [JsonPropertyName("time")]
        public int? Time { get; set; }

        /// <summary>
        /// Gets or sets the maneuver length in the units specified.
        /// </summary>
        [JsonPropertyName("length")]
        public double? Length { get; set; }

        /// <summary>
        /// Gets or sets the index into the list of shape points for the start of the maneuver.
        /// </summary>
        [JsonPropertyName("begin_shape_index")]
        public int? BeginShapeIndex { get; set; }

        /// <summary>
        /// Gets or sets the index into the list of shape points for the end of the maneuver.
        /// </summary>
        [JsonPropertyName("end_shape_index")]
        public int? EndShapeIndex { get; set; }

        /// <summary>
        /// Gets or sets True if the maneuver has any toll, or portions of the maneuver are subject to a toll.
        /// </summary>
        [JsonPropertyName("toll")]
        public bool? Toll { get; set; }

        /// <summary>
        /// Gets or sets True if a highway is encountered on this maneuver.
        /// </summary>
        [JsonPropertyName("highway")]
        public bool? Highway { get; set; }

        /// <summary>
        /// Gets or sets True if the maneuver is unpaved or rough pavement, or has any portions that have rough pavement.
        /// </summary>
        [JsonPropertyName("rough")]
        public bool? Rough { get; set; }

        /// <summary>
        /// Gets or sets True if a gate is encountered on this maneuver.
        /// </summary>
        [JsonPropertyName("gate")]
        public bool? Gate { get; set; }

        /// <summary>
        /// Gets or sets True if a ferry is encountered on this maneuver.
        /// </summary>
        [JsonPropertyName("ferry")]
        public bool? Ferry { get; set; }

        /// <summary>
        /// Gets or sets the interchange guide information at a road junction associated with this maneuver.
        /// </summary>
        [JsonPropertyName("sign")]
        public SignInformation? Sign { get; set; }

        /// <summary>
        /// Gets or sets the spoke to exit roundabout after entering.
        /// </summary>
        [JsonPropertyName("roundabout_exit_count")]
        public int? RoundaboutExitCount { get; set; }

        /// <summary>
        /// Gets or sets the written depart time instruction. Typically used with a transit maneuver, such as "Depart: 8:04 AM from 8 St - NYU".
        /// </summary>
        [JsonPropertyName("depart_instruction")]
        public string? DepartInstruction { get; set; }

        /// <summary>
        /// Gets or sets a Text suitable for use as a verbal depart time instruction. Typically used with a transit maneuver, such as "Depart at 8:04 AM from 8 St - NYU".
        /// </summary>
        [JsonPropertyName("verbal_depart_instruction")]
        public string? VerbalDepartInstruction { get; set; }

        /// <summary>
        /// Gets or sets the written arrive time instruction. Typically used with a transit maneuver, such as "Arrive: 8:10 AM at 34 St - Herald Sq".
        /// </summary>
        [JsonPropertyName("arrive_instruction")]
        public string? ArriveInstruction { get; set; }

        /// <summary>
        /// Gets or sets a Text suitable for use as a verbal arrive time instruction. Typically used with a transit maneuver, such as "Arrive at 8:10 AM at 34 St - Herald Sq".
        /// </summary>
        [JsonPropertyName("verbal_arrive_instruction")]
        public string? VerbalArriveInstruction { get; set; }

        /// <summary>
        /// Gets or sets the transit information for the maneuver.
        /// </summary>
        [JsonPropertyName("transit_info")]
        public TransitInfo? TransitInfo { get; set; }

        /// <summary>
        /// Gets or sets True if the verbal_pre_transition_instruction has been appended with the verbal instruction of the next maneuver.
        /// </summary>
        [JsonPropertyName("verbal_multi_cue")]
        public bool? VerbalMultiCue { get; set; }

        /// <summary>
        /// Gets or sets the travel mode for the maneuver.
        /// </summary>
        [JsonPropertyName("travel_mode")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TravelMode? TravelMode { get; set; }

        /// <summary>
        /// Gets or sets the travel type for the maneuver.
        /// </summary>
        [JsonPropertyName("travel_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TravelType? TravelType { get; set; }

        /// <summary>
        /// Gets or sets the bikeshare maneuver type for the maneuver.
        /// </summary>
        [JsonPropertyName("bss_maneuver_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BikeShareManeuverType? BikeShareManeuverType { get; set; }

        /// <summary>
        /// Gets or sets the clockwise angle from true north to the direction of travel immediately before the maneuver.
        /// </summary>
        [JsonPropertyName("bearing_before")]
        public double? BearingBefore { get; set; }

        /// <summary>
        /// Gets or sets the clockwise angle from true north to the direction of travel immediately after the maneuver.
        /// </summary>
        [JsonPropertyName("bearing_after")]
        public double? BearingAfter { get; set; }
    }
}
