// ----------------------------------------------------------------------------
// <copyright file="ValhallaServiceRequestHandlingTests.cs" company="Freie Programme Hohenstein">
// Copyright (c) Freie Programme Hohenstein.
// Licensed under Apache-2.0 license. See LICENSE file in the project root for full license information.
// </copyright>
// ----------------------------------------------------------------------------

using System.Net;
using System.Text;
using FPH.ValhallaNET.Enums;
using FPH.ValhallaNET.Models;
using FPH.ValhallaNET.Requests;
using FPH.ValhallaNET.Tests.Support;

namespace FPH.ValhallaNET.Tests.Serialization
{
    /// <summary>
    /// Tests <see cref="ValhallaService"/>'s handling of HTTP responses (success, failure, and
    /// malformed bodies) using a stubbed <see cref="HttpMessageHandler"/> instead of the network,
    /// so these run deterministically regardless of the live server's availability. The live
    /// server's actual behavior for these same scenarios is covered separately in Integration/.
    /// </summary>
    public class ValhallaServiceRequestHandlingTests
    {
        [Fact]
        public async Task GetRouteAsync_ReturnsParsedResponse_OnSuccess()
        {
            string body = Fixture.Load("route_auto_response.json");
            FakeHttpMessageHandler handler = new(_ => new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(body, Encoding.UTF8, "application/json"),
            });
            ValhallaService service = new("https://valhalla.fphst.de", new HttpClient(handler));

            RouteRequest request = new()
            {
                Locations = [Location(50.9865, 11.0294), Location(50.9787, 11.0341)],
                Costing = CostingModel.auto,
            };

            var response = await service.GetRouteAsync(request);

            Assert.NotNull(response.Trip);
            Assert.Equal(0, response.Trip!.Status);
        }

        [Fact]
        public async Task GetRouteAsync_PostsToRouteEndpoint()
        {
            FakeHttpMessageHandler handler = new(_ => new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(Fixture.Load("route_auto_response.json"), Encoding.UTF8, "application/json"),
            });
            ValhallaService service = new("https://valhalla.fphst.de/", new HttpClient(handler));

            await service.GetRouteAsync(new RouteRequest
            {
                Locations = [Location(50.9865, 11.0294), Location(50.9787, 11.0341)],
                Costing = CostingModel.auto,
            });

            Assert.Equal(HttpMethod.Post, handler.LastRequest!.Method);

