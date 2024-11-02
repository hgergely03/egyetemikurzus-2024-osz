using System.Text.Json;

using BYVAM0.Interfaces;

namespace BYVAM0.Services
{
    internal class FactService : IFactService
    {
        private readonly HttpClient _httpClient;

        public FactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private static string? ParseResponse(string response)
        {
            var jsonElement = JsonSerializer.Deserialize<JsonElement>(response);

            if(jsonElement.TryGetProperty("fact", out JsonElement fact)) {
                return fact.GetString();
            }

            return null;
        }

        private async Task<string?> GetFactFromApi()
        {
            try
            {
                using var response = await _httpClient.GetAsync("/fact");

                if (response.IsSuccessStatusCode)
                {
                    var responseText = await response.Content.ReadAsStringAsync();

                    if (responseText is null)
                    {
                        return null;
                    }

                    var fact = ParseResponse(responseText);

                    return fact;
                }
                else
                {
                    return null;
                }
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }

        public async Task<string> GetCatFact()
        {
            var fact = await GetFactFromApi();

            if (fact is null)
            {
                return "Cats do not think that they are little people. They think that we are big cats. " +
                "This influences their behavior in many ways.";
            }

            return fact;
        }
    }
}
