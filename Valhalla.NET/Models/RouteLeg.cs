using System.Text.Json.Serialization;

namespace FPH.ValhallaNET.Models
{
    // A class to represent a leg of the route
    public class RouteLeg
    {
        [JsonPropertyName("shape")]
        public string? Shape { get; set; } // The encoded polyline of the leg

        public List<Tuple<double, double>>? Coordinates()
        {
            if (Shape == null) return null;
            int i = 0;
            const double kInvPolylinePrecision = 1.0 / 1E6;

            // Handy lambda to turn a few bytes of an encoded string into an integer
            Func<double, double> deserialize = (previous) =>
            {
                // Grab each 5 bits and mask it in where it belongs using the shift
                int byteValue, shift = 0, result = 0;
                do
                {
                    byteValue = Shape[i++] - 63;
                    result |= (byteValue & 0x1f) << shift;
                    shift += 5;
                } while (byteValue >= 0x20);

                // Undo the left shift from above or the bit flipping and add to previous
                // since it's an offset
                return previous + ((result & 1) == 1 ? ~(result >> 1) : result >> 1);
            };

            List<Tuple<double, double>> coords = new List<Tuple<double, double>>();
            double lastLon = 0, lastLat = 0;

            while (i < Shape.Length)
            {
                // Decode the coordinates, lat first for some reason
                double lat = deserialize(lastLat);
                double lon = deserialize(lastLon);

                // Shift the decimal point 5 places to the left
                coords.Add(new Tuple<double, double>((double)(lat * kInvPolylinePrecision), (double)(lon * kInvPolylinePrecision)));

                // Remember the last one we encountered
                lastLon = lon;
                lastLat = lat;
            }

            return coords;
        }

        [JsonPropertyName("summary")]
        public RouteSummary? Summary { get; set; } // The summary of the leg

        [JsonPropertyName("maneuvers")]
        public RouteManeuver[]? Maneuvers { get; set; } // The maneuvers of the leg
    }
}
