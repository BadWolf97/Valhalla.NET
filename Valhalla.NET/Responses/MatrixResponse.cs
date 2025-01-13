using FPH.ValhallaNET.Enums;
using FPH.ValhallaNET.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FPH.ValhallaNET.Responses
{
    // A class to represent a time-distance element for the matrix response
    public class TimeDistance
    {
        [JsonPropertyName("time")]
        public double Time { get; set; }

        [JsonPropertyName("distance")]
        public double Distance { get; set; }

        [JsonPropertyName("to_index")]
        public int ToIndex { get; set; }

        [JsonPropertyName("from_index")]
        public int FromIndex { get; set; }

        [JsonPropertyName("date_time")]
        public string? DateTime { get; set; }

        [JsonPropertyName("time_zone_offset")]
        public int TimeZoneOffset { get; set; }

        [JsonPropertyName("time_zone_name")]
        public string? TimeZoneName { get; set; }
    }

    // A class to represent a matrix response
    public class MatrixResponse
    {
        [JsonPropertyName("sources")]
        public MatrixLocation[]? Sources { get; set; }

        [JsonPropertyName("targets")]
        public MatrixLocation[]? Targets { get; set; }

        [JsonPropertyName("sources_to_targets")]
        public TimeDistance[][]? Matrix { get; set; }

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("algorithm")]
        public MatrixAlgorithm? Algorithm { get; set; }

        [JsonPropertyName("units")]
        public Unit? Unit { get; set; }

        [JsonPropertyName("warnings")]
        public string[]? Warnings { get; set; }

        // A method to deserialize the matrix response from JSON
        public static MatrixResponse? FromJson(string json)
        {
            var options = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
            };
            return JsonSerializer.Deserialize<MatrixResponse>(json, options);
        }
    }

}
