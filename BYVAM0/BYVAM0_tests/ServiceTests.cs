using System.Net;
using System.Text.Json;
using BYVAM0.Services;
using BYVAM0_tests.Mocks;

namespace BYVAM0_tests
{
    public class ServiceTests
    {
        [Test]
        public async Task GetCatFact_ServiceUnavailable_ReturnsDefaultFact()
        {
            var fact = new
            {
                fact = "test",
                length = 4
            };

            var json = JsonSerializer.Serialize(fact);
            var messageHandler = new MockFactApiHandler(json, HttpStatusCode.ServiceUnavailable);
            var httpClient = new HttpClient(messageHandler)
            {
                BaseAddress = new Uri("https://catfact.ninja"),
            };

            FactService service = new(httpClient);
            var response = await service.GetCatFact();
            var defaultFact = "Cats do not think that they are little people. They think that we are big cats. " +
                "This influences their behavior in many ways.";

            Assert.That(response, Is.EqualTo(defaultFact));
        }

        [Test]
        public async Task GetCatFact_ServiceAvailable_ReturnsFact()
        {
            var fact = new
            {
                fact = "Interesting cat fact",
                length = 20
            };

            var json = JsonSerializer.Serialize(fact);
            var messageHandler = new MockFactApiHandler(json, HttpStatusCode.OK);
            var httpClient = new HttpClient(messageHandler)
            {
                BaseAddress = new Uri("https://catfact.ninja"),
            };

            FactService service = new(httpClient);
            var response = await service.GetCatFact();

            Assert.That(response, Is.EqualTo(fact.fact));
        }
    }
}
