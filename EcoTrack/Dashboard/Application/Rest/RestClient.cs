using System.Text.Json;

namespace Dashboard.Application.Rest
{
    public class RestClient<TGet>
    {
        private readonly string _BaseUrl;
        private readonly HttpClient _client;

        public RestClient(string baseUrl)
        {
            this._BaseUrl = baseUrl;
            _client = new HttpClient();
        }

        public async Task<List<TGet>> GetListRequest(string url)
        {
            var response = await _client.GetAsync(_BaseUrl + url);
            if (!response.IsSuccessStatusCode)
                throw new Exception("Error while fetching resource");

            var json = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var result = JsonSerializer.Deserialize<List<TGet>>(json, options);

            return result ?? throw new Exception("Result Null");
        }

    }
}