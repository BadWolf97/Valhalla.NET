﻿// ----------------------------------------------------------------------------
// <copyright file="Location.cs" company="Freie Programme Hohenstein">
// Copyright (c) Freie Programme Hohenstein.
// Licensed under Apache-2.0 license. See LICENSE file in the project root for full license information.
// </copyright>
// ----------------------------------------------------------------------------

using System.Text.Json.Serialization;
using FPH.ValhallaNET.Enums;

namespace FPH.ValhallaNET.Models
{
    /// <summary>
    /// A class to represent a location for routing.
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Gets or sets the Latitude of the location in degrees. This is assumed to be both the routing location and the display location if no display_lat and display_lon are provided.
        /// </summary>
        [JsonPropertyName("lat")]
        public required double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the Longitude of the location in degrees. This is assumed to be both the routing location and the display location if no display_lat and display_lon are provided.
        /// </summary>
        [JsonPropertyName("lon")]
        public required double Longitude { get; set; }

        /// <summary>
        /// Gets or sets the Location Type. Each type controls two characteristics: whether or not to allow a u-turn at the location and whether or not to generate guidance/legs at the location. A break is a location at which we allows u-turns and generate legs and arrival/departure maneuvers. A through location is a location at which we neither allow u-turns nor generate legs or arrival/departure maneuvers. A via location is a location at which we allow u-turns but do not generate legs or arrival/departure maneuvers. A break_through location is a location at which we do not allow u-turns but do generate legs and arrival/departure maneuvers. If no type is provided, the type is assumed to be a break. The types of the first and last locations are ignored and are treated as breaks.
        /// </summary>
        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public LocationType? Type { get; set; }

        /// <summary>
        /// Gets or sets the preferred direction of travel for the start from the location. This can be useful for mobile routing where a vehicle is traveling in a specific direction along a road, and the route should start in that direction. The heading is indicated in degrees from north in a clockwise direction, where north is 0°, east is 90°, south is 180°, and west is 270°.
        /// </summary>
        [JsonPropertyName("heading")]
        public double? Heading { get; set; }

        /// <summary>
        /// Gets or sets how close in degrees a given street's angle must be in order for it to be considered as in the same direction of the heading parameter. The default value is 60 degrees.
        /// </summary>
        [JsonPropertyName("heading_tolerance")]
        public double? HeadingTolerance { get; set; }

        /// <summary>
        /// Gets or sets the Street name. The street name may be used to assist finding the correct routing location at the specified latitude, longitude. This is not currently implemented.
        /// </summary>
        [JsonPropertyName("street")]
        [Obsolete("This property is not currently implemented.")]
        public string? Street { get; set; }

        /// <summary>
        /// Gets or sets the OpenStreetMap identification number for a polyline way. The way ID may be used to assist finding the correct routing location at the specified latitude, longitude. This is not currently implemented.
        /// </summary>
        [JsonPropertyName("way_id")]
        [Obsolete("This property is not currently implemented.")]
        public string? WayID { get; set; }

        /// <summary>
        /// Gets or sets the minimum number of nodes (intersections) reachable for a given edge (road between intersections) to consider that edge as belonging to a connected region. When correlating this location to the route network, try to find candidates who are reachable from this many or more nodes (intersections). If a given candidate edge reaches less than this number of nodes its considered to be a disconnected island and we'll search for more candidates until we find at least one that isn't considered a disconnected island. If this value is larger than the configured service limit it will be clamped to that limit. The default is a minimum of 50 reachable nodes.
        /// </summary>
        [JsonPropertyName("minimum_reachability")]
        public int? MinimumReachability { get; set; }

        /// <summary>
        /// Gets or sets the number of meters about this input location within which edges (roads between intersections) will be considered as candidates for said location. When correlating this location to the route network, try to only return results within this distance (meters) from this location. If there are no candidates within this distance it will return the closest candidate within reason. If this value is larger than the configured service limit it will be clamped to that limit. The default is 0 meters.
        /// </summary>
        [JsonPropertyName("radius")]
        public double? Radius { get; set; }

        /// <summary>
        /// Gets or sets whether or not to rank the edge candidates for this location. The ranking is used as a penalty within the routing algorithm so that some edges will be penalized more heavily than others. If true candidates will be ranked according to their distance from the input and various other attributes. If false the candidates will all be treated as equal which should lead to routes that are just the most optimal path with emphasis about which edges were selected.
        /// </summary>
        [JsonPropertyName("rank_candidates")]
        public bool? RankCandidates { get; set; }

