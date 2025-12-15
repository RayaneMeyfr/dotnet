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
    internal class ChambreRepository : IRepository<Chambre, int>
    {
        private readonly ApplicationDbContext _db;

        public ChambreRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Chambre? Add(Chambre entity)
        {
            EntityEntry<Chambre> chambreEntity = _db.Add(entity);
            _db.SaveChanges();

            return chambreEntity.Entity;
        }

        public List<Chambre> GetAll()
        {
            return _db.Chambres.ToList();
        }

        public List<Chambre> GetAll(Func<Chambre, bool> predicate)
        {
            return _db.Chambres.Where(predicate).ToList();
        }

        public Chambre? GetByNumeroChambre(int id)
        {
            return _db.Chambres.FirstOrDefault(p => p.NumeroChambre == id);
        }

        public Chambre? Get(Func<Chambre, bool> predicate)
        {
            return _db.Chambres.FirstOrDefault(predicate);
        }

        public Chambre? Update(int id, Chambre entity)
        {
            var chambre = GetByNumeroChambre(id);

            if (chambre is null)
            {
                return null;
            }

            if (chambre.Status != entity.Status)
                chambre.Status = entity.Status;
            if (chambre.Tarrif != entity.Tarrif)
                chambre.Tarrif = entity.Tarrif;
            if (chambre.NombreLit != entity.NombreLit)
                chambre.NombreLit = entity.NombreLit;

            _db.SaveChanges();

            return chambre;
        }

        public bool Delete(int id)
        {
            var chambre = GetByNumeroChambre(id);
            if (chambre is null)
            {
                return false;
            }

            _db.Remove(chambre);
            return _db.SaveChanges() == 1;
        }

        public Chambre? GetById(int id)
        {
            return _db.Chambres.FirstOrDefault(c => c.NumeroChambre == id);
        }
    }
}
