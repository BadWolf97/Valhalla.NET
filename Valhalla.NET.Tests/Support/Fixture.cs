// ----------------------------------------------------------------------------
// <copyright file="Fixture.cs" company="Freie Programme Hohenstein">
// Copyright (c) Freie Programme Hohenstein.
// Licensed under Apache-2.0 license. See LICENSE file in the project root for full license information.
// </copyright>
// ----------------------------------------------------------------------------

namespace FPH.ValhallaNET.Tests.Support
{
    /// <summary>
    /// Loads recorded/handcrafted Valhalla JSON responses used by the deterministic unit tests.
    /// </summary>
    public static class Fixture
    {
        /// <summary>
        /// Reads a fixture file from the Fixtures directory next to the test assembly.
        /// </summary>
        /// <param name="fileName">The file name of the fixture, e.g. "route_auto_response.json".</param>
        /// <returns>The raw file content.</returns>
        public static string Load(string fileName)
        {
            string path = Path.Combine(AppContext.BaseDirectory, "Fixtures", fileName);
            return File.ReadAllText(path);
        }
    }
}
