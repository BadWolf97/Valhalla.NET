// ----------------------------------------------------------------------------
// <copyright file="IsochroneIntegrationTests.cs" company="Freie Programme Hohenstein">
// Copyright (c) Freie Programme Hohenstein.
// Licensed under Apache-2.0 license. See LICENSE file in the project root for full license information.
// </copyright>
// ----------------------------------------------------------------------------

using System.Net;
using FPH.ValhallaNET.Enums;
using FPH.ValhallaNET.Models;
using FPH.ValhallaNET.Requests;
using FPH.ValhallaNET.Tests.Support;

namespace FPH.ValhallaNET.Tests.Integration
{
    /// <summary>
    /// Integration tests that call GetIsochroneAsync against a real Valhalla server and verify
    /// that <see cref="ValhallaService"/> correctly parses the returned GeoJSON.
    /// </summary>
    public class IsochroneIntegrationTests
    {
        private static readonly Location Center = new() { Latitude = 50.9865, Longitude = 11.0294 };

        [Fact]
        public async Task GetIsochroneAsync_Polygons_ReturnsOneClosedPolygonPerContour()
        {
            var service = TestServer.CreateService();

            var response = await service.GetIsochroneAsync(new IsochroneRequest
            {
                Locations = [Center],
                Costing = CostingModel.pedestrian,
                Contours = [new ContourOptions { Time = 5 }, new ContourOptions { Time = 10 }],
                Polygons = true,
            });

            Assert.Equal("FeatureCollection", response.Type);
            Assert.NotNull(response.Features);
            Assert.Equal(2, response.Features!.Count);

            foreach (var feature in response.Features)
            {
                Assert.Equal(GeometryType.Polygon, feature.Geometry.Type);
                var ring = feature.Geometry.Coordinates[0][0];
                Assert.True(ring.Count > 3);
                Assert.Equal(ring[0][0], ring[^1][0]);
                Assert.Equal(ring[0][1], ring[^1][1]);
            }
        }

        [Fact]
        public async Task GetIsochroneAsync_WithoutPolygons_ReturnsLineStrings()
        {
            var service = TestServer.CreateService();

            var response = await service.GetIsochroneAsync(new IsochroneRequest
            {
                Locations = [Center],
                Costing = CostingModel.pedestrian,
                Contours = [new ContourOptions { Time = 5 }],
                Polygons = false,
            });

            var feature = Assert.Single(response.Features!);
            Assert.Equal(GeometryType.LineString, feature.Geometry.Type);
        }

        [Fact]
        public async Task GetIsochroneAsync_ContourValuesAndMetricRoundTripCorrectly()
        {
            var service = TestServer.CreateService();

            var response = await service.GetIsochroneAsync(new IsochroneRequest
            {
                Locations = [Center],
                Costing = CostingModel.pedestrian,
                Contours = [new ContourOptions { Time = 7 }],
                Polygons = true,
            });

            var properties = response.Features![0].Properties;
            Assert.Equal(7f, properties.Contour);
            Assert.Equal(MetricEnum.Time, properties.Metric);
        }

        [Fact]
        public async Task GetIsochroneAsync_DistanceContour_UsesDistanceMetric()
        {
            var service = TestServer.CreateService();

            var response = await service.GetIsochroneAsync(new IsochroneRequest
            {
                Locations = [Center],
                Costing = CostingModel.pedestrian,
                Contours = [new ContourOptions { Distance = 1 }],
                Polygons = true,
            });

            Assert.Equal(MetricEnum.Distance, response.Features![0].Properties.Metric);
        }

        [Fact]
        public async Task GetIsochroneAsync_InvalidLatitude_ThrowsHttpRequestException()
        {
            var service = TestServer.CreateService();

            HttpRequestException ex = await Assert.ThrowsAsync<HttpRequestException>(() => service.GetIsochroneAsync(new IsochroneRequest
            {
                Locations = [new Location { Latitude = 999, Longitude = 11.0294 }],
                Costing = CostingModel.pedestrian,
                Contours = [new ContourOptions { Time = 5 }],
            }));

            Assert.Equal(HttpStatusCode.BadRequest, ex.StatusCode);
        }
    }
}
