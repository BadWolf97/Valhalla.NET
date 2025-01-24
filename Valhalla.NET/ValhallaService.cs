// ----------------------------------------------------------------------------
// <copyright file="ValhallaService.cs" company="Freie Programme Hohenstein">
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
    /// The Valhalla Service to get route and matrix information.
    /// </summary>
    public class ValhallaService : IValhallaService
    {
        private readonly HttpClient httpClient;
        private readonly string apiUrl;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValhallaService"/> class.
        /// </summary>
        /// <param name="apiUrl">The Base API-URL.</param>
        /// <param name="httpClient">An httpClient.</param>
        public ValhallaService(string apiUrl, HttpClient httpClient)
        {
            this.apiUrl = apiUrl.TrimEnd('/');
            this.httpClient = httpClient;
        }

        /// <summary>
        /// Asynchronously gets the route information based on the provided route request.
        /// </summary>
        /// <param name="routeRequest">The RouteRequest containing the request.</param>
        /// <returns>The RouteResponse containing the response.</returns>
        public async Task<RouteResponse> GetRouteAsync(RouteRequest routeRequest)
        {
            try
            {
                string requestUrl = $"{this.apiUrl}/route";

                string content = await this.PostRequestAsync(requestUrl, routeRequest);
                RouteResponse? response = RouteResponse.FromJson(content);
                if (response == null)
                {
                    throw new Exception("Deserialization not successfull.");
                }

                return response;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Asynchronously gets the matrix information based on the provided matrix request.
        /// </summary>
        /// <param name="routeRequest">The MatrixRequest containing the request.</param>
        /// <returns>The MatrixResponse containing the response.</returns>
        public async Task<MatrixResponse> GetMatrixAsync(MatrixRequest routeRequest)
        {
            try
            {
                string requestUrl = $"{this.apiUrl}/sources_to_targets";

                string content = await this.GetRequestAsync(requestUrl, routeRequest);
                MatrixResponse? response = MatrixResponse.FromJson(content);
                if (response == null)
                {
                    throw new Exception("Deserialization not successfull.");
                }

                return response;
            }
            catch
            {
                throw;
            }
        }

        private async Task<string> PostRequestAsync(string url, object payload)
        {
            var options = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) },
            };
            HttpResponseMessage response = await this.httpClient.PostAsJsonAsync(url, payload, options);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            throw new HttpRequestException(await response.Content.ReadAsStringAsync(), null, response.StatusCode);
        }

        private async Task<string> GetRequestAsync(string url, object payload)
        {
            var options = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) },
            };
            string jsonRequest = JsonSerializer.Serialize(payload, options);
            if (string.IsNullOrEmpty(jsonRequest))
            {
                throw new Exception("Serialization not successfull.");
            }

            UriBuilder ub = new UriBuilder(url);
            NameValueCollection nvc = HttpUtility.ParseQueryString(ub.Query);
            nvc.Add("json", jsonRequest);
            ub.Query = nvc.ToString();

            HttpResponseMessage response = await this.httpClient.GetAsync(ub.ToString());

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            throw new HttpRequestException(await response.Content.ReadAsStringAsync(), null, response.StatusCode);
        }
    }
}
