using System.Text.Json.Serialization;

namespace Dashboard.Application.Dto
{
    public class TransportDtoSend
    {
        public int Id { get; set; }
        public string Mode { get; set; }
        public float DistanceKm { get; set; }
        [JsonPropertyName("FacteurEmission")]
        public float FacteurEmission { get; set; }
        [JsonPropertyName("EmissionCO2")]
        public float EmissionCO2 { get; set; }
    }
}
