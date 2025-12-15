using Hotel.data;
using Hotel.models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hotel.repository
{
    internal class ReservationRepository : IRepository<Reservation, int>
    {
        private readonly ApplicationDbContext _db;
        private readonly ClientRepository _clientRepo;
        private readonly ChambreRepository _chambreRepo;

        public ReservationRepository(ApplicationDbContext db, ClientRepository clientRepo, ChambreRepository chambreRepo)
        {
            _db = db;
            _clientRepo = clientRepo;
            _chambreRepo = chambreRepo;
        }

        public Reservation? Add(Reservation entity)
        {
            var client = _clientRepo.GetById(entity.unClient.Id);
            var chambre = _chambreRepo.GetByNumeroChambre(entity.uneChambre.NumeroChambre);

            if (client is null || chambre is null)
            {
                return null;
            }

            entity.unClient = client;
            entity.uneChambre = chambre;

            EntityEntry<Reservation> reservationEntity = _db.Add(entity);
            _db.SaveChanges();

            return reservationEntity.Entity;
        }

        public List<Reservation> GetAll()
        {
            return _db.Reservations.ToList();
        }

        public List<Reservation> GetAll(Func<Reservation, bool> predicate)
        {
            return _db.Reservations.Where(predicate).ToList();
        }

        public Reservation? Get(Func<Reservation, bool> predicate)
        {
            return _db.Reservations.FirstOrDefault(predicate);
        }

        public Reservation? GetById(int id)
        {
            return _db.Reservations.FirstOrDefault(r => r.Id == id);
        }

        public Reservation? Update(int id, Reservation entity)
        {
            var reservation = GetById(id);
            if (reservation is null)
                return null;

            if (reservation.unClient.Id != entity.unClient.Id)
            {
                var client = _clientRepo.GetById(entity.unClient.Id);
                if (client != null)
                    reservation.unClient = client;
            }

            if (reservation.uneChambre.NumeroChambre != entity.uneChambre.NumeroChambre)
            {
                var chambre = _chambreRepo.GetByNumeroChambre(entity.uneChambre.NumeroChambre);
                if (chambre != null)
                    reservation.uneChambre = chambre;
            }

            reservation.statut = entity.statut;

            _db.SaveChanges();
            return reservation;
        }

        public bool Delete(int id)
        {
            var reservation = GetById(id);
            if (reservation is null)
                return false;

            _db.Remove(reservation);
            return _db.SaveChanges() == 1;
        }
    }
}
