using FPH.ValhallaNET.Requests;
using FPH.ValhallaNET.Responses;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace FPH.ValhallaNET
{
    public interface IValhallaService
    {
        public Task<RouteResponse> GetRouteAsync(RouteRequest routeRequest);
        public Task<MatrixResponse > GetMatrixAsync(MatrixRequest  routeRequest);
    }
    public class ValhallaService : IValhallaService
    {
        private readonly HttpClient httpClient;
        private readonly string apiUrl;

        public ValhallaService(string apiUrl, HttpClient httpClient)
        {
            this.apiUrl = apiUrl;
            this.httpClient = httpClient;
        }

        private async Task<string> GetRequestAsync(string url, object payload)
        {
            var options = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(url, payload, options);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            throw new HttpRequestException(await response.Content.ReadAsStringAsync(), null, response.StatusCode);
        }
        public async Task<RouteResponse> GetRouteAsync(RouteRequest routeRequest)
        {
            try
            {
                string requestUrl = $"{apiUrl}/route";

                string content = await GetRequestAsync(requestUrl, routeRequest);
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
        public async Task<MatrixResponse> GetMatrixAsync(MatrixRequest routeRequest)
        {
            try
            {
                string requestUrl = $"{apiUrl}/sources_to_targets";

                string content = await GetRequestAsync(requestUrl, routeRequest);
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
    }
}
