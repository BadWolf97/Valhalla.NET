using System.Text.Json.Serialization;
using FPH.ValhallaNET.Enums;

namespace FPH.ValhallaNET.Models
{
    // A class to represent the options for filtering the route by attributes
    public class FilterOptions
    {
        [JsonPropertyName("attributes")]
        public required string[] Attributes { get; set; } // An array of attributes to filter the route by

        [JsonPropertyName("action")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public FilterAction Action { get; set; } // The action to apply to the filtered route: 0 - exclude, 1 - include
    }
}
