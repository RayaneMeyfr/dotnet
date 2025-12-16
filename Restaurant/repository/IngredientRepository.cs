using Restaurant.data;
using Restaurant.models;

namespace Restaurant.repository
{
    public class IngredientRepository : IRepository<Ingredient>
    {
        private readonly AppDbContext _db;

        public IngredientRepository(AppDbContext db)
        {
            _db = db;
        }
        public bool Create(Ingredient entity)
        {
            _db.Add(entity);
            _db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            Ingredient ingredientFound = Get(id);
            if (ingredientFound != null)
            {
                _db.Remove(ingredientFound);
                return true;
            }
            return false;
        }

        public Ingredient Get(int id)
        {
            return _db.Ingredients.Find(id);
        }

        public List<Ingredient> GetAll()
        {
            return _db.Ingredients.ToList();
        }

        public bool Update(Ingredient entity)
        {
            Ingredient ingredientFound = Get(entity.Id);
            if (ingredientFound != null)
            {
                _db.Update(ingredientFound);
                return true;
            }
            return false;
        }
    }
}
