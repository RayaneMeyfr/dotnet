using MicroServiceEnergie.Domain.Entity.Enum;

namespace MicroServiceEnergie.Application.Dto
{
    public class EnergieDtoSend
    {
        public int Id { get; set; }
        public string Source { get; set; }
        public int CosomationKWh { get; set; }
        public DateTime Date { get; set; }
    }
}
