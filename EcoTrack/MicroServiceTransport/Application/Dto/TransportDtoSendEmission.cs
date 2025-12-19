using MicroServiceTransport.Domain.Entity.Enum;

namespace MicroServiceTransport.Application.Dto
{
    public class TransportDtoSendEmission
    {
        public int Id { get; set; }
        public string Mode { get; set; }
        public float DistanceKm { get; set; }
        public float FacteurEmission { get; set; }
        public float EmissionCO2 { get; set; }
    }
}
