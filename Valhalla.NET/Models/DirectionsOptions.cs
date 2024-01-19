using System.Text.Json.Serialization;
using FPH.ValhallaNET.Enums;

namespace FPH.ValhallaNET.Models
{
    // A class to represent the options for the directions output
    public class DirectionsOptions
    {
        [JsonPropertyName("language")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public LanguageTag? Language { get; set; } // The language code for the directions text

        [JsonPropertyName("narrative_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public NarrativeType? NarrativeType { get; set; } // The type of narrative for the directions text

        [JsonPropertyName("units")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Unit? Units { get; set; } // The units to use for distance and speed

        [JsonPropertyName("format")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Format? Format { get; set; } // The format of the directions output

        [JsonPropertyName("encoded_polyline")]
        public bool? EncodedPolyline { get; set; } // Whether to include an encoded polyline in the directions output

        [JsonPropertyName("roundabout_exits")]
        public bool? RoundaboutExits { get; set; } // Whether to include exit counts for roundabouts in the directions output
    }
}
