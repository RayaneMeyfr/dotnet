using ListeContact.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListeContact.repository
{
    internal interface IContactRepository : IRepository<Contact , int>
    {
        private readonly ApplicationDbContext _db;
    
    }
}
