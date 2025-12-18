using MicroServiceDechets.Domain.Entity;
using MicroServiceDechets.Domain.Ports;
using MicroServiceDechets.Infrastructure.Data;

namespace MicroServiceDechets.Infrastructure.Persistence
{
    public class DechetRepository : IRepository<Dechet>
    {
        private AppDbContext _dbContext;

        public DechetRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Dechet Create(Dechet entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            Dechet dechet = GetById(id);

            _dbContext.Remove(dechet);
            _dbContext.SaveChanges();
            return true;
        }

        public List<Dechet> GetAll()
        {
            return _dbContext.Dechets.ToList();
        }

        public Dechet GetById(int id)
        {
            return _dbContext.Dechets.Find(id);
        }

        public Dechet Update(Dechet entity)
        {
            Dechet dechet = GetById(entity.Id);
            if (dechet == null)
            {
                return null;
            }

            _dbContext.Update(entity);
            _dbContext.SaveChanges();
            return entity;
        }
    }
}
