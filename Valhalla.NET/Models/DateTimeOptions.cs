using System.Text.Json.Serialization;
using FPH.ValhallaNET.Enums;

namespace FPH.ValhallaNET.Models
{
    // A class to represent the options for time-dependent routing
    public class DateTimeOptions
    {
        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public DateTimeType Type { get; set; } // The type of date and time for routing: 0 - current, 1 - depart at, 2 - arrive by

        [JsonPropertyName("value")]
        public string? Value { get; set; } // The date and time value in the format YYYY-MM-DDTHH:mm
    }
}
