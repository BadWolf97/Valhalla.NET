using System.Text.Json.Serialization;

namespace FPH.ValhallaNET.Models
{
    // A class to represent the options for a costing model
    public class CostingOptions
    {
        [JsonPropertyName("country_crossing_penalty")]
        public double? CountryCrossingPenalty { get; set; } // Penalty for crossing country borders in seconds

        [JsonPropertyName("use_ferry")]
        public double? UseFerry { get; set; } // A factor that modifies the cost when using a ferry. A value of 0 completely avoids ferries, while a value of 1.0 does not avoid ferries. Values between 0 and 1 will increase or decrease the cost of ferries based on the value.

        [JsonPropertyName("use_tolls")]
        public double? UseTolls { get; set; } // A factor that modifies the cost when using a toll road. A value of 0 completely avoids toll roads, while a value of 1.0 does not avoid toll roads. Values between 0 and 1 will increase or decrease the cost of toll roads based on the value.

        [JsonPropertyName("use_highways")]
        public double? UseHighways { get; set; } // A factor that modifies the cost when using a highway. A value of 0 completely avoids highways, while a value of 1.0 does not avoid highways. Values between 0 and 1 will increase or decrease the cost of highways based on the value.

        [JsonPropertyName("use_tracks")]
        public double? UseTracks { get; set; } // A factor that modifies the cost when using a track. A value of 0 completely avoids tracks, while a value of 1.0 does not avoid tracks. Values between 0 and 1 will increase or decrease the cost of tracks based on the value.

        [JsonPropertyName("use_living_streets")]
        public double? UseLivingStreets { get; set; } // A factor that modifies the cost when using a living street. A value of 0 completely avoids living streets, while a value of 1.0 does not avoid living streets. Values between 0 and 1 will increase or decrease the cost of living streets based on the value.

        [JsonPropertyName("use_hills")]
        public double? UseHills { get; set; } // A factor that modifies the cost when using a hilly road. A value of 0 completely avoids hilly roads, while a value of 1.0 does not avoid hilly roads. Values between 0 and 1 will increase or decrease the cost of hilly roads based on the value.

        [JsonPropertyName("use_primary")]
        public double? UsePrimary { get; set; } // A factor that modifies the cost when using a primary road. A value of 0 completely avoids primary roads, while a value of 1.0 does not avoid primary roads. Values between 0 and 1 will increase or decrease the cost of primary roads based on the value.

        [JsonPropertyName("maneuver_penalty")]
        public double? ManeuverPenalty { get; set; } // Penalty (in seconds) to add when a maneuver occurs.

        [JsonPropertyName("gate_cost")]
        public double? GateCost { get; set; } // Cost (in seconds) to go through a gate.

        [JsonPropertyName("gate_penalty")]
        public double? GatePenalty { get; set; } // Penalty (in seconds) to go through a gate.

        [JsonPropertyName("alley_penalty")]
        public double? AlleyPenalty { get; set; } // Penalty (in seconds) to use an alley.

        [JsonPropertyName("toll_booth_cost")]
        public double? TollBoothCost { get; set; } // Cost (in seconds) to go through a toll booth.

        [JsonPropertyName("toll_booth_penalty")]
        public double? TollBoothPenalty { get; set; } // Penalty (in seconds) to go through a toll booth.

        [JsonPropertyName("ferry_cost")]
        public double? FerryCost { get; set; } // Cost (in seconds) to take a ferry.

        [JsonPropertyName("destination_only_penalty")]
        public double? DestinationOnlyPenalty { get; set; } // Penalty (in seconds) to use a destination only road.

        [JsonPropertyName("low_class_penalty")]
        public double? LowClassPenalty { get; set; } // Penalty (in seconds) to use a low class road.

        [JsonPropertyName("hazmat")]
        public bool? Hazmat { get; set; } // Whether the vehicle has hazardous materials.

        [JsonPropertyName("weight")]
        public double? Weight { get; set; } // The weight of the vehicle in kilograms.

        [JsonPropertyName("axle_load")]
        public double? AxleLoad { get; set; } // The axle load of the vehicle in kilograms.

        [JsonPropertyName("height")]
        public double? Height { get; set; } // The height of the vehicle in meters.

        [JsonPropertyName("width")]
        public double? Width { get; set; } // The width of the vehicle in meters.

        [JsonPropertyName("length")]
        public double? Length { get; set; } // The length of the vehicle in meters.

        [JsonPropertyName("top_speed")]
        public double? TopSpeed { get; set; } // The top speed of the vehicle in kilometers per hour.

        [JsonPropertyName("flow_mask")]
        public int? FlowMask { get; set; } // A mask to indicate which flow types are considered when computing the route. The default is 0, which means no flow data is used. The possible values are: 1 - use current flow data, 2 - use free flow data, 3 - use both current and free flow data.
    }
}
