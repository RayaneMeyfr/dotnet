using MicroServiceEnergie.Domain.Entity.Enum;
using System.ComponentModel.DataAnnotations;

namespace MicroServiceEnergie.Domain.Entity
{
    public class Energie
    {
        [Key]
        public int Id { get; set; }
        public SourceEnergie Source { get; set; }
        public int CosomationKWh {  get; set; }
        public DateTime Date { get; set; }
    }
}