            // A trailing slash on the base URL must not produce a double slash in the request path.
            Assert.Equal("https://valhalla.fphst.de/route", handler.LastRequestUri);
        }

        [Fact]
        public async Task GetRouteAsync_Throws_WithServerErrorBody_OnBadRequest()
        {
            string errorBody = Fixture.Load("error_response.json");
            FakeHttpMessageHandler handler = new(_ => new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent(errorBody, Encoding.UTF8, "application/json"),
            });
            ValhallaService service = new("https://valhalla.fphst.de", new HttpClient(handler));

            HttpRequestException ex = await Assert.ThrowsAsync<HttpRequestException>(() => service.GetRouteAsync(new RouteRequest
            {
                Locations = [Location(999, 11.0294), Location(50.9787, 11.0341)],
                Costing = CostingModel.auto,
            }));

            Assert.Equal(HttpStatusCode.BadRequest, ex.StatusCode);
            Assert.Contains("Failed to parse location", ex.Message);
        }

        [Fact]
        public async Task GetRouteAsync_Throws_WhenBodyIsJsonNull()
        {
            FakeHttpMessageHandler handler = new(_ => new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("null", Encoding.UTF8, "application/json"),
            });
            ValhallaService service = new("https://valhalla.fphst.de", new HttpClient(handler));

            await Assert.ThrowsAsync<Exception>(() => service.GetRouteAsync(new RouteRequest
            {
                Locations = [Location(50.9865, 11.0294), Location(50.9787, 11.0341)],
                Costing = CostingModel.auto,
            }));
        }

        [Fact]
        public async Task GetMatrixAsync_SendsGetRequestWithJsonQueryParameter()
        {
            FakeHttpMessageHandler handler = new(_ => new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(Fixture.Load("matrix_response.json"), Encoding.UTF8, "application/json"),
            });
            ValhallaService service = new("https://valhalla.fphst.de", new HttpClient(handler));

            MatrixRequest request = new()
            {
                Sources = [new MatrixLocation { Latitude = 50.9865, Longitude = 11.0294 }],
                Targets = [new MatrixLocation { Latitude = 50.9787, Longitude = 11.0341 }],
                Costing = CostingModel.auto,
            };

            await service.GetMatrixAsync(request);

            Assert.Equal(HttpMethod.Get, handler.LastRequest!.Method);
            Assert.StartsWith("https://valhalla.fphst.de/sources_to_targets?json=", handler.LastRequestUri);
            Assert.Contains("sources", Uri.UnescapeDataString(handler.LastRequestUri!));
        }

        [Fact]
        public async Task GetMatrixAsync_ReturnsParsedResponse_OnSuccess()
        {
            FakeHttpMessageHandler handler = new(_ => new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(Fixture.Load("matrix_response.json"), Encoding.UTF8, "application/json"),
            });
            ValhallaService service = new("https://valhalla.fphst.de", new HttpClient(handler));

            var response = await service.GetMatrixAsync(new MatrixRequest
            {
                Sources = [new MatrixLocation { Latitude = 50.9865, Longitude = 11.0294 }],
                Targets = [new MatrixLocation { Latitude = 50.9787, Longitude = 11.0341 }],
                Costing = CostingModel.auto,
            });

            Assert.Equal(MatrixAlgorithm.CostMatrix, response.Algorithm);
        }

        [Fact]
        public async Task GetMatrixAsync_Throws_WithServerErrorBody_OnBadRequest()
        {
            string errorBody = Fixture.Load("error_response.json");
            FakeHttpMessageHandler handler = new(_ => new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent(errorBody, Encoding.UTF8, "application/json"),
            });
            ValhallaService service = new("https://valhalla.fphst.de", new HttpClient(handler));

            HttpRequestException ex = await Assert.ThrowsAsync<HttpRequestException>(() => service.GetMatrixAsync(new MatrixRequest
            {
                Sources = [new MatrixLocation { Latitude = 999, Longitude = 11.0294 }],
                Targets = [new MatrixLocation { Latitude = 50.9787, Longitude = 11.0341 }],
                Costing = CostingModel.auto,
            }));

            Assert.Equal(HttpStatusCode.BadRequest, ex.StatusCode);
        }

        [Fact]
        public async Task GetIsochroneAsync_ReturnsParsedResponse_OnSuccess()
        {
            FakeHttpMessageHandler handler = new(_ => new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(Fixture.Load("isochrone_polygon_response.json"), Encoding.UTF8, "application/json"),
            });
            ValhallaService service = new("https://valhalla.fphst.de", new HttpClient(handler));

            var response = await service.GetIsochroneAsync(new IsochroneRequest
            {
                Locations = [Location(50.9865, 11.0294)],
                Costing = CostingModel.pedestrian,
                Contours = [new ContourOptions { Time = 5 }, new ContourOptions { Time = 10 }],
                Polygons = true,
            });

            Assert.Equal(2, response.Features!.Count);
        }

        [Fact]
        public async Task GetIsochroneAsync_PostsToIsochroneEndpoint()
        {
            FakeHttpMessageHandler handler = new(_ => new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(Fixture.Load("isochrone_polygon_response.json"), Encoding.UTF8, "application/json"),
            });
            ValhallaService service = new("https://valhalla.fphst.de", new HttpClient(handler));

            await service.GetIsochroneAsync(new IsochroneRequest
            {
                Locations = [Location(50.9865, 11.0294)],
                Costing = CostingModel.pedestrian,
                Contours = [new ContourOptions { Time = 5 }],
            });

            Assert.Equal("https://valhalla.fphst.de/isochrone", handler.LastRequestUri);
        }

        [Fact]
        public async Task GetRouteAsync_KnownIssue_DirectionsTypeIsSerializedWithWrongCasing()
        {
            // KNOWN BUG (not fixed here - it's a request-serialization issue, not a response-parsing
            // one, and fixing it properly needs a dedicated enum-naming strategy across several
            // properties, see the summary of this test session for details):
            //
            // RouteRequest.DirectionsType is decorated with a bare [JsonConverter(typeof(JsonStringEnumConverter))]
            // attribute. Attribute-level converters take precedence over the JsonStringEnumConverter(CamelCase)
            // instance that ValhallaService.PostRequestAsync adds to its JsonSerializerOptions, so the enum
            // is written using its literal PascalCase member name ("None") instead of the lower-cased value
            // Valhalla's API expects ("none"). Confirmed against the live server: requesting directions_type
            // "None" has no effect and Valhalla still returns full turn-by-turn maneuvers - see
            // RouteIntegrationTests for the corresponding live-server observation.
            FakeHttpMessageHandler handler = new(_ => new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(Fixture.Load("route_auto_response.json"), Encoding.UTF8, "application/json"),
            });
            ValhallaService service = new("https://valhalla.fphst.de", new HttpClient(handler));

            await service.GetRouteAsync(new RouteRequest
            {
                Locations = [Location(50.9865, 11.0294), Location(50.9787, 11.0341)],
                Costing = CostingModel.auto,
                DirectionsType = FPH.ValhallaNET.Enums.DirectionsType.None,
            });

            Assert.Contains("\"directions_type\":\"None\"", handler.LastRequestBody);
        }

        [Fact]
        public async Task GetRouteAsync_SerializesBicycleTypeWithItsExactCasing()
        {
            // Unlike almost every other Valhalla enum value (lower_snake_case), bicycle_type is one
            // of the few fields Valhalla expects in its literal capitalized form ("Road", "Hybrid",
            // "City", "Cross", "Mountain") - confirmed against the live server: sending "road"
            // (lower case) is silently ignored and the route falls back to the "Hybrid" default,
            // while "Road" is honored. BicycleType therefore needs its own bare JsonStringEnumConverter
            // instead of the CamelCase-policy converter ValhallaService applies globally (which would
            // lower-case the leading letter and reintroduce this bug).
            FakeHttpMessageHandler handler = new(_ => new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(Fixture.Load("route_auto_response.json"), Encoding.UTF8, "application/json"),
            });
            ValhallaService service = new("https://valhalla.fphst.de", new HttpClient(handler));

            await service.GetRouteAsync(new RouteRequest
            {
                Locations = [Location(50.9865, 11.0294), Location(50.9787, 11.0341)],
                Costing = CostingModel.bicycle,
                CostingOptions = new Dictionary<CostingModel, CostingOptions>
                {
                    [CostingModel.bicycle] = new CostingOptions { Costing = CostingModel.bicycle, BicycleType = BicycleType.Road },
                },
            });

            Assert.Contains("\"bicycle_type\":\"Road\"", handler.LastRequestBody);
        }

        private static Location Location(double lat, double lon) => new() { Latitude = lat, Longitude = lon };
    }
}
