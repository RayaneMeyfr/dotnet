using MicroServiceDechets.Domain.Entity.Enum;
using System.ComponentModel.DataAnnotations;

namespace MicroServiceDechets.Domain.Entity
{
    public class Dechet
    {
        [Key]
        public int Id { get; set; }
        public TypeDechet Type { get; set; }
        public int QuantiteKg { get; set; }
        public float TauxRecyclageKg { get; set; }
    }
}
