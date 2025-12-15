using Hotel.data;
using Hotel.models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.repository
{
    internal class ClientRepository : IRepository<Client, int>
    {
        private readonly ApplicationDbContext _db;

        public ClientRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Client? Add(Client entity)
        {
            EntityEntry<Client> clientEntity = _db.Add(entity);
            _db.SaveChanges();

            return clientEntity.Entity;
        }

        public List<Client> GetAll()
        {
            return _db.Clients.ToList();
        }

        public List<Client> GetAll(Func<Client, bool> predicate)
        {
            return _db.Clients.Where(predicate).ToList();
        }

        public Client? GetByNumeroClient(int id)
        {
            return _db.Clients.FirstOrDefault(p => p.Id == id);
        }

        public Client? Get(Func<Client, bool> predicate)
        {
            return _db.Clients.FirstOrDefault(predicate);
        }

        public Client? Update(int id, Client entity)
        {
            var client = GetByNumeroClient(id);

            if (client is null)
            {
                return null;
            }

            if (client.Nom != entity.Nom)
                client.Nom = entity.Nom;
            if (client.Prenom != entity.Prenom)
                client.Prenom = entity.Prenom;
            if (client.Numero != entity.Numero)
                client.Numero = entity.Numero;

            _db.SaveChanges();

            return client;
        }

        public bool Delete(int id)
        {
            var client = GetByNumeroClient(id);
            if (client is null)
            {
                return false;
            }

            _db.Remove(client);
            return _db.SaveChanges() == 1;
        }

        public Client? GetById(int id)
        {
            return _db.Clients.FirstOrDefault(c => c.Id == id);
        }
    }
}
