using System.Text.Json.Serialization;

namespace FPH.ValhallaNET.Models
{
    // A class to represent the search filter for a location
    public class SearchFilter
    {
        [JsonPropertyName("categories")]
        public string[]? Categories { get; set; } // An array of categories to filter the candidates by

        [JsonPropertyName("attributes")]
        public string[]? Attributes { get; set; } // An array of attributes to filter the candidates by
    }
}