        /// <summary>
        /// Gets or sets the determined side of street is used to determine whether or not the location should be visited from the same, opposite or either side of the road with respect to the side of the road the given locale drives on. In Germany (driving on the right side of the road), passing a value of same will only allow you to leave from or arrive at a location such that the location will be on your right. In Australia (driving on the left side of the road), passing a value of same will force the location to be on your left. A value of opposite will enforce arriving/departing from a location on the opposite side of the road from that which you would be driving on while a value of either will make no attempt limit the side of street that is available for the route. If the location is not offset from the road centerline or is closest to an intersection this option has no effect.
        /// </summary>
        [JsonPropertyName("preferred_side")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SideOfStreet? PreferredSide { get; set; }

        /// <summary>
        /// Gets or sets the Latitude of the map location in degrees. If provided the lat and lon parameters will be treated as the routing location and the display_lat and display_lon will be used to determine the side of street. Both display_lat and display_lon must be provided and valid to achieve the desired effect.
        /// </summary>
        [JsonPropertyName("display_lat")]
        public double? DisplayLat { get; set; }

        /// <summary>
        /// Gets or sets the Longitude of the map location in degrees. If provided the lat and lon parameters will be treated as the routing location and the display_lat and display_lon will be used to determine the side of street. Both display_lat and display_lon must be provided and valid to achieve the desired effect.
        /// </summary>
        [JsonPropertyName("display_lon")]
        public double? DisplayLon { get; set; }

        /// <summary>
        /// Gets or sets the cutoff at which we will assume the input is too far away from civilisation to be worth correlating to the nearest graph elements. The default is 35 km.
        /// </summary>
        [JsonPropertyName("search_cutoff")]
        public int? SearchCutoff { get; set; }

        /// <summary>
        /// Gets or sets the tolerance used to determine (during edge correlation) whether or not to snap to the intersection rather than along the street, if the snap location is within this distance from the intersection the intersection is used instead. The default is 5 meters.
        /// </summary>
        [JsonPropertyName("node_snap_tolerance")]
        public double? NodeSnapTolerance { get; set; }

        /// <summary>
        /// Gets or sets the tolerance away from the edge centerline thet the input coordinate needs to me less than then we set your side of street to none otherwise your side of street will be left or right depending on direction of travel. The default is 5 meters.
        /// </summary>
        [JsonPropertyName("street_side_tolerance")]
        public double? StreetSideTolerance { get; set; }

        /// <summary>
        /// Gets or sets the max distance in meters that the input coordinates or display ll can be from the edge centerline for them to be used for determining the side of street. Beyond this distance the side of street is set to none. The default is 1000 meters.
        /// </summary>
        [JsonPropertyName("street_side_max_distance")]
        public double? StreetSideMaxDistance { get; set; }

        /// <summary>
        /// Gets or sets the road class that the edge has to be in to be considered for the side of street determination. Disables the preferred_side when set to same or opposite if the edge has a road class less than that provided by street_side_cutoff. The road class must be one of the following strings: motorway, trunk, primary, secondary, tertiary, unclassified, residential, service_other. The default value is service_other so that preferred_side will not be disabled for any edges.
        /// </summary>
        [JsonPropertyName("street_side_cutoff")]
        public string? StreetSideCutoff { get; set; }

        /// <summary>
        /// Gets or sets the layer on which edges should be considered. If provided, edges whose layer does not match the provided value will be discarded from the candidate search.
        /// </summary>
        [JsonPropertyName("preferred_layer")]
        public int? PreferredLayer { get; set; }

        /// <summary>
        /// Gets or sets a set of optional filters to exclude candidate edges based on their attribution.
        /// </summary>
        [JsonPropertyName("search_filter")]
        public SearchFilter? SearchFilter { get; set; }

        /// <summary>
        /// Gets or sets the name of the location. This is just passed through to the output and may get used in route narration directions.
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets a city name. This is just passed through to the output.
        /// </summary>
        [JsonPropertyName("city")]
        public string? City { get; set; }

        /// <summary>
        /// Gets or sets a state name. This is just passed through to the output.
        /// </summary>
        [JsonPropertyName("state")]
        public string? State { get; set; }

        /// <summary>
        /// Gets or sets a postal code. This is just passed through to the output.
        /// </summary>
        [JsonPropertyName("postal_code")]
        public string? PostalCode { get; set; }

        /// <summary>
        /// Gets or sets a country name. This is just passed through to the output.
        /// </summary>
        [JsonPropertyName("country")]
        public string? Country { get; set; }

        /// <summary>
        /// Gets or sets a phone number. This is just passed through to the output.
        /// </summary>
        [JsonPropertyName("phone")]
        public string? Phone { get; set; }

        /// <summary>
        /// Gets or sets a URL. This is just passed through to the output.
        /// </summary>
        [JsonPropertyName("url")]
        public string? Url { get; set; }

        /// <summary>
        /// Gets or sets the waiting time in seconds at this location. E.g. when the route describes a pizza delivery tour, each location has a service time, which can be respected by setting waiting on the location, then the departure will be delayed by this amount in seconds. Only works for break or break_through types.
        /// </summary>
        [JsonPropertyName("waiting")]
        public int? Waiting { get; set; }

        /// <summary>
        /// Gets or sets the side of street of a break location that is determined based on the actual route when the location is offset from the street. The possible values are left and right.
        /// </summary>
        [JsonPropertyName("side_of street")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SideOfStreet? SideOfStreet { get; set; }

        /// <summary>
        /// Gets or sets the expected date/time for the user to be at the location using the ISO 8601 format (YYYY-MM-DDThh:mm) in the local time zone of departure or arrival. For example "2015-12-29T08:00". If waiting was set on this location in the request, and it's an intermediate location, the date_time will describe the departure time at this location.
        /// </summary>
        [JsonPropertyName("date_time")]
        public string? DateTime { get; set; }
    }
}
