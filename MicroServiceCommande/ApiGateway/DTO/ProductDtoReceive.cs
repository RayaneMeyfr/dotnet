using System.Text.Json.Serialization;

namespace ApiGateway.DTO
{
    public class ProductDtoReceive
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("price")]
        public float Price { get; set; }
    }
}
