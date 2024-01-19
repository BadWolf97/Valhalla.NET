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

    }

    // A class to represent a matrix response
    public class MatrixResponse
    {
        [JsonPropertyName("sources")]
        public MatrixLocation[]? Sources { get; set; }

        [JsonPropertyName("targets")]
        public MatrixLocation[]? Targets { get; set; }

        [JsonPropertyName("matrix")]
        public TimeDistance[][]? Matrix { get; set; }

        // A method to deserialize the matrix response from JSON
        public static MatrixResponse? FromJson(string json)
        {
            return JsonSerializer.Deserialize<MatrixResponse>(json);
        }
    }

}
