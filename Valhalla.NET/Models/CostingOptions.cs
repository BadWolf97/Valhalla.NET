// ----------------------------------------------------------------------------
// <copyright file="CostingOptions.cs" company="Freie Programme Hohenstein">
// Copyright (c) Freie Programme Hohenstein.
// Licensed under Apache-2.0 license. See LICENSE file in the project root for full license information.
// </copyright>
// ----------------------------------------------------------------------------

using System.Text.Json.Serialization;
using FPH.ValhallaNET.Enums;

namespace FPH.ValhallaNET.Models
{
    /// <summary>
    /// A class to represent the options for a costing model.
    /// </summary>
    public class CostingOptions
    {
        /// <summary>
        /// Gets or sets the basic costing model to use for routing.
        /// </summary>
        [JsonPropertyName("costing")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public required CostingModel Costing { get; set; }

        /// <summary>
        /// Gets or sets the name of the costing model. Used for recostings.
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets a penalty applied when transitioning between roads that do not have consistent naming–in other words, no road names in common. This penalty can be used to create simpler routes that tend to have fewer maneuvers or narrative guidance instructions. The default maneuver penalty is five seconds.
        /// </summary>
        /// <remarks>Available for auto, motor_scooter, motorcycle, bus, truck and bicycle costing methods.</remarks>
        [JsonPropertyName("maneuver_penalty")]
        public double? ManeuverPenalty { get; set; }

        /// <summary>
        /// Gets or sets a cost applied when a gate with undefined or private access is encountered. This cost is added to the estimated time / elapsed time. The default gate cost is 30 seconds.
        /// </summary>
        /// <remarks>Available for auto, motor_scooter, motorcycle, bus, truck and bicycle costing methods.</remarks>
        [JsonPropertyName("gate_cost")]
        public double? GateCost { get; set; }

        /// <summary>
        /// Gets or sets a penalty applied when a gate with no access information is on the road. The default gate penalty is 300 seconds.
        /// </summary>
        /// <remarks>Available for auto, motor_scooter, motorcycle, bus, truck and bicycle  costing methods.</remarks>
        [JsonPropertyName("gate_penalty")]
        public double? GatePenalty { get; set; }

        /// <summary>
        /// Gets or sets a penalty applied when a gate or bollard with access=private is encountered. The default private access penalty is 450 seconds.
        /// </summary>
        /// <remarks>Available for auto, motor_scooter, motorcycle, bus and truck costing methods.</remarks>
        [JsonPropertyName("private_access_penalty")]
        public double? PrivateAccessPenalty { get; set; }

        /// <summary>
        /// Gets or sets a penalty applied when entering an road which is only allowed to enter if necessary to reach the destination.
        /// </summary>
        /// <remarks>Available for pedestrians, auto, motor_scooter, motorcycle, bus, truck and bicycle costing methods.</remarks>
        [JsonPropertyName("destination_only_penalty")]
        public double? DestinationOnlyPenalty { get; set; }

        /// <summary>
        /// Gets or sets a cost applied when a toll booth is encountered. This cost is added to the estimated and elapsed times. The default cost is 15 seconds.
        /// </summary>
        /// <remarks>Available for auto, motor_scooter, motorcycle, bus and truck costing methods.</remarks>
        [JsonPropertyName("toll_booth_cost")]
        public double? TollBoothCoset { get; set; }

        /// <summary>
        /// Gets or sets a penalty applied to the cost when a toll booth is encountered. This penalty can be used to create paths that avoid toll roads. The default toll booth penalty is 0.
        /// </summary>
        /// <remarks>Available for auto, motor_scooter, motorcycle, bus and truck costing methods.</remarks>
        [JsonPropertyName("toll_booth_penalty")]
        public double? TollBoothPenalty { get; set; }

        /// <summary>
        /// Gets or sets a cost applied when entering a ferry. This cost is added to the estimated and elapsed times. The default cost is 300 seconds (5 minutes).
        /// </summary>
        /// <remarks>Available for auto, bus and truck costing methods.</remarks>
        [JsonPropertyName("ferry_cost")]
        public double? FerryCost { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates the willingness to take ferries. This is a range of values between 0 and 1. Values near 0 attempt to avoid ferries and values near 1 will favor ferries. The default value is 0.5. Note that sometimes ferries are required to complete a route so values of 0 are not guaranteed to avoid ferries entirely.
        /// </summary>
        /// <remarks>Available for pedestrian, auto, motor_scooter, motorcycle, bus, truck and bicycle costing methods.</remarks>
        [JsonPropertyName("use_ferry")]
        public double? UseFerry { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates the willingness to take highways. This is a range of values between 0 and 1. Values near 0 attempt to avoid highways and values near 1 will favor highways. The default value is 1.0. Note that sometimes highways are required to complete a route so values of 0 are not guaranteed to avoid highways entirely.
        /// </summary>
        /// <remarks>Available for auto, motor_scooter, motorcycle, bus and truck costing methods.</remarks>
        [JsonPropertyName("use_highways")]
        public double? UseHighways { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates the willingness to take toll roads. This is a range of values between 0 and 1. Values near 0 attempt to avoid toll roads and values near 1 will favor toll roads. The default value is 0.5. Note that sometimes toll roads are required to complete a route so values of 0 are not guaranteed to avoid toll roads entirely.
        /// </summary>
        /// <remarks>Available for auto, motor_scooter, motorcycle, bus and truck costing methods.</remarks>
        [JsonPropertyName("use_toll_roads")]
        public double? UseTollRoads { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates the willingness to take living streets. This is a range of values between 0 and 1. Values near 0 attempt to avoid living streets and values near 1 will favor living streets. The default value is 0 for trucks, 0.1 for cars, busses, motor scooters and motorcycles, 0.6 for pedestrians. Note that sometimes living streets are required to complete a route so values of 0 are not guaranteed to avoid living streets entirely.
        /// </summary>
        /// <remarks>Available for pedestrians, auto, motor_scooter, motorcycle, bus, truck and bicycle costing methods.</remarks>
        [JsonPropertyName("use_living_streets")]
        public double? UseLivingStreets { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates the willingness to take track roads. This is a range of values between 0 and 1. Values near 0 attempt to avoid tracks and values near 1 will favor tracks a little bit. The default value is 0 for autos, 0.5 for pedestrians, motor scooters and motorcycles. Note that sometimes tracks are required to complete a route so values of 0 are not guaranteed to avoid tracks entirely.
        /// </summary>
        /// <remarks>Available for pedestrians, auto, motor_scooter, motorcycle, bus and truck costing methods.</remarks>
        [JsonPropertyName("use_tracks")]
        public double? UseTracks { get; set; }

        /// <summary>
        /// Gets or sets a penalty applied for transition to generic service road. The default penalty is 0 for pedestrians and trucks and 15 for cars, buses, motor scooters and motorcycles.
        /// </summary>
        /// <remarks>Available for pedestrians, auto, motor_scooter, motorcycle, bus, truck and bicycle costing methods.</remarks>
        [JsonPropertyName("service_penalty")]
        public double? ServicePenalty { get; set; }

        /// <summary>
        /// Gets or sets a factor that modifies (multiplies) the cost when generic service roads are encountered. The default is 1.
        /// </summary>
        /// <remarks>Available for pedestrians, auto, motor_scooter, motorcycle, bus and truck costing methods.</remarks>
        [JsonPropertyName("service_factor")]
        public double? ServiceFactor { get; set; }

        /// <summary>
        /// Gets or sets a cost applied when encountering an international border. This cost is added to the estimated and elapsed times. The default cost is 600 seconds.
        /// </summary>
        /// <remarks>Available for auto, motor_scooter, motorcycle, bus, truck and bicycle  costing methods.</remarks>
        [JsonPropertyName("country_crossing_cost")]
        public double? CountryCrossingCost { get; set; }

        /// <summary>
        /// Gets or sets a penalty applied for a country crossing. This penalty can be used to create paths that avoid spanning country boundaries. The default penalty is 0.
        /// </summary>
        /// <remarks>Available for auto, motor_scooter, motorcycle, bus, truck and bicycle  costing methods.</remarks>
        [JsonPropertyName("country_crossing_penalty")]
        public double? CountryCrossingPenalty { get; set; }

        /// <summary>
        /// Gets or sets the metric to quasi-shortest, i.e. purely distance-based costing. Note, this will disable all other costings + penalties. Also note, shortest will not disable hierarchy pruning, leading to potentially sub-optimal routes for some costing models. The default is false.
        /// </summary>
        /// <remarks>Available for pedestrian, auto, motor_scooter, motorcycle, bus, truck and bicycle costing methods.</remarks>
        [JsonPropertyName("shortest")]
        public bool? Shortest { get; set; }

        /// <summary>
        /// Gets or sets a factor that allows controlling the contribution of distance and time to the route costs. The value is in range between 0 and 1, where 0 only takes time into account (default) and 1 only distance. A factor of 0.5 will weight them roughly equally. Note: this costing is currently only available for auto costing.
        /// </summary>
        /// <remarks>Available for auto, motor_scooter, motorcycle, bus and truck costing methods.</remarks>
        [JsonPropertyName("use_distance")]
        public double? UseDistance { get; set; }

        /// <summary>
        /// Gets or sets a value if hierarchies are disabled to calculate the actual optimal route. The default is false. Note: This could be quite a performance drainer so there is a upper limit of distance. If the upper limit is exceeded, this option will always be false.
        /// </summary>
        /// <remarks>Available for auto, motor_scooter, motorcycle, bus and truck costing methods.</remarks>
        [JsonPropertyName("disable_hierarchy_pruning")]
        public bool? DisableHierarchyPruning { get; set; }

        /// <summary>
        /// Gets or sets the Top speed the vehicle can go. Also used to avoid roads with higher speeds than this value. top_speed must be between 10 and 252 KPH for auto, bus and truck and between 20 and 120 KPH for motor_scooter. The default value is 120 KPH for truck, 140 KPH for auto and bus and 45 KPH for motor_scooter.
        /// </summary>
        /// <remarks>Available for auto, motor_scooter, motorcycle, bus, and truck costing methods.</remarks>
        [JsonPropertyName("top_speed")]
        public double? TopSpeed { get; set; }

        /// <summary>
        /// Gets or sets the fixed speed the vehicle can go. Used to override the calculated speed. Can be useful if speed of vehicle is known. fixed_speed must be between 1 and 252 KPH. The default value is 0 KPH which disables fixed speed and falls back to the standard calculated speed based on the road attribution.
        /// </summary>
        /// <remarks>Available for auto, motor_scooter, motorcycle, bus and truck costing methods.</remarks>
        [JsonPropertyName("fixed_speed")]
        public double? FixedSpeed { get; set; }

        /// <summary>
        /// Gets or sets a bool to ignores all closures, marked due to live traffic closures, during routing. Note: This option cannot be set if location.search_filter.exclude_closures is also specified in the request and will return an error if it is. Default is false.
        /// </summary>
        /// <remarks>Available for auto, motor_scooter, motorcycle, bus and truck costing methods.</remarks>
        [JsonPropertyName("ignore_closures")]
        public bool? IgnoreClosures { get; set; }

        /// <summary>
        /// Gets or sets a factor that penalizes the cost when traversing a closed edge (eg: if search_filter.exclude_closures is false for origin and/or destination location and the route starts/ends on closed edges). Its value can range from 1.0 - don't penalize closed edges, to 10.0 - apply high cost penalty to closed edges. Default value is 9.0. Note: This factor is applicable only for motorized modes of transport, i.e auto, motorcycle, motor_scooter, bus, truck + taxi.
        /// </summary>
        /// <remarks>Available for auto, motor_scooter, motorcycle, bus and truck costing methods.</remarks>
        [JsonPropertyName("closure_factor")]
        public double? ClosureFactor { get; set; }

        /// <summary>
        /// Gets or sets a bool to ignores any restrictions (e.g. turn/dimensional/conditional restrictions). Especially useful for matching GPS traces to the road network regardless of restrictions. Default is false. This does not contain IgnoreOneways.
        /// </summary>
        /// <remarks>Available for auto, motor_scooter, motorcycle, bus and truck costing methods.</remarks>
        [JsonPropertyName("ignore_restrictions")]
        public bool? IgnoreRestrictions { get; set; }

        /// <summary>
        /// Gets or sets a bool to ignore one-way restrictions. Especially useful for matching GPS traces to the road network ignoring uni-directional traffic rules. Not included in ignore_restrictions option. Default is false.
        /// </summary>
        /// <remarks>Available for auto, motor_scooter, motorcycle, bus and truck costing methods.</remarks>
        [JsonPropertyName("ignore_oneways")]
        public bool? IgnoreOneways { get; set; }

        /// <summary>
        /// Gets or sets a bool to ignore restrictions that do not impact vehicle safety, such as weight and size restrictions. Simlar to IgnoreRestrictions. Default is false.
        /// </summary>
        /// <remarks>Available for auto, motor_scooter, motorcycle, bus and truck costing methods.</remarks>
        [JsonPropertyName("ignore_non_vehicular_restrictions")]
        public bool? IgnoreNonVehicularRestrictions { get; set; }

        /// <summary>
        /// Gets or sets a bool to ignore mode-specific access tags. Especially useful for matching GPS traces to the road network regardless of access tags. Default is false.
        /// </summary>
        /// <remarks>Available for auto, motor_scooter, motorcycle, bus and truck costing methods.</remarks>
        [JsonPropertyName("ignore_access")]
        public bool? IgnoreAccess { get; set; }

        /// <summary>
        /// Gets or sets a bool to ignore construction tags. Only works when the include_construction option is set before building the graph. Useful for planning future routes. Default is false.
        /// </summary>
        /// <remarks>Available for auto, motor_scooter, motorcycle, bus and truck costing methods.</remarks>
        [JsonPropertyName("ignore_construction")]
        public bool? IgnoreConstruction { get; set; }

        /// <summary>
        /// Gets or sets a value to determine which speed sources are used, if available. A list of strings with the following possible values: freeflow, constrained, predicted, current. Default is all sources(again, only if available).
        /// </summary>
        /// <remarks>Available for auto, motor_scooter, motorcycle, bus and truck costing methods.</remarks>
        [JsonPropertyName("speed_types")]
        public string[]? SpeedTypes { get; set; }

        /// <summary>
        /// Gets or sets the height of the vehicle (in meters). Default 1.9 for car, bus, taxi and 4.11 for truck.
        /// </summary>
        /// <remarks>Available for auto, motor_scooter, motorcycle, bus, taxi and truck costing methods.</remarks>
        [JsonPropertyName("height")]
        public double? Height { get; set; }

        /// <summary>
        /// Gets or sets the width of the vehicle (in meters). Default 1.6 for car, bus, taxi and 2.6 for truck.
        /// </summary>
        /// <remarks>Available for auto, motor_scooter, motorcycle, bus, taxi and truck costing methods.</remarks>
        [JsonPropertyName("width")]
        public double? Width { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates whether or not the path may include unpaved roads. If ExcludeUnpaved is set to 1 it is allowed to start and end with unpaved roads, but is not allowed to have them in the middle of the route path, otherwise they are allowed. Default false.
        /// </summary>
        /// <remarks>Available for auto, motor_scooter, motorcycle, bus, taxi and truck costing methods.</remarks>
        [JsonPropertyName("exclude_unpaved")]
        public bool? ExcludeUnpaved { get; set; }

        /// <summary>
        /// Gets or sets a boolean value which indicates the desire to avoid routes with cash-only tolls. Default false.
        /// </summary>
        /// <remarks>Available for auto, motor_scooter, motorcycle, bus, taxi and truck costing methods.</remarks>
        [JsonPropertyName("exclude_cash_only_tolls")]
        public bool? ExcludeCashOnlyTolls { get; set; }

        /// <summary>
        /// Gets or sets a boolean value which indicates the desire to include HOV roads with a 2-occupant requirement in the route when advantageous. Default false.
        /// </summary>
        /// <remarks>Available for auto, motor_scooter, motorcycle, bus, taxi and truck costing methods.</remarks>
        [JsonPropertyName("include_hov2")]
        public bool? IncludeHov2 { get; set; }

        /// <summary>
        /// Gets or sets a boolean value which indicates the desire to include HOV roads with a 3-occupant requirement in the route when advantageous. Default false.
        /// </summary>
        /// <remarks>Available for auto, motor_scooter, motorcycle, bus, taxi and truck costing methods.</remarks>
        [JsonPropertyName("include_hov3")]
        public bool? IncludeHov3 { get; set; }

        /// <summary>
        /// Gets or sets aboolean value which indicates the desire to include tolled HOV roads which require the driver to pay a toll if the occupant requirement isn't met. Default false.
        /// </summary>
        /// <remarks>Available for auto, motor_scooter, motorcycle, bus, taxi and truck costing methods.</remarks>
        [JsonPropertyName("include_hot")]
        public bool? IncludeHot { get; set; }

        /// <summary>
        /// Gets or sets the length of the truck (in meters). Default 21.64.
        /// </summary>
        /// <remarks>Available for truck costing methods.</remarks>
        [JsonPropertyName("length")]
        public double? Length { get; set; }

        /// <summary>
        /// Gets or sets the weight of the truck (in metric tons). Default 21.77.
        /// </summary>
        /// <remarks>Available for truck costing methods.</remarks>
        [JsonPropertyName("weight")]
        public double? Weight { get; set; }

        /// <summary>
        /// Gets or sets the axle load of the truck (in metric tons). Default 9.07.
        /// </summary>
        /// <remarks>Available for truck costing methods.</remarks>
        [JsonPropertyName("axle_load")]
        public double? AxleLoad { get; set; }

        /// <summary>
        /// Gets or sets the axle count of the truck. Default 5.
        /// </summary>
        /// <remarks>Available for truck costing methods.</remarks>
        [JsonPropertyName("axle_count")]
        public int? AxleCount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the truck is carrying hazardous material. Default false.
        /// </summary>
        /// <remarks>Available for truck costing methods.</remarks>
        [JsonPropertyName("hazmat")]
        public bool? Hazmat { get; set; }

        /// <summary>
        /// Gets or sets a penalty applied to roads with no HGV/truck access. If set to a value less than 43200 seconds, HGV will be allowed on these roads and the penalty applies. Default 43200, i.e. trucks are not allowed.
        /// </summary>
        /// <remarks>Available for truck costing methods.</remarks>
        [JsonPropertyName("hgv_no_access_penalty")]
        public double? HgvNoAccessPenalty { get; set; }

        /// <summary>
        /// Gets or sets a penalty (in seconds) which is applied when going to residential or service roads. Default is 30 seconds.
        /// </summary>
        /// <remarks>Available for truck costing methods.</remarks>
        [JsonPropertyName("low_class_penalty")]
        public double? LowClassPenalty { get; set; }

        /// <summary>
        /// Gets or sets a value as a range of values from 0 to 1, where 0 indicates a light preference for streets marked as truck routes, and 1 indicates that streets not marked as truck routes should be avoided. This information is derived from the hgv=designated tag. Note that even with values near 1, there is no guarantee the returned route will include streets marked as truck routes. The default value is 0.
        /// </summary>
        /// <remarks>Available for truck costing methods.</remarks>
        [JsonPropertyName("use_truck_route")]
        public double? UseTruckRoute { get; set; }

        /// <summary>
        /// Gets or sets the type of bicycle. The default type is Hybrid.
        /// </summary>
        /// <remarks>Available for bicycle costing methods.</remarks>
        [JsonPropertyName("bicycle_type")]
        public BicycleType? BicycleType { get; set; }

        /// <summary>
        /// Gets or sets the average travel speed along smooth, flat roads. This is meant to be the speed a rider can comfortably maintain over the desired distance of the route. It can be modified (in the costing method) by surface type in conjunction with bicycle type and (coming soon) by hilliness of the road section. When no speed is specifically provided, the default speed is determined by the bicycle type and are as follows: Road = 25 KPH (15.5 MPH), Cross = 20 KPH (13 MPH), Hybrid/City = 18 KPH (11.5 MPH), and Mountain = 16 KPH (10 MPH).
        /// </summary>
        /// <remarks>Available for bicycle costing methods.</remarks>
        [JsonPropertyName("cycling_speed")]
        public double? CyclingSpeed { get; set; }

        /// <summary>
        /// Gets or sets the cyclist's propensity to use roads alongside other vehicles. This is a range of values from 0 to 1, where 0 attempts to avoid roads and stay on cycleways and paths, and 1 indicates the rider is more comfortable riding on roads. Based on the use_roads factor, roads with certain classifications and higher speeds are penalized in an attempt to avoid them when finding the best path. The default value is 0.5.
        /// </summary>
        /// <remarks>Available for bicycle costing methods.</remarks>
        [JsonPropertyName("use_roads")]
        public double? UseRoads { get; set; }

        /// <summary>
        /// Gets or sets the cyclist's desire to tackle hills in their routes. This is a range of values from 0 to 1, where 0 attempts to avoid hills and steep grades even if it means a longer (time and distance) path, while 1 indicates the rider does not fear hills and steeper grades. Based on the use_hills factor, penalties are applied to roads based on elevation change and grade. These penalties help the path avoid hilly roads in favor of flatter roads or less steep grades where available. Note that it is not always possible to find alternate paths to avoid hills (for example when route locations are in mountainous areas). The default value is 0.5.
        /// </summary>
        /// <remarks>Available for pedestrians, bicycle and motor_scooter costing methods.</remarks>
        [JsonPropertyName("use_hills")]
        public double? UseHills { get; set; }

        /// <summary>
        /// Gets or sets a value to represent how much a cyclist wants to avoid roads with poor surfaces relative to the bicycle type being used. This is a range of values between 0 and 1. When the value is 0, there is no penalization of roads with different surface types; only bicycle speed on each surface is taken into account. As the value approaches 1, roads with poor surfaces for the bike are penalized heavier so that they are only taken if they significantly improve travel time. When the value is equal to 1, all bad surfaces are completely disallowed from routing, including start and end points. The default value is 0.25.
        /// </summary>
        /// <remarks>Available for bicycle costing methods.</remarks>
        [JsonPropertyName("avoid_bad_surfaces")]
        public double? AvoidBadSurfaces { get; set; }

        /// <summary>
        /// Gets or sets a value represents the time will be used to return a rental bike. This value will be displayed in the final directions and used to calculate the whole duration. This is useful when bikeshare is chosen as travel mode. The default value is 120 seconds.
        /// </summary>
        /// <remarks>Available for bikeshare costing methods.</remarks>
        [JsonPropertyName("bss_return_cost")]
        public double? BssReturnCost { get; set; }

        /// <summary>
        /// Gets or sets a value represents the penalty will be applied when returning a rental bike. This value won't be displayed and used only inside of the algorithm. This is useful when bikeshare is chosen as travel mode. The default value is 0.
        /// </summary>
        /// <remarks>Available for bikeshare costing methods.</remarks>
        [JsonPropertyName("bss_return_penalty")]
        public double? BssReturnPenalty { get; set; }

        /// <summary>
        /// Gets or sets the rider's propensity to use primary roads. This is a range of values from 0 to 1, where 0 attempts to avoid primary roads, and 1 indicates the rider is more comfortable riding on primary roads. Based on the use_primary factor, roads with certain classifications and higher speeds are penalized in an attempt to avoid them when finding the best path. The default value is 0.5.
        /// </summary>
        /// <remarks>Available for motor_scooter costing methods.</remarks>
        [JsonPropertyName("use_primary")]
        public double? UsePrimary { get; set; }

        /// <summary>
        /// Gets or sets a riders's desire for adventure in their routes. This is a range of values from 0 to 1, where 0 will avoid trails, tracks, unclassified or bad surfaces and values towards 1 will tend to avoid major roads and route on secondary roads. The default value is 0.0.
        /// </summary>
        /// <remarks>Available for motorcycle costing methods.</remarks>
        [JsonPropertyName("use_trails")]
        public double? UseTrails { get; set; }

        /// <summary>
        /// Gets or sets the walking speed in kilometers per hour. Must be between 0.5 and 25 km/hr. Defaults to 5.1 km/hr (3.1 miles/hour).
        /// </summary>
        /// <remarks>Available for pedestrian costing methods.</remarks>
        [JsonPropertyName("walking_speed")]
        public double? WalkingSpeed { get; set; }

        /// <summary>
        /// Gets or sets a factor that modifies the cost when encountering roads classified as footway (no motorized vehicles allowed), which may be designated footpaths or designated sidewalks along residential roads. Pedestrian routes generally attempt to favor using these walkways and sidewalks. The default walkway_factor is 1.0.
        /// </summary>
        /// <remarks>Available for pedestrian costing methods.</remarks>
        [JsonPropertyName("walkway_factor")]
        public double? WalkwayFactor { get; set; }

        /// <summary>
        /// Gets or sets a factor that modifies the cost when encountering roads with dedicated sidewalks. Pedestrian routes generally attempt to favor using sidewalks. The default sidewalk_factor is 1.0.
        /// </summary>
        /// <remarks>Available for pedestrian costing methods.</remarks>
        [JsonPropertyName("sidewalk_factor")]
        public double? SidewalkFactor { get; set; }

        /// <summary>
        /// Gets or sets a factor that modifies (multiplies) the cost when alleys are encountered. Pedestrian routes generally want to avoid alleys or narrow service roads between buildings. The default alley_factor is 2.0.
        /// </summary>
        /// <remarks>Available for pedestrian costing methods.</remarks>
        [JsonPropertyName("alley_factor")]
        public double? AlleyFactor { get; set; }

        /// <summary>
        /// Gets or sets a factor that modifies (multiplies) the cost when encountering a driveway, which is often a private, service road. Pedestrian routes generally want to avoid driveways (private). The default driveway factor is 5.0.
        /// </summary>
        /// <remarks>Available for pedestrian costing methods.</remarks>
        [JsonPropertyName("driveway_factor")]
        public double? DrivewayFactor { get; set; }

        /// <summary>
        /// Gets or sets a penalty in seconds added to each transition onto a path with steps or stairs. Higher values apply larger cost penalties to avoid paths that contain flights of steps.
        /// </summary>
        /// <remarks>Available for pedestrian costing methods.</remarks>
        [JsonPropertyName("step_penalty")]
        public double? StepPenalty { get; set; }

        /// <summary>
        /// Gets or sets a penalty in seconds added to each transition via an elevator node or onto an elevator edge. Higher values apply larger cost penalties to avoid elevators.
        /// </summary>
        /// <remarks>Available for pedestrian costing methods.</remarks>
        [JsonPropertyName("elevator_penalty")]
        public double? ElevatorPenalty { get; set; }

        /// <summary>
        /// Gets or sets a value that is a range of values from 0 to 1, where 0 indicates indifference towards lit streets, and 1 indicates that unlit streets should be avoided. Note that even with values near 1, there is no guarantee the returned route will include lit segments. The default value is 0.
        /// </summary>
        /// <remarks>Available for pedestrian costing methods.</remarks>
        [JsonPropertyName("use_lit")]
        public double? UseLit { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the maximum difficulty of hiking trails that is allowed. Values between 0 and 6 are allowed. The values correspond to sac_scale values within OpenStreetMap, see reference on https://wiki.openstreetmap.org/wiki/Key:sac_scale. The default value is 1 which means that well cleared trails that are mostly flat or slightly sloped are allowed. Higher difficulty trails can be allowed by specifying a higher value for max_hiking_difficulty.
        /// </summary>
        /// <remarks>Available for pedestrian costing methods.</remarks>
        [JsonPropertyName("max_hiking_difficulty")]
        public double? MaxHikingDifficulty { get; set; }

        /// <summary>
        /// Gets or sets the maximum total walking distance of a route. Default is 100 km (~62 miles).
        /// </summary>
        /// <remarks>Available for pedestrian costing methods.</remarks>
        [JsonPropertyName("max_distance")]
        public double? MaxDistance { get; set; }

        /// <summary>
        /// Gets or sets the type of pedestrian.\n\nIf set to blind, enables additional route instructions, especially useful for blind users: Announcing crossed streets, the stairs, bridges, tunnels, gates and bollards, which need to be passed on route; information about traffic signals on crosswalks; route numbers not announced for named routes.\nIf set to wheelchair, changes the defaults for max_distance, walking_speed, and step_penalty to be better aligned to the needs of wheelchair users.\n\nThese two options are mutually exclusive.In case you want to combine them, please use blind and pass the options adjusted for wheelchair users manually. Default foot.
        /// </summary>
        /// <remarks>Available for pedestrian costing methods.</remarks>
        [JsonPropertyName("type")]
        public PedestrianType? PedestrianType { get; set; }

        /// <summary>
        /// Gets or sets a pedestrian option that can be added to the request to extend the defaults (2145 meters or approximately 1.5 miles). This is the maximum walking distance at the beginning or end of a route.
        /// </summary>
        /// <remarks>Available for multimodal costing methods.</remarks>
        [JsonPropertyName("transit_start_end_max_distance")]
        public double? TransitStartEndMaxDistance { get; set; }

        /// <summary>
        /// Gets or sets a pedestrian option that can be added to the request to extend the defaults (800 meters or 0.5 miles). This is the maximum walking distance between transfers.
        /// </summary>
        /// <remarks>Available for multimodal costing methods.</remarks>
        [JsonPropertyName("transit_transfer_max_distance")]
        public double? TransitTransferMaxDistance { get; set; }

        /// <summary>
        /// Gets or sets a factor which the cost of a pedestrian edge will be multiplied with on multimodal request, e.g. bss or multimodal/transit. Default is a factor of 1.5, i.e. avoiding walking.
        /// </summary>
        /// <remarks>Available for multimodal costing methods.</remarks>
        [JsonPropertyName("mode_factor")]
        public double? ModeFactor { get; set; }

        /// <summary>
        /// Gets or sets a User's desire to use buses. Range of values from 0 (try to avoid buses) to 1 (strong preference for riding buses).
        /// </summary>
        /// <remarks>Available for multimodal costing methods.</remarks>
        [JsonPropertyName("use_bus")]
        public double? UseBus { get; set; }

        /// <summary>
        /// Gets or sets a User's desire to use rail/subway/metro. Range of values from 0 (try to avoid rail) to 1 (strong preference for riding rail).
        /// </summary>
        /// <remarks>Available for multimodal costing methods.</remarks>
        [JsonPropertyName("use_rail")]
        public double? UseRail { get; set; }

        /// <summary>
        /// Gets or sets a User's desire to favor transfers. Range of values from 0 (try to avoid transfers) to 1 (totally comfortable with transfers).
        /// </summary>
        /// <remarks>Available for multimodal costing methods.</remarks>
        [JsonPropertyName("use_transfers")]
        public double? UseTransfers { get; set; }
    }
}
