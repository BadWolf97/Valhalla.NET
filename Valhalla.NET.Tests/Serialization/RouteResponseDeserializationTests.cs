// ----------------------------------------------------------------------------
// <copyright file="RouteResponseDeserializationTests.cs" company="Freie Programme Hohenstein">
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
    /// Deterministic tests that verify <see cref="RouteResponse"/> is correctly built from real
    /// Valhalla /route JSON payloads recorded from https://valhalla.fphst.de.
    /// </summary>
    public class RouteResponseDeserializationTests
    {
        [Fact]
        public void FromJson_ParsesTopLevelTripFields()
        {
            string json = Fixture.Load("route_auto_response.json");

            RouteResponse? response = RouteResponse.FromJson(json);

            Assert.NotNull(response);
            Assert.NotNull(response!.Trip);
            Assert.Equal(0, response.Trip!.Status);
            Assert.Equal("Found route between points", response.Trip.StatusMessage);
            Assert.Equal(Unit.Kilometers, response.Trip.Units);
            Assert.Equal("en-US", response.Trip.Language);
        }

        [Fact]
        public void FromJson_ParsesLocations()
        {
            string json = Fixture.Load("route_auto_response.json");

            RouteResponse response = RouteResponse.FromJson(json)!;

            Assert.NotNull(response.Trip!.Locations);
            Assert.Equal(2, response.Trip.Locations!.Length);
            Assert.Equal(50.9865, response.Trip.Locations[0].Latitude);
            Assert.Equal(11.0294, response.Trip.Locations[0].Longitude);
            Assert.Equal(LocationType.Break, response.Trip.Locations[0].Type);
        }

        [Fact]
        public void FromJson_ParsesRouteSummary()
        {
            string json = Fixture.Load("route_auto_response.json");

            RouteResponse response = RouteResponse.FromJson(json)!;

            Assert.NotNull(response.Trip!.Summary);
            Assert.Equal(171.925, response.Trip.Summary!.Time);
            Assert.Equal(1.527, response.Trip.Summary.Length);
            Assert.False(response.Trip.Summary.HasToll);
            Assert.False(response.Trip.Summary.HasHighway);
            Assert.Equal(50.978227, response.Trip.Summary.MinLat);
            Assert.Equal(11.040123, response.Trip.Summary.MaxLon);
        }

        [Fact]
        public void FromJson_ParsesLegsAndManeuvers()
        {
            string json = Fixture.Load("route_auto_response.json");

            RouteResponse response = RouteResponse.FromJson(json)!;

            Assert.NotNull(response.Trip!.Legs);
            Assert.Single(response.Trip.Legs!);

            var maneuvers = response.Trip.Legs![0].Maneuvers;
            Assert.NotNull(maneuvers);
            Assert.Equal(6, maneuvers!.Length);
        }

        [Fact]
        public void FromJson_MapsNumericManeuverTypeToEnum()
        {
            // Valhalla sends the maneuver "type" as an integer, not a string. The library uses a
            // custom JsonNumberEnumConverter<ManeuverType> for this - verify it actually maps the
            // documented codes to the matching enum members instead of silently defaulting to 0/None.
            string json = Fixture.Load("route_auto_response.json");

            RouteResponse response = RouteResponse.FromJson(json)!;
            var maneuvers = response.Trip!.Legs![0].Maneuvers!;

            Assert.Equal(ManeuverType.Start, maneuvers[0].Type);
            Assert.Equal(ManeuverType.Right, maneuvers[1].Type);
            Assert.Equal(ManeuverType.Right, maneuvers[2].Type);
            Assert.Equal(ManeuverType.Left, maneuvers[3].Type);
            Assert.Equal(ManeuverType.Right, maneuvers[4].Type);
            Assert.Equal(ManeuverType.Destination, maneuvers[5].Type);
        }

        [Fact]
        public void FromJson_MapsTravelModeAndTravelTypeStringEnums()
        {
            // travel_mode/travel_type arrive lower-cased ("drive"/"car") while the C# enum members
            // are PascalCase ("Drive"/"Car"). Verify the case-insensitive string enum matching works
            // end-to-end for a real payload.
            string json = Fixture.Load("route_auto_response.json");

            RouteResponse response = RouteResponse.FromJson(json)!;
            var maneuver = response.Trip!.Legs![0].Maneuvers![0];

            Assert.Equal(TravelMode.Drive, maneuver.TravelMode);
            Assert.Equal(TravelType.Car, maneuver.TravelType);
        }

        [Fact]
        public void FromJson_IgnoresUnknownFieldsWithoutThrowing()
        {
            // The fixture contains fields the model does not declare (e.g. summary.cost,
            // summary.has_time_restrictions, maneuver.sign as an empty object). None of these
            // should cause deserialization to fail.
            string json = Fixture.Load("route_auto_response.json");

            RouteResponse? response = RouteResponse.FromJson(json);

            Assert.NotNull(response);
        }

        [Fact]
        public void FromJson_DecodesPolylineShapeIntoCoordinatesNearRequestEndpoints()
        {
            string json = Fixture.Load("route_auto_response.json");
            RouteResponse response = RouteResponse.FromJson(json)!;

            var coordinates = response.Trip!.Legs![0].Coordinates();

            Assert.NotNull(coordinates);
            Assert.True(coordinates!.Count > 1);

            var first = coordinates[0];
            var last = coordinates[^1];

            // Decoded shape should start/end close to the requested origin/destination.
            Assert.InRange(first.Item1, 50.985, 50.988);
            Assert.InRange(first.Item2, 11.028, 11.031);
            Assert.InRange(last.Item1, 50.977, 50.980);
            Assert.InRange(last.Item2, 11.032, 11.035);
        }

        [Fact]
        public void FromJson_MapsSideOfStreetOnLocations()
        {
            // Regression test: Location.SideOfStreet was mapped with the JSON property name
            // "side_of street" (a literal space instead of an underscore), so Valhalla's actual
            // "side_of_street" field was silently dropped and always deserialized as null.
            string json = Fixture.Load("route_side_of_street_response.json");

            RouteResponse response = RouteResponse.FromJson(json)!;

            Assert.NotNull(response.Trip!.Locations);
            Assert.Equal(SideOfStreet.Right, response.Trip.Locations![0].SideOfStreet);
            Assert.Null(response.Trip.Locations[1].SideOfStreet);
        }

        [Fact]
        public void FromJson_ReturnsNullTripPropertiesGracefully_ForMinimalResponse()
        {
            string json = "{\"trip\":{\"status\":0}}";

            RouteResponse? response = RouteResponse.FromJson(json);

            Assert.NotNull(response);
            Assert.NotNull(response!.Trip);
            Assert.Equal(0, response.Trip!.Status);
            Assert.Null(response.Trip.Legs);
            Assert.Null(response.Trip.Locations);
            Assert.Null(response.Trip.Summary);
        }

        [Fact]
        public void FromJson_ParsesRouteIdWhenPresent()
        {
            string json = "{\"id\":\"my-request-id\",\"trip\":{\"status\":0,\"id\":\"my-request-id\"}}";

            RouteResponse response = RouteResponse.FromJson(json)!;

            Assert.Equal("my-request-id", response.Id);
            Assert.Equal("my-request-id", response.Trip!.Id);
        }

        [Fact]
        public void FromJson_ReturnsNull_ForJsonNullLiteral()
        {
            Assert.Null(RouteResponse.FromJson("null"));
        }
    }
}
