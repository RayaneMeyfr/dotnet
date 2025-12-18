using MicroServiceDechets.Domain.Entity.Enum;

namespace MicroServiceDechets.Application.Dto
{
    public class DechetDtoSend
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int QuantiteKg { get; set; }
        public float TauxRecyclageKg { get; set; }
    }
}
