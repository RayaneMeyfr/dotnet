using OrderService.Data;
using OrderService.Models;

namespace OrderService.Repository
{
    public class OrderRepository : IRepository<Order>
    {

        private AppDbContext _dbContext;

        public OrderRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Order Create(Order entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            Order order = GetById(id);

            _dbContext.Remove(order);
            _dbContext.SaveChanges();
            return true;
        }

        public List<Order> GetAll()
        {
            return _dbContext.Orders.ToList();
        }

        public Order GetById(int id)
        {
            return _dbContext.Orders.FirstOrDefault(p => p.Id == id);
        }

        public Order Update(Order entity)
        {
            Order order = GetById(entity.Id);
            if (order == null)
            {
                return null;
            }

            _dbContext.Update(entity);
            _dbContext.SaveChanges();
            return entity;
        }
    }
}
