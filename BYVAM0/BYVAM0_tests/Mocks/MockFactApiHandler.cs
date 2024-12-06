using System.Net;
using System.Text;

namespace BYVAM0_tests.Mocks
{
    public class MockFactApiHandler : HttpMessageHandler
    {
        private readonly string _json;
        private readonly HttpStatusCode _statusCode;

        public MockFactApiHandler(string json, HttpStatusCode statusCode)
        {
            _json = json;
            _statusCode = statusCode;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                StatusCode = _statusCode,
                Content = new StringContent(_json, Encoding.UTF8, "application/json"),
            };

            return Task.FromResult(response);
        }
    }
}
