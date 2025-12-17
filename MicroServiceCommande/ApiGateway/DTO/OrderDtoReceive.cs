using System.Text.Json.Serialization;

namespace ApiGateway.DTO
{
    public class OrderDtoReceive
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("userId")]
        public int UserId { get; set; }
        [JsonPropertyName("ProductIds")]
        public List<int> ProductIds { get; set; }
    }
}
