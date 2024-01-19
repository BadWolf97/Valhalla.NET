using System.Text.Json.Serialization;

namespace FPH.ValhallaNET.Models
{
    public class MatrixLocation
    {
        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        [JsonPropertyName("lon")]
        public double Longitude { get; set; }
    }
}
