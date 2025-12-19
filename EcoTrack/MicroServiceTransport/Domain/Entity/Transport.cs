using MicroServiceTransport.Domain.Entity.Enum;
using System.ComponentModel.DataAnnotations;

namespace MicroServiceTransport.Domain.Entity
{
    public class Transport
    {
        [Key]
        public int Id { get; set; }
        public ModeTransport Mode { get; set; }
        public float DistanceKm { get; set; }
        public float FacteurEmission { get; set; }
        public float EmissionCO2 => DistanceKm * FacteurEmission;


    }
}
