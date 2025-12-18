using MicroServiceDechets.Domain.Entity.Enum;

namespace MicroServiceDechets.Application.Dto
{
    public class DechetDtoReceive
    {
        public TypeDechet Type { get; set; }
        public int QuantiteKg { get; set; }
        public float TauxRecyclageKg { get; set; }
    }
}
