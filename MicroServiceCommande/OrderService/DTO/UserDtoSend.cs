using System.Text.Json.Serialization;

namespace OrderService.DTO
{
    public class UserDtoSend
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}
