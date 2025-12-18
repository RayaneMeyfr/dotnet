using MicroServiceEnergie.Domain.Entity.Enum;

namespace MicroServiceEnergie.Application.Dto
{
    public class EnergieDtoReceive
    {
        public SourceEnergie Source { get; set; }
        public int CosomationKWh { get; set; }
        public DateTime Date { get; set; }
    }
}
