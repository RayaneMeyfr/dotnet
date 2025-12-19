using MicroServiceTransport.Domain.Entity;
using MicroServiceTransport.Domain.Ports;
using MicroServiceTransport.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MicroServiceTransport.Infrastructure.Persistence
{
    public class TransportRepository : IRepository<Transport>
    {

        private AppDbContext _dbContext;

        public TransportRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Transport Create(Transport entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            Transport transport = GetById(id);

            _dbContext.Remove(transport);
            _dbContext.SaveChanges();
            return true;
        }

        public List<Transport> GetAll()
        {
            return _dbContext.Transports.ToList();
        }

        public Transport GetById(int id)
        {
            return _dbContext.Transports.Find(id);
        }

        public Transport Update(Transport entity)
        {
            _dbContext.Transports.Update(entity);
            _dbContext.SaveChanges();
            return entity;
        }

    }
}