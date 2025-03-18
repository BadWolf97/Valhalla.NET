using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FPH.ValhallaNET;
using FPH.ValhallaNET.Requests;
using FPH.ValhallaNET.Responses;
using Moq;
using Moq.Protected;
using NUnit.Framework;

namespace ValhallaTests
{
    [TestFixture]
    public class ValhallaServiceTests
    {
        private Mock<HttpMessageHandler> httpMessageHandlerMock;
        private HttpClient httpClient;
        private ValhallaService valhallaService;

        [SetUp]
        public void SetUp()
        {
            httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            httpClient = new HttpClient(httpMessageHandlerMock.Object);
            valhallaService = new ValhallaService("https://valhalla.fphst.de", httpClient);
        }

        [Test]
        public async Task GetRouteAsync_ShouldReturnRouteResponse_WhenRequestIsSuccessful()
        {
            // Arrange
            var routeRequest = new RouteRequest { Locations = new[] { new Location { Latitude = 52.52, Longitude = 13.405 } } };
            var routeResponseJson = "{\"id\":\"test\",\"trip\":{}}";
            httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(routeResponseJson)
                });

            // Act
            var result = await valhallaService.GetRouteAsync(routeRequest);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("test", result.Id);
        }

        [Test]
        public void GetRouteAsync_ShouldThrowException_WhenDeserializationFails()
        {
            // Arrange
            var routeRequest = new RouteRequest { Locations = new[] { new Location { Latitude = 52.52, Longitude = 13.405 } } };
            var invalidJson = "invalid json";
            httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(invalidJson)
                });

            // Act & Assert
            Assert.ThrowsAsync<Exception>(async () => await valhallaService.GetRouteAsync(routeRequest));
        }

        [Test]
        public async Task GetMatrixAsync_ShouldReturnMatrixResponse_WhenRequestIsSuccessful()
        {
            // Arrange
            var matrixRequest = new MatrixRequest { Sources = new[] { new MatrixLocation { Latitude = 52.52, Longitude = 13.405 } }, Targets = new[] { new MatrixLocation { Latitude = 52.52, Longitude = 13.405 } } };
            var matrixResponseJson = "{\"id\":\"test\",\"sources\":[{}],\"targets\":[{}],\"sources_to_targets\":[[{}]]}";
            httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(matrixResponseJson)
                });

            // Act
            var result = await valhallaService.GetMatrixAsync(matrixRequest);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("test", result.Id);
        }

        [Test]
        public async Task GetIsochroneAsync_ShouldReturnIsochroneResponse_WhenRequestIsSuccessful()
        {
            // Arrange
            var isochroneRequest = new IsochroneRequest { Locations = new List<Location> { new Location { Latitude = 52.52, Longitude = 13.405 } } };
            var isochroneResponseJson = "{\"type\":\"FeatureCollection\"}";
            httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(isochroneResponseJson)
                });

            // Act
            var result = await valhallaService.GetIsochroneAsync(isochroneRequest);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("FeatureCollection", result.Type);
        }
    }
}
