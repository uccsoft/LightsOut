using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using LightsOut.Api.Models;

namespace LightsOut.App
{
    class LightsOutApiClient
    {
        private readonly Uri _baseUri;

        public LightsOutApiClient(string host, string port)
        {
            _baseUri = new Uri($"http://{host}:{port}");
        }

        private async Task<string> GetRawDataFromApi(string relativeUrl)
        {
            using (var client = new HttpClient())
            {
                using (var result = await client.GetAsync($"{_baseUri}{relativeUrl}"))
                {
                    result.EnsureSuccessStatusCode();
                    return await result.Content.ReadAsStringAsync();
                }
            }
        }

        public async Task<GameSettings> GetGameSettings(int id)
        {
            var rawData = await GetRawDataFromApi($"api/gamesettings/{id}");

            return JsonSerializer.Deserialize<GameSettings>(rawData, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            }); 
        }
    }
}
