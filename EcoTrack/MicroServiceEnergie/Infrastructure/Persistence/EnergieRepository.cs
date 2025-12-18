using MicroServiceEnergie.Domain.Entity;
using MicroServiceEnergie.Domain.Ports;
using MicroServiceEnergie.Infrastructure.Data;

namespace MicroServiceEnergie.Infrastructure.Persistence
{
    public class EnergieRepository : IRepository<Energie>
    {

        private AppDbContext _dbContext;

        public EnergieRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Energie Create(Energie entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            Energie energie = GetById(id);

            _dbContext.Remove(energie);
            _dbContext.SaveChanges();
            return true;
        }

        public List<Energie> GetAll()
        {
            return _dbContext.Energies.ToList();
        }

        public Energie GetById(int id)
        {
            return _dbContext.Energies.Find(id);
        }

        public Energie Update(Energie entity)
        {
            Energie energie = GetById(entity.Id);
            if (energie == null)
            {
                return null;
            }

            _dbContext.Update(entity);
            _dbContext.SaveChanges();
            return entity;
        }
    }
}
