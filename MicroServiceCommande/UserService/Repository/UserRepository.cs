using UserService.Data;
using UserService.Models;

namespace UserService.Repository
{
    public class UserRepository : IRepository<User>
    {

        private AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User Create(User entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            User user = GetById(id);


            _dbContext.Remove(user);
            _dbContext.SaveChanges();
            return true;
        }

        public List<User> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public User GetById(int id)
        {
            return _dbContext.Users.Find(id);
        }

        public User Update(User entity)
        {
            User user = GetById(entity.Id);
            if (user == null)
            {
                return null;
            }

            _dbContext.Update(entity);
            _dbContext.SaveChanges();
            return entity;
        }
    }
}
