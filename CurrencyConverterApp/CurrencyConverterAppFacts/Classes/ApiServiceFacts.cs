using CurrencyAppConverter.Classes;
using Moq;
using Moq.Protected;
using System.Net;

namespace CurrencyConverterAppFacts.Classes
{
    public class ApiServiceFacts
    {
        private ApiService apiService = new();

        [Fact]
        public void DeserializeCurrencies_ValidJsonResponse_ShouldReturnTrue()
        {
            string response = "{\r\n        \"meta\":{\r\n            \"last_updated_at\":\"2023-08-03T23:59:59Z\"\r\n        },\r\n        \"data\":{\r\n            \"BIF\": {\r\n                \"code\": \"BIF\",\r\n                \"value\": 2825.50500246\r\n            },} } ";
            var apiService = new ApiService();

            Dictionary<string, double> currencies = apiService.DeserializeCurrencies(response);

            Assert.True(currencies.ContainsKey("BIF"));
            Assert.True(currencies.TryGetValue("BIF", out _));
            Assert.Single(currencies);
        }

        [Fact]
        public void DeserializeCurrencies_InvalidJsonResponse_ShouldThrowArgumentException()
        {
            string jsonResponse = " \"code\": \"BIF} ";
            var apiService = new ApiService();

            Assert.Throws<ArgumentException>(() => apiService.DeserializeCurrencies(jsonResponse));
        }

        [Fact]
        public void DeserializeCurrencies_EmptyJsonResponse_ShouldThrowArgumentException()
        {
            string jsonResponse = "";
            var apiService = new ApiService();

            Assert.Throws<ArgumentException>(() => apiService.DeserializeCurrencies(jsonResponse));
        }

        [Fact]
        public void DeserializeCurrencies_NullJsonResponse_ShouldThrowArgumentException()
        {
            string? jsonResponse = null;
            var apiService = new ApiService();

            Assert.Throws<ArgumentException>(() => apiService.DeserializeCurrencies(jsonResponse));
        }

        [Fact]
        public async void GetCurrenciesDataAsync_ApiKeyIsValid_ShouldReturnExpectedResult()
        {
            string apiKey = "validApiKey";

            var mockHttpHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            mockHttpHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("EUR, USD, RON")
                });

            var httpClient = new HttpClient(mockHttpHandler.Object);
            apiService = new ApiService(httpClient);

            string currencies = await apiService.GetCurrenciesDataAsync(apiKey);

            Assert.Contains("EUR", currencies);
            Assert.Contains("USD", currencies);
            Assert.Contains("RON", currencies);
        }

        [Fact]
        public async Task GetCurrenciesDataAsync_ApiKeyIsInvalid_ShouldReturnExpectedResult()
        {
            string apiKey = "fakeApiKey";

            var mockHttpHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            mockHttpHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                });

            var httpClient = new HttpClient(mockHttpHandler.Object);
            apiService = new ApiService(httpClient);


            await Assert.ThrowsAsync<InvalidOperationException>(() => apiService.GetCurrenciesDataAsync(apiKey));
        }

        [Fact]
        public async Task GetCurrenciesDataAsync_InternalServerError_ShouldReturnExpectedResult()
        {
            string apiKey = "validApiKey";

            var mockHttpHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            mockHttpHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                });

            var httpClient = new HttpClient(mockHttpHandler.Object);
            apiService = new ApiService(httpClient);


            await Assert.ThrowsAsync<InvalidOperationException>(() => apiService.GetCurrenciesDataAsync(apiKey));
        }

        [Fact]
        public async Task GetCurrenciesDataAsync_NetworkUnavailable_ShouldThrowException()
        {
            string apiKey = "validApiKey";

            var mockHttpHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            mockHttpHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ThrowsAsync(new HttpRequestException());

            var httpClient = new HttpClient(mockHttpHandler.Object);
            apiService = new ApiService(httpClient);

            await Assert.ThrowsAsync<InvalidOperationException>(() => apiService.GetCurrenciesDataAsync(apiKey));
        }

        [Fact]
        public async Task GetCurrenciesDataAsync_UnexpectedJsonResponse_ShouldReturnExpectedResult()
        {
            string apiKey = "validApiKey";
            string expectedResponse = "{\"currencies\": EUR, CHF, USD }";

            var mockHttpHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            mockHttpHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{\"invalid_field\": 20}")
                });

            var httpClient = new HttpClient(mockHttpHandler.Object);
            var apiService = new ApiService(httpClient);

            string currencies = await apiService.GetCurrenciesDataAsync(apiKey);

            Assert.NotEqual(currencies, expectedResponse);
            Assert.Contains("\"invalid_field\": 20", currencies);
        }

        [Fact]
        public async Task GetCurrenciesDataAsync_JsonResponseIsNull_ShouldThrowException()
        {
            string apiKey = "validApiKey";

            var mockHttpHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            _ = mockHttpHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(() => null);

            var httpClient = new HttpClient(mockHttpHandler.Object);
            var apiService = new ApiService(httpClient);

            await Assert.ThrowsAsync<InvalidOperationException>(() => apiService.GetCurrenciesDataAsync(apiKey));
        }

        [Fact]
        public async Task GetCurrenciesDataAsync_RequestLimitExceeded_ShouldThrowException()
        {
            string apiKey = "validApiKey";

            var mockHttpHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            mockHttpHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.TooManyRequests
                });

            var httpClient = new HttpClient(mockHttpHandler.Object);
            apiService = new ApiService(httpClient);

            await Assert.ThrowsAsync<InvalidOperationException>(() => apiService.GetCurrenciesDataAsync(apiKey));
        }

        [Fact]
        public async void DisposeHttpClient_HttpClientIsDisposed_ShoudThrowException()
        {
            string apiKey = "validApiKey";

            var mockHttpHandler = new Mock<HttpMessageHandler>();
            mockHttpHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                });

            var httpClient = new HttpClient(mockHttpHandler.Object);

            apiService = new ApiService(httpClient);
            apiService.DisposeHttpClient();

            await Assert.ThrowsAsync<ObjectDisposedException>(() => apiService.GetCurrenciesDataAsync(apiKey));
        }
    }
}