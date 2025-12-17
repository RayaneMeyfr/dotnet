using System.Text;
using System.Text.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ApiGateway.Rest
{
    public class RestClient<TGet, TPost>
    {
        private readonly string _BaseUrl;
        private readonly HttpClient _client;

        public RestClient(string baseUrl)
        {
            _BaseUrl = baseUrl;
            _client = new HttpClient();
        }

        public async Task<TGet> GetRequest(string url)
        {
            var response = await _client.GetAsync(_BaseUrl + url);

            if (!response.IsSuccessStatusCode) throw new Exception("Error while fetching ressource");

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<TGet>(json);
            return result ?? throw new Exception("Result null");
        }

        public async Task<List<TGet>> GetListRequest(string url)
        {
            var response = await _client.GetAsync(_BaseUrl + url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<TGet>>(json);
            return result ?? new List<TGet>();
        }

        public async Task<TGet> PostRequest(string url, TPost postElement)
        {
            var jsonContent = new StringContent(
                JsonSerializer.Serialize(postElement),
                Encoding.UTF8,
                "application/json");

            var response = await _client.PostAsync(_BaseUrl + url, jsonContent);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<TGet>(json);
            return result ?? throw new Exception("Result null");
        }

        public async Task DeleteRequest(string url)
        {
            var response = await _client.DeleteAsync(_BaseUrl + url);
            response.EnsureSuccessStatusCode();
        }
    }
}
