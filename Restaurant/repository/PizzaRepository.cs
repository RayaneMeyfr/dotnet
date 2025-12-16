using Restaurant.data;
using Restaurant.models;

namespace Restaurant.repository
{
    public class PizzaRepository : IRepository<Pizza>
    {
        private readonly AppDbContext _db;

        public PizzaRepository(AppDbContext db)
        {
            _db = db;
        }
        public bool Create(Pizza entity)
        {
            _db.Add(entity);
            _db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            Pizza pizzatFound = Get(id);
            if (pizzatFound != null)
            {
                _db.Remove(pizzatFound);
                return true;
            }
            return false;
        }

        public Pizza Get(int id)
        {
            return _db.Pizzas.Find(id);
        }

        public List<Pizza> GetAll()
        {
            return _db.Pizzas.ToList();
        }

        public bool Update(Pizza entity)
        {
            Pizza pizzatFound = Get(entity.Id);
            if (pizzatFound != null)
            {
                _db.Update(pizzatFound);
                return true;
            }
            return false;
        }
    }
}
