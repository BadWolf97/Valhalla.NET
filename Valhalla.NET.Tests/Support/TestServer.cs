// ----------------------------------------------------------------------------
// <copyright file="TestServer.cs" company="Freie Programme Hohenstein">
// Copyright (c) Freie Programme Hohenstein.
// Licensed under Apache-2.0 license. See LICENSE file in the project root for full license information.
// </copyright>
// ----------------------------------------------------------------------------

using FPH.ValhallaNET;

namespace FPH.ValhallaNET.Tests.Support
{
    /// <summary>
    /// Shared configuration for tests that talk to a live Valhalla server.
    /// </summary>
    public static class TestServer
    {
        /// <summary>
        /// Gets the base URL of the Valhalla server used for integration tests.
        /// Can be overridden with the VALHALLA_TEST_SERVER_URL environment variable.
        /// </summary>
        public static string BaseUrl => Environment.GetEnvironmentVariable("VALHALLA_TEST_SERVER_URL")
            ?? "https://valhalla.fphst.de";

        /// <summary>
        /// Creates a new <see cref="ValhallaService"/> pointed at the test server.
        /// </summary>
        /// <returns>A configured <see cref="ValhallaService"/>.</returns>
        public static ValhallaService CreateService()
        {
            HttpClient httpClient = new()
            {
                Timeout = TimeSpan.FromSeconds(30),
            };
            return new ValhallaService(BaseUrl, httpClient);
        }
    }
}
