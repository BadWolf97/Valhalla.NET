// ----------------------------------------------------------------------------
// <copyright file="GeometryJsonConverterTests.cs" company="Freie Programme Hohenstein">
// Copyright (c) Freie Programme Hohenstein.
// Licensed under Apache-2.0 license. See LICENSE file in the project root for full license information.
// </copyright>
// ----------------------------------------------------------------------------

using System.Text.Json;
using FPH.ValhallaNET.Converters;
using FPH.ValhallaNET.Enums;
using FPH.ValhallaNET.Models;

namespace FPH.ValhallaNET.Tests.Serialization
{
    /// <summary>
    /// Round-trip tests for <see cref="GeometryJsonConverter"/> across all three geometry shapes
    /// that a Valhalla isochrone response can return.
    /// </summary>
    public class GeometryJsonConverterTests
    {
        private static readonly JsonSerializerOptions Options = new()
        {
            Converters = { new GeometryJsonConverter() },
        };

        [Fact]
        public void RoundTrip_LineString()
        {
            Geometry original = new()
            {
                Type = GeometryType.LineString,
                Coordinates = [[[[1.0, 2.0], [3.0, 4.0]]]],
            };

            string json = JsonSerializer.Serialize(original, Options);
            Geometry? result = JsonSerializer.Deserialize<Geometry>(json, Options);

            Assert.NotNull(result);
            Assert.Equal(GeometryType.LineString, result!.Type);
            Assert.Equal(original.Coordinates, result.Coordinates);
        }

        [Fact]
        public void RoundTrip_Polygon()
        {
            Geometry original = new()
            {
                Type = GeometryType.Polygon,
                Coordinates = [[[[0.0, 0.0], [1.0, 0.0], [1.0, 1.0], [0.0, 0.0]]]],
            };

            string json = JsonSerializer.Serialize(original, Options);
            Geometry? result = JsonSerializer.Deserialize<Geometry>(json, Options);

            Assert.NotNull(result);
            Assert.Equal(GeometryType.Polygon, result!.Type);
            Assert.Equal(original.Coordinates, result.Coordinates);
        }

        [Fact]
        public void RoundTrip_MultiPolygon()
        {
            Geometry original = new()
            {
                Type = GeometryType.MultiPolygon,
                Coordinates =
                [
                    [[[0.0, 0.0], [1.0, 0.0], [1.0, 1.0], [0.0, 0.0]]],
                    [[[5.0, 5.0], [6.0, 5.0], [6.0, 6.0], [5.0, 5.0]]],
                ],
            };

            string json = JsonSerializer.Serialize(original, Options);
            Geometry? result = JsonSerializer.Deserialize<Geometry>(json, Options);

            Assert.NotNull(result);
            Assert.Equal(GeometryType.MultiPolygon, result!.Type);
            Assert.Equal(original.Coordinates, result.Coordinates);
        }

        [Fact]
        public void Write_Polygon_ThrowsWhenCoordinateStructureDoesNotMatchType()
        {
            Geometry invalid = new()
            {
                Type = GeometryType.Polygon,

                // A Polygon geometry must contain exactly one ring - two rings is invalid for this type.
                Coordinates =
                [
                    [[[0.0, 0.0], [1.0, 0.0]]],
                    [[[5.0, 5.0], [6.0, 5.0]]],
                ],
            };

            Assert.Throws<JsonException>(() => JsonSerializer.Serialize(invalid, Options));
        }

        [Fact]
        public void Write_LineString_ThrowsWhenCoordinateStructureDoesNotMatchType()
        {
            Geometry invalid = new()
            {
                Type = GeometryType.LineString,

                // A LineString must contain exactly one ring with one point-set - two point-sets is invalid.
                Coordinates =
                [
                    [[[0.0, 0.0], [1.0, 0.0]], [[2.0, 2.0], [3.0, 3.0]]],
                ],
            };

            Assert.Throws<JsonException>(() => JsonSerializer.Serialize(invalid, Options));
        }

        [Fact]
        public void Read_ThrowsJsonException_WhenTypeIsMissing()
        {
            string json = "{\"coordinates\":[[1.0,2.0],[3.0,4.0]]}";

            Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<Geometry>(json, Options));
        }

        [Fact]
        public void Read_IsCaseInsensitiveForGeometryTypeValue()
        {
            string json = "{\"type\":\"linestring\",\"coordinates\":[[1.0,2.0],[3.0,4.0]]}";

            Geometry? result = JsonSerializer.Deserialize<Geometry>(json, Options);

            Assert.NotNull(result);
            Assert.Equal(GeometryType.LineString, result!.Type);
        }
    }
}
