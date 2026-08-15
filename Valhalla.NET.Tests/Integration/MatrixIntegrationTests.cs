// ----------------------------------------------------------------------------
// <copyright file="MatrixIntegrationTests.cs" company="Freie Programme Hohenstein">
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
    /// Integration tests that call GetMatrixAsync against a real Valhalla server and verify that
    /// <see cref="ValhallaService"/> correctly builds the GET request and parses the response.
    /// </summary>
    public class MatrixIntegrationTests
    {
        private static readonly MatrixLocation PointA = new() { Latitude = 50.9865, Longitude = 11.0294 };
        private static readonly MatrixLocation PointB = new() { Latitude = 50.9787, Longitude = 11.0341 };
        private static readonly MatrixLocation PointC = new() { Latitude = 50.9800, Longitude = 11.0300 };

        [Fact]
        public async Task GetMatrixAsync_ReturnsMatrixShapedAsSourcesTimesTargets()
        {
            var service = TestServer.CreateService();

            var response = await service.GetMatrixAsync(new MatrixRequest
            {
                Sources = [PointA, PointB],
                Targets = [PointB, PointC],
                Costing = CostingModel.auto,
            });

            Assert.Equal(MatrixAlgorithm.CostMatrix, response.Algorithm);
            Assert.Equal(2, response.Sources!.Length);
            Assert.Equal(2, response.Targets!.Length);
            Assert.Equal(2, response.Matrix!.Length);
            Assert.All(response.Matrix, row => Assert.Equal(2, row.Length));

            foreach (var row in response.Matrix)
            {
                foreach (var cell in row)
                {
                    Assert.True(cell.Distance >= 0);
                    Assert.True(cell.Time >= 0);
                }
            }
        }

        [Fact]
        public async Task GetMatrixAsync_SameSourceAndTarget_YieldsZeroDistance()
        {
            var service = TestServer.CreateService();

            var response = await service.GetMatrixAsync(new MatrixRequest
            {
                Sources = [PointA],
                Targets = [PointA],
                Costing = CostingModel.auto,
            });

            var cell = response.Matrix![0][0];
            Assert.Equal(0.0, cell.Distance);
            Assert.Equal(0.0, cell.Time);
            Assert.Equal(0, cell.FromIndex);
            Assert.Equal(0, cell.ToIndex);
        }

        [Fact]
        public async Task GetMatrixAsync_PedestrianCosting_ReturnsPlausibleWalkingTimes()
        {
            var service = TestServer.CreateService();

            var response = await service.GetMatrixAsync(new MatrixRequest
            {
                Sources = [PointA],
                Targets = [PointB],
                Costing = CostingModel.pedestrian,
            });

            var cell = response.Matrix![0][0];

            // Walking should be slower than driving over the same short distance but the trip must
            // still complete in well under an hour for a ~1.5 km trip.
            Assert.True(cell.Time > 0);
            Assert.True(cell.Time < 3600);
        }

        [Fact]
        public async Task GetMatrixAsync_InvalidLatitude_ThrowsHttpRequestException()
        {
            var service = TestServer.CreateService();

            HttpRequestException ex = await Assert.ThrowsAsync<HttpRequestException>(() => service.GetMatrixAsync(new MatrixRequest
            {
                Sources = [new MatrixLocation { Latitude = 999, Longitude = 11.0294 }],
                Targets = [PointB],
                Costing = CostingModel.auto,
            }));

            Assert.Equal(HttpStatusCode.BadRequest, ex.StatusCode);
        }
    }
}
