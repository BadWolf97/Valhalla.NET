// ----------------------------------------------------------------------------
// <copyright file="MatrixResponseDeserializationTests.cs" company="Freie Programme Hohenstein">
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
    /// Deterministic tests that verify <see cref="MatrixResponse"/> is correctly built from a real
    /// Valhalla /sources_to_targets JSON payload recorded from https://valhalla.fphst.de.
    /// </summary>
    public class MatrixResponseDeserializationTests
    {
        [Fact]
        public void FromJson_ParsesAlgorithmAndUnits()
        {
            // "costmatrix" (all lower case, no separators) must map onto MatrixAlgorithm.CostMatrix.
            string json = Fixture.Load("matrix_response.json");

            MatrixResponse? response = MatrixResponse.FromJson(json);

            Assert.NotNull(response);
            Assert.Equal(MatrixAlgorithm.CostMatrix, response!.Algorithm);
            Assert.Equal(Unit.Kilometers, response.Unit);
        }

        [Fact]
        public void FromJson_ParsesSourcesAndTargets()
        {
            string json = Fixture.Load("matrix_response.json");

            MatrixResponse response = MatrixResponse.FromJson(json)!;

            Assert.NotNull(response.Sources);
            Assert.NotNull(response.Targets);
            Assert.Equal(2, response.Sources!.Length);
            Assert.Equal(2, response.Targets!.Length);
            Assert.Equal(11.029461, response.Sources[0].Longitude);
            Assert.Equal(50.986505, response.Sources[0].Latitude);
        }

        [Fact]
        public void FromJson_MatrixShapeMatchesSourcesTimesTargets()
        {
            string json = Fixture.Load("matrix_response.json");

            MatrixResponse response = MatrixResponse.FromJson(json)!;

            Assert.NotNull(response.Matrix);
            Assert.Equal(response.Sources!.Length, response.Matrix!.Length);
            foreach (var row in response.Matrix)
            {
                Assert.Equal(response.Targets!.Length, row.Length);
            }
        }

        [Fact]
        public void FromJson_TimeDistanceEntriesHaveCorrectIndicesAndValues()
        {
            string json = Fixture.Load("matrix_response.json");

            MatrixResponse response = MatrixResponse.FromJson(json)!;

            var cell = response.Matrix![0][1];
            Assert.Equal(0, cell.FromIndex);
            Assert.Equal(1, cell.ToIndex);
            Assert.Equal(2.176, cell.Distance);
            Assert.Equal(225, cell.Time);
        }

        [Fact]
        public void FromJson_ZeroDistanceForCoincidentSourceAndTarget()
        {
            // sources[1] and targets[0] in the fixture are the exact same coordinate pair, so the
            // matrix cell that pairs them must round-trip to a distance/time of 0.
            string json = Fixture.Load("matrix_response.json");

            MatrixResponse response = MatrixResponse.FromJson(json)!;

            var sameLocationCell = response.Matrix![1][0];
            Assert.Equal(0.0, sameLocationCell.Distance);
            Assert.Equal(0.0, sameLocationCell.Time);
        }

        [Fact]
        public void FromJson_ReturnsEmptyWarnings_WhenFieldAbsent()
        {
            string json = Fixture.Load("matrix_response.json");

            MatrixResponse response = MatrixResponse.FromJson(json)!;

            Assert.Null(response.Warnings);
        }

        [Fact]
        public void FromJson_ParsesWarningsWhenPresent()
        {
            string json = "{\"sources\":[],\"targets\":[],\"sources_to_targets\":[],\"units\":\"kilometers\"," +
                "\"algorithm\":\"costmatrix\",\"warnings\":[\"Not all vertices were found\"]}";

            MatrixResponse response = MatrixResponse.FromJson(json)!;

            Assert.NotNull(response.Warnings);
            Assert.Single(response.Warnings!);
            Assert.Equal("Not all vertices were found", response.Warnings![0]);
        }
    }
}
