using FPH.ValhallaNET.Models;
using System.Text.Json.Serialization;
using System.Text.Json;
using FPH.ValhallaNET.Enums;

namespace FPH.ValhallaNET.Requests
{
    public class MatrixRequest
    {
        [JsonPropertyName("sources")]
        public required MatrixLocation[] Sources { get; set; }

        [JsonPropertyName("targets")]
        public required MatrixLocation[] Targets { get; set; }

        [JsonPropertyName("costing")]
        public CostingModel Costing { get; set; }

        [JsonPropertyName("date_time")]
        public DateTimeOptions? DateTimeOptions { get; set; }

        // A method to serialize the matrix request to JSON
        public string ToJson()
        {
            var options = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
            return JsonSerializer.Serialize(this, options);
        }
    }
}
