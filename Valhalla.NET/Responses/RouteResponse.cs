using System.Text.Json.Serialization;
using System.Text.Json;
using FPH.ValhallaNET.Models;

namespace FPH.ValhallaNET.Responses
{
    public class RouteResponse 
    {
        [JsonPropertyName("trip")]
        public Trip? Trip { get; set; } // The trip information

        // A method to deserialize the response from JSON
        public static RouteResponse? FromJson(string json)
        {
            return JsonSerializer.Deserialize<RouteResponse>(json);
        }
    }
}
