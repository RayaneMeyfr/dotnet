using Hotel.models.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.models
{
    public class Chambre
    {
        [Key]
        public int NumeroChambre {  get; set; }
        public StatutChambre Status { get; set; }
        public int NombreLit { get; set; }
        public float Tarrif { get; set; }

        public override string ToString()
        {
            return $"Chambre {NumeroChambre} - Statut: {Status}, Lits: {NombreLit}, Tarif: {Tarrif}€";
        }
    }
}
