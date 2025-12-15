using Hotel.models.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        public StatutReservation statut { get; set; }
        public Chambre uneChambre { get; set; }
        public Client unClient { get; set; }

        public override string ToString()
        {
            return $"Reservation {Id} - Statut: {statut}, Client: {unClient.Nom} {unClient.Prenom}, Chambre: {uneChambre.NumeroChambre}";
        }
    }
}
