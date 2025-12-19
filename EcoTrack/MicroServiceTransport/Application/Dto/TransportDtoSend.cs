using MicroServiceTransport.Domain.Entity.Enum;

namespace MicroServiceTransport.Application.Dto
{
    public class TransportDtoSend
    {
        public int Id { get; set; }
        public string Mode { get; set; }
        public float DistanceKm { get; set; }
        public float FacteurEmission { get; set; }
    }
}
