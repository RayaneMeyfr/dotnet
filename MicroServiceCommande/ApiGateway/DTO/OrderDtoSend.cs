using System.Text.Json.Serialization;

namespace ApiGateway.DTO
{
    public class OrderDtoSend
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("user")]
        public UserDtoSend User { get; set; }
        [JsonPropertyName("product")]
        public List<ProductDtoSend> Products { get; set; } = new List<ProductDtoSend>();
        [JsonPropertyName("price")]
        public float Price => Products.Sum(p => p.Price);
    }
}
