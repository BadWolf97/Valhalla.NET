// ----------------------------------------------------------------------------
// <copyright file="PolylineDecodingTests.cs" company="Freie Programme Hohenstein">
// Copyright (c) Freie Programme Hohenstein.
// Licensed under Apache-2.0 license. See LICENSE file in the project root for full license information.
// </copyright>
// ----------------------------------------------------------------------------

using System.Text;
using FPH.ValhallaNET.Models;

namespace FPH.ValhallaNET.Tests.Serialization
{
    /// <summary>
    /// Tests for <see cref="RouteLeg.Coordinates"/>, which decodes Valhalla's encoded polyline
    /// shape string (precision 1e6, i.e. "polyline6").
    /// </summary>
    public class PolylineDecodingTests
    {
        [Fact]
        public void Coordinates_DecodesSimpleTwoPointShape()
        {
            (double Lat, double Lon)[] expected = [(50.986500, 11.029400), (50.978700, 11.034100)];
            RouteLeg leg = new() { Shape = Encode(expected) };

            var decoded = leg.Coordinates();

            Assert.NotNull(decoded);
            Assert.Equal(expected.Length, decoded!.Count);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.Equal(expected[i].Lat, decoded[i].Item1, 5);
                Assert.Equal(expected[i].Lon, decoded[i].Item2, 5);
            }
        }

        [Fact]
        public void Coordinates_DecodesShapeWithNegativeDeltas()
        {
            (double Lat, double Lon)[] expected =
            [
                (50.0, 11.0),
                (50.5, 10.5), // lat increases, lon decreases
                (49.5, 11.5), // lat decreases, lon increases
            ];
            RouteLeg leg = new() { Shape = Encode(expected) };

            var decoded = leg.Coordinates();

            Assert.NotNull(decoded);
            Assert.Equal(expected.Length, decoded!.Count);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.Equal(expected[i].Lat, decoded[i].Item1, 5);
                Assert.Equal(expected[i].Lon, decoded[i].Item2, 5);
            }
        }

        [Fact]
        public void Coordinates_ReturnsNull_WhenShapeIsNull()
        {
            RouteLeg leg = new() { Shape = null };

            Assert.Null(leg.Coordinates());
        }

        [Fact]
        public void Coordinates_ReturnsEmptyList_WhenShapeIsEmptyString()
        {
            RouteLeg leg = new() { Shape = string.Empty };

            var decoded = leg.Coordinates();

            Assert.NotNull(decoded);
            Assert.Empty(decoded!);
        }

        /// <summary>
        /// Encodes lat/lon pairs using the standard polyline algorithm at Valhalla's precision of
        /// 1e6, independently of the library's decoder, so the decode test does not simply mirror
        /// the implementation under test.
        /// </summary>
        private static string Encode((double Lat, double Lon)[] points)
        {
            const double Precision = 1e6;
            StringBuilder sb = new();
            long prevLat = 0, prevLon = 0;

            foreach (var (lat, lon) in points)
            {
                long lat5 = (long)Math.Round(lat * Precision);
                long lon5 = (long)Math.Round(lon * Precision);

                EncodeValue(lat5 - prevLat, sb);
                EncodeValue(lon5 - prevLon, sb);

                prevLat = lat5;
                prevLon = lon5;
            }

            return sb.ToString();
        }

        private static void EncodeValue(long value, StringBuilder sb)
        {
            long shifted = value << 1;
            if (value < 0)
            {
                shifted = ~shifted;
            }

            while (shifted >= 0x20)
            {
                sb.Append((char)((0x20 | (shifted & 0x1f)) + 63));
                shifted >>= 5;
            }

            sb.Append((char)(shifted + 63));
        }
    }
}
