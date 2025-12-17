using System.Text.Json.Serialization;

namespace ApiGateway.DTO
{
    public class UserDtoReceive
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}
