using MicroServiceTransport.Domain.Entity.Enum;

namespace MicroServiceTransport.Application.Dto
{
    public class TransportDtoReceive
    {
        public ModeTransport Mode { get; set; }
        public float DistanceKm { get; set; }
    }
}
