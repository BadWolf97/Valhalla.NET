// ----------------------------------------------------------------------------
// <copyright file="IsochroneResponseDeserializationTests.cs" company="Freie Programme Hohenstein">
// Copyright (c) Freie Programme Hohenstein.
// Licensed under Apache-2.0 license. See LICENSE file in the project root for full license information.
// </copyright>
// ----------------------------------------------------------------------------

using FPH.ValhallaNET.Enums;
using FPH.ValhallaNET.Responses;
using FPH.ValhallaNET.Tests.Support;

namespace FPH.ValhallaNET.Tests.Serialization
{
    /// <summary>
    /// Deterministic tests that verify <see cref="IsochroneResponse"/> is correctly built from real
    /// Valhalla /isochrone JSON payloads (polygons=true and polygons=false) recorded from
    /// https://valhalla.fphst.de, plus a handcrafted MultiPolygon payload for the third geometry shape.
    /// </summary>
    public class IsochroneResponseDeserializationTests
    {
        [Fact]
        public void FromJson_ParsesFeatureCollectionEnvelope()
        {
            string json = Fixture.Load("isochrone_polygon_response.json");

            IsochroneResponse? response = IsochroneResponse.FromJson(json);

            Assert.NotNull(response);
            Assert.Equal("FeatureCollection", response!.Type);
            Assert.NotNull(response.Features);
            Assert.Equal(2, response.Features!.Count);
        }

        [Fact]
        public void FromJson_ParsesPolygonGeometryAsClosedRing()
        {
            string json = Fixture.Load("isochrone_polygon_response.json");

            IsochroneResponse response = IsochroneResponse.FromJson(json)!;
            var feature = response.Features![1];

            Assert.Equal(GeometryType.Polygon, feature.Geometry.Type);
            Assert.Single(feature.Geometry.Coordinates);
            var ring = feature.Geometry.Coordinates[0];
            Assert.Single(ring);
            var points = ring[0];
            Assert.True(points.Count > 3);

            // GeoJSON polygon rings must be closed (first point == last point).
            Assert.Equal(points[0][0], points[^1][0]);
            Assert.Equal(points[0][1], points[^1][1]);
        }

        [Fact]
        public void FromJson_ParsesContourProperties()
        {
            string json = Fixture.Load("isochrone_polygon_response.json");

            IsochroneResponse response = IsochroneResponse.FromJson(json)!;

            Assert.Equal(10, response.Features![0].Properties.Contour);
            Assert.Equal(5, response.Features[1].Properties.Contour);
            Assert.Equal(MetricEnum.Time, response.Features[0].Properties.Metric);
            Assert.Equal("#00ff00", response.Features[0].Properties.Color);
        }

        [Fact]
        public void FromJson_ParsesLineStringGeometry_WhenPolygonsIsFalse()
        {
            string json = Fixture.Load("isochrone_linestring_response.json");

            IsochroneResponse response = IsochroneResponse.FromJson(json)!;
            var feature = Assert.Single(response.Features!);

            Assert.Equal(GeometryType.LineString, feature.Geometry.Type);
            Assert.Single(feature.Geometry.Coordinates);
            Assert.Single(feature.Geometry.Coordinates[0]);
            Assert.True(feature.Geometry.Coordinates[0][0].Count > 3);
        }

        [Fact]
        public void FromJson_ParsesMultiPolygonGeometry()
        {
            string json = Fixture.Load("isochrone_multipolygon_response.json");

            IsochroneResponse response = IsochroneResponse.FromJson(json)!;
            var feature = Assert.Single(response.Features!);

            Assert.Equal(GeometryType.MultiPolygon, feature.Geometry.Type);
            Assert.Equal(2, feature.Geometry.Coordinates.Count);
            Assert.Equal(5, feature.Geometry.Coordinates[0][0].Count);
            Assert.Equal(5, feature.Geometry.Coordinates[1][0].Count);
        }

        [Fact]
        public void FromJson_LineStringCoordinateValuesMatchLonLatOrder()
        {
            // GeoJSON coordinates are [lon, lat], not [lat, lon] - verify the converter does not swap them.
            string json = Fixture.Load("isochrone_linestring_response.json");

            IsochroneResponse response = IsochroneResponse.FromJson(json)!;
            double[] firstPoint = response.Features![0].Geometry.Coordinates[0][0][0];

            Assert.Equal(11.0294, firstPoint[0]);
            Assert.Equal(50.990032, firstPoint[1]);
        }
    }
}
