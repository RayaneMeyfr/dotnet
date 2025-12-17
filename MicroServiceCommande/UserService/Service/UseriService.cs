using UserService.DTO;
using UserService.Models;
using UserService.Repository;

namespace UserService.Service
{
    public class UseriService : IService<UserDtoReceive, UserDtoSend>
    {
        private readonly IRepository<User> repository;

        public UseriService(IRepository<User> repository)
        {
            this.repository = repository;
        }
        public UserDtoSend Create(UserDtoReceive receive)
        {
            return EntityToDto(repository.Create(DtoToEntity(receive, null)));

        }

        public bool Delete(int id)
        {
            return repository.Delete(id);
        }

        public List<UserDtoSend> GetAll()
        {
            List<User> users = repository.GetAll();
            List<UserDtoSend> userDtoSends = new List<UserDtoSend>();
            foreach (var user in users)
            {
                userDtoSends.Add(EntityToDto(user));
            }

            return userDtoSends;
        }

        public UserDtoSend GetById(int id)
        {
            User user = repository.GetById(id);
            if (user == null)
            {
                return null;
            }

            return EntityToDto(user);
        }

        public UserDtoSend Update(UserDtoReceive receive, int id)
        {
            return EntityToDto(repository.Update(DtoToEntity(receive, id)));
        }

        private User DtoToEntity(UserDtoReceive receive, int? id)
        {
            User user = new User()
            {
                Name = receive.Name,
                FirstName = receive.FirstName,
                Email = receive.Email

            };

            if (id != null)
            {
                user.Id = (int)id;
            }

            return user;
        }

        private UserDtoSend EntityToDto(User user)
        {
            return new UserDtoSend()
            {
                Id = user.Id,
                Name = user.Name,
                FirstName = user.FirstName,
                Email = user.Email
            };
        }
    }
}
