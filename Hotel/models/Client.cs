using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string Nom {  get; set; }
        public string Prenom { get; set; }
        public string Numero { get; set; }

        public override string ToString()
        {
            return $"Client {Id} : {Nom} {Prenom}, Tel: {Numero}";
        }
    }
}
