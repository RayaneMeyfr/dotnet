using ProductService.Data;
using ProductService.Models;

namespace ProductService.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        private AppDbContext _dbContext;

        public ProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Product Create(Product entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            Product product = GetById(id);

            _dbContext.Remove(product);
            _dbContext.SaveChanges();
            return true;
        }

        public List<Product> GetAll()
        {
            return _dbContext.Products.ToList();

        }

        public Product GetById(int id)
        {
            return _dbContext.Products.Find(id);
        }

        public Product Update(Product entity)
        {
            Product product = GetById(entity.Id);
            if (product == null)
            {
                return null;
            }

            _dbContext.Update(entity);
            _dbContext.SaveChanges();
            return entity;
        }
    }
}
