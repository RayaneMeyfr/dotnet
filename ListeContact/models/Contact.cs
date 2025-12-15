using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListeContact.models
{
    internal class Contact
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public DateOnly DateNaissance { get; set; }
        public int Age { get; set; }
        public int Genre { get; set; }
        public string Numero { get; set; }
        public string Email { get; set; }
    }
}
