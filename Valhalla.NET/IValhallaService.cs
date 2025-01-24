// ----------------------------------------------------------------------------
// <copyright file="IValhallaService.cs" company="Freie Programme Hohenstein">
// Copyright (c) Freie Programme Hohenstein.
// Licensed under Apache-2.0 license. See LICENSE file in the project root for full license information.
// </copyright>
// ----------------------------------------------------------------------------

using System.Collections.Specialized;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web;
using FPH.ValhallaNET.Requests;
using FPH.ValhallaNET.Responses;

namespace FPH.ValhallaNET
{
    /// <summary>
    /// Interface for Valhalla service to get route and matrix information.
    /// </summary>
    public interface IValhallaService
    {
        /// <summary>
        /// Asynchronously gets the route information based on the provided route request.
        /// </summary>
        /// <param name="routeRequest">The route request containing the parameters for the route.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the route response.</returns>
        public Task<RouteResponse> GetRouteAsync(RouteRequest routeRequest);

        /// <summary>
        /// Asynchronously gets the matrix information based on the provided matrix request.
        /// </summary>
        /// <param name="routeRequest">The matrix request containing the parameters for the matrix.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the matrix response.</returns>
        public Task<MatrixResponse> GetMatrixAsync(MatrixRequest routeRequest);
    }
}
