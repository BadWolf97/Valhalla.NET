// ----------------------------------------------------------------------------
// <copyright file="RouteIntegrationTests.cs" company="Freie Programme Hohenstein">
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
    /// Integration tests that call GetRouteAsync against a real, running Valhalla server
    /// (https://valhalla.fphst.de by default, override with VALHALLA_TEST_SERVER_URL) and verify
    /// that <see cref="ValhallaService"/> correctly parses whatever the server actually returns.
    /// </summary>
    public class RouteIntegrationTests
    {
        // Two points inside the OSM extract loaded by the test server (Erfurt city center area),
        // confirmed reachable by direct HTTP probing before writing these tests.
        private static readonly Location Origin = new() { Latitude = 50.9865, Longitude = 11.0294 };
        private static readonly Location Waypoint = new() { Latitude = 50.9820, Longitude = 11.0310 };
        private static readonly Location Destination = new() { Latitude = 50.9787, Longitude = 11.0341 };

        [Fact]
        public async Task GetRouteAsync_Auto_ReturnsCompleteTripWithDriveManeuvers()
        {
            var service = TestServer.CreateService();

            var response = await service.GetRouteAsync(new RouteRequest
            {
                Locations = [Origin, Destination],
                Costing = CostingModel.auto,
            });

            Assert.NotNull(response.Trip);
            Assert.Equal(0, response.Trip!.Status);
            Assert.NotNull(response.Trip.Legs);
            Assert.Single(response.Trip.Legs!);

            var maneuvers = response.Trip.Legs![0].Maneuvers;
            Assert.NotNull(maneuvers);
            Assert.True(maneuvers!.Length >= 2);
            Assert.Equal(ManeuverType.Start, maneuvers[0].Type);
            Assert.Equal(ManeuverType.Destination, maneuvers[^1].Type);
            Assert.All(maneuvers, m => Assert.Equal(TravelMode.Drive, m.TravelMode));
            Assert.All(maneuvers, m => Assert.Equal(TravelType.Car, m.TravelType));

            Assert.True(response.Trip.Summary!.Length > 0);
            Assert.True(response.Trip.Summary.Time > 0);
        }

        [Fact]
        public async Task GetRouteAsync_Pedestrian_ReturnsFootTravelMode()
        {
            var service = TestServer.CreateService();

            var response = await service.GetRouteAsync(new RouteRequest
            {
                Locations = [Origin, Destination],
                Costing = CostingModel.pedestrian,
            });

            var maneuvers = response.Trip!.Legs![0].Maneuvers!;
            Assert.All(maneuvers, m => Assert.Equal(TravelMode.Pedestrian, m.TravelMode));
            Assert.All(maneuvers, m => Assert.Equal(TravelType.Foot, m.TravelType));
        }

        [Fact]
        public async Task GetRouteAsync_Bicycle_DefaultHybridType_DoesNotThrowAndParsesTravelType()
        {
            // Regression test: Valhalla's default bicycle_type is "hybrid" (see CostingOptions.BicycleType
            // docs), so an ordinary bicycle route - without overriding costing_options - comes back with
            // "travel_type":"hybrid". TravelType used to be missing that member (and several others, e.g.
            // "wheelchair"/"blind"), which made RouteResponse.FromJson throw for the most common bicycle
            // request instead of just returning a value.
            var service = TestServer.CreateService();

            var response = await service.GetRouteAsync(new RouteRequest
            {
                Locations = [Origin, Destination],
                Costing = CostingModel.bicycle,
            });

            var maneuvers = response.Trip!.Legs![0].Maneuvers!;
            Assert.All(maneuvers, m => Assert.Equal(TravelMode.Bicycle, m.TravelMode));
            Assert.All(maneuvers, m => Assert.Equal(TravelType.Hybrid, m.TravelType));
        }

        [Fact]
        public async Task GetRouteAsync_Bicycle_CostingOptionsOverride_ChangesReturnedTravelType()
        {
            // Regression test: RouteRequest.CostingOptions used to be typed as
            // KeyValuePair<CostingModel, CostingOptions>?, which serializes as {"Key":...,"Value":...}
            // instead of the {"bicycle":{...}} shape Valhalla expects for costing_options. That meant
            // the server silently ignored the override (no error - Valhalla just used its defaults),
            // so requesting a road bike still came back as "hybrid". Now it is a
            // Dictionary<CostingModel, CostingOptions>?, matching MatrixRequest/IsochroneRequest, and
            // the override actually reaches the server.
            var service = TestServer.CreateService();

            var response = await service.GetRouteAsync(new RouteRequest
            {
                Locations = [Origin, Destination],
                Costing = CostingModel.bicycle,
                CostingOptions = new Dictionary<CostingModel, CostingOptions>
                {
                    [CostingModel.bicycle] = new CostingOptions { Costing = CostingModel.bicycle, BicycleType = BicycleType.Road },
                },
            });

            var maneuvers = response.Trip!.Legs![0].Maneuvers!;
            Assert.All(maneuvers, m => Assert.Equal(TravelMode.Bicycle, m.TravelMode));
            Assert.All(maneuvers, m => Assert.Equal(TravelType.Road, m.TravelType));
        }

        [Fact]
        public async Task GetRouteAsync_ThreeLocations_ProducesTwoLegs()
        {
            var service = TestServer.CreateService();

            var response = await service.GetRouteAsync(new RouteRequest
            {
                Locations = [Origin, Waypoint, Destination],
                Costing = CostingModel.auto,
            });

            Assert.Equal(2, response.Trip!.Legs!.Length);
            Assert.Equal(3, response.Trip.Locations!.Length);
        }

        [Fact]
        public async Task GetRouteAsync_DirectionsTypeNone_KnownIssue_ServerIgnoresItDueToCasingBug()
        {
            // This documents a known, NOT-yet-fixed bug: RouteRequest.DirectionsType is sent as
            // "None" (PascalCase) instead of "none" because of how its JsonStringEnumConverter
            // attribute is configured (see ValhallaServiceRequestHandlingTests for the exact
            // mechanism). Valhalla does not recognize "None" and silently keeps its own default
            // (full instructions), so - contrary to what the request asked for - maneuvers are
            // still present. If the underlying serialization bug is ever fixed, this assertion
            // should flip (Maneuvers should become null) and needs to be updated accordingly.
            var service = TestServer.CreateService();

            var response = await service.GetRouteAsync(new RouteRequest
            {
                Locations = [Origin, Destination],
                Costing = CostingModel.auto,
                DirectionsType = DirectionsType.None,
            });

            Assert.NotNull(response.Trip!.Legs);
            Assert.NotNull(response.Trip.Legs![0].Maneuvers);
        }

        [Fact]
        public async Task GetRouteAsync_DecodedShapeAlignsWithRequestedEndpoints()
        {
            var service = TestServer.CreateService();

            var response = await service.GetRouteAsync(new RouteRequest
            {
                Locations = [Origin, Destination],
                Costing = CostingModel.auto,
            });

            var coordinates = response.Trip!.Legs![0].Coordinates()!;

            Assert.True(coordinates.Count > 1);
            Assert.InRange(coordinates[0].Item1, Origin.Latitude - 0.002, Origin.Latitude + 0.002);
            Assert.InRange(coordinates[0].Item2, Origin.Longitude - 0.002, Origin.Longitude + 0.002);
            Assert.InRange(coordinates[^1].Item1, Destination.Latitude - 0.002, Destination.Latitude + 0.002);
            Assert.InRange(coordinates[^1].Item2, Destination.Longitude - 0.002, Destination.Longitude + 0.002);
        }

        [Fact]
        public async Task GetRouteAsync_LocationOffsetFromRoad_PopulatesSideOfStreet()
        {
            // Regression test for the "side_of street" (space instead of underscore) property
            // name bug in Location.cs: request a break location whose display point is offset
            // from the routing point so Valhalla computes and returns "side_of_street", then
            // assert the client actually surfaces it.
            var service = TestServer.CreateService();

            var offsetOrigin = new Location
            {
                Latitude = 50.9867,
                Longitude = 11.0295,
                DisplayLat = 50.9867,
                DisplayLon = 11.0300,
            };

            var response = await service.GetRouteAsync(new RouteRequest
            {
                Locations = [offsetOrigin, Destination],
                Costing = CostingModel.auto,
            });

            Assert.NotNull(response.Trip!.Locations);
            Assert.True(
                response.Trip.Locations![0].SideOfStreet.HasValue,
                "Expected the server-reported side_of_street to be deserialized onto Location.SideOfStreet.");
        }

        [Fact]
        public async Task GetRouteAsync_InvalidLatitude_ThrowsHttpRequestExceptionWithServerErrorDetails()
        {
            var service = TestServer.CreateService();

            HttpRequestException ex = await Assert.ThrowsAsync<HttpRequestException>(() => service.GetRouteAsync(new RouteRequest
            {
                Locations = [new Location { Latitude = 999, Longitude = 11.0294 }, Destination],
                Costing = CostingModel.auto,
            }));

            Assert.Equal(HttpStatusCode.BadRequest, ex.StatusCode);
            Assert.Contains("error", ex.Message, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public async Task GetRouteAsync_SingleLocation_Throws()
        {
            var service = TestServer.CreateService();

            await Assert.ThrowsAsync<HttpRequestException>(() => service.GetRouteAsync(new RouteRequest
            {
                Locations = [Origin],
                Costing = CostingModel.auto,
            }));
        }
    }
}
