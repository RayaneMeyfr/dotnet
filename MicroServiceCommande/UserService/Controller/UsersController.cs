using Microsoft.AspNetCore.Mvc;
using UserService.DTO;
using UserService.Service;

namespace UserService.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IService<UserDtoReceive, UserDtoSend> _service;

        public UsersController(IService<UserDtoReceive, UserDtoSend> service)
        {
            _service = service;
        }

        [HttpGet]
        public List<UserDtoSend> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public UserDtoSend GetById(int id)
        {
            var user = _service.GetById(id);
            return user;
        }

        [HttpPost]
        public UserDtoSend Create([FromBody] UserDtoReceive user)
        {
            UserDtoSend userDtoSend = _service.Create(user);
            return userDtoSend;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_service.Delete(id))
            {
                return NoContent(); 
            }

            return NotFound("User not found");
        }

    }
}
