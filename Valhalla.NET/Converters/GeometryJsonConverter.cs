using System.Text.Json;
using System.Text.Json.Serialization;
using FPH.ValhallaNET.Enums;
using FPH.ValhallaNET.Models;

namespace FPH.ValhallaNET.Converters
{
    /// <summary>
    /// Converts Geometry objects to and from JSON.
    /// </summary>
    public class GeometryJsonConverter : JsonConverter<Geometry>
    {
        /// <summary>
        /// Reads and converts the JSON to a Geometry object.
        /// </summary>
        /// <param name="reader">The reader to read from.</param>
        /// <param name="typeToConvert">The type to convert.</param>
        /// <param name="options">Options to control the conversion behavior.</param>
        /// <returns>The converted Geometry object.</returns>
        /// <exception cref="JsonException">Thrown when the JSON is invalid.</exception>
        public override Geometry Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
            {
                var root = doc.RootElement;
                var json_type = root.GetProperty("type").GetString();
                var json_coordinates = root.GetProperty("coordinates").ToString();

                if (json_type == null || json_coordinates == null)
                {
                    throw new JsonException();
                }

                GeometryType type = Enum.Parse<GeometryType>(json_type, true);
                List<List<List<double[]>>> coordinates = new();

                switch (type)
                {
                    case GeometryType.MultiPolygon:
                        var multipolygon = JsonSerializer.Deserialize<List<List<List<double[]>>>>(json_coordinates, options);
                        if (multipolygon != null)
                        {
                            coordinates = multipolygon;
                        }

                        break;
                    case GeometryType.Polygon:
                        var polygon = JsonSerializer.Deserialize<List<List<double[]>>>(json_coordinates, options);
                        if (polygon != null)
                        {
                            coordinates.Add(polygon);
                        }

                        break;
                    case GeometryType.LineString:
                        var lineString = JsonSerializer.Deserialize<List<double[]>>(json_coordinates, options);
                        if (lineString != null)
                        {
                            coordinates.Add(new List<List<double[]>> { lineString });
                        }

                        break;
                }

                return new Geometry
                {
                    Type = Enum.Parse<GeometryType>(json_type, true),
                    Coordinates = coordinates,
                };
            }
        }

        /// <summary>
        /// Writes a Geometry object as JSON.
        /// </summary>
        /// <param name="writer">The writer to write to.</param>
        /// <param name="value">The Geometry object to write.</param>
        /// <param name="options">Options to control the conversion behavior.</param>
        public override void Write(Utf8JsonWriter writer, Geometry value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteString("type", value.Type.ToString());

            switch (value.Type)
            {
                case GeometryType.MultiPolygon:
                    JsonSerializer.Serialize(writer, value.Coordinates, options);
                    break;
                case GeometryType.Polygon:
                    if (value.Coordinates.Count != 1)
                    {
                        throw new JsonException("The coordinate structure does not fit the Geometry Type.");
                    }

                    JsonSerializer.Serialize(writer, value.Coordinates[0], options);
                    break;
                case GeometryType.LineString:
                    if (value.Coordinates.Count != 1 || value.Coordinates[0].Count != 1)
                    {
                        throw new JsonException("The coordinate structure does not fit the Geometry Type.");
                    }

                    JsonSerializer.Serialize(writer, value.Coordinates[0][0], options);
                    break;
            }

            writer.WriteEndObject();
        }
    }
}
