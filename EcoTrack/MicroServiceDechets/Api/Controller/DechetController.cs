using MicroServiceDechets.Application.Dto;
using MicroServiceDechets.Application.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroServiceDechets.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DechetController : ControllerBase
    {
        private readonly IService<DechetDtoReceive, DechetDtoSend> _service;

        public DechetController(IService<DechetDtoReceive, DechetDtoSend> service)
        {
            _service = service;
        }

        [HttpGet]
        public List<DechetDtoSend> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public DechetDtoSend GetById(int id)
        {
            var dechet = _service.GetById(id);
            return dechet;
        }

        [HttpPost]
        public DechetDtoSend Create([FromBody] DechetDtoReceive dechet)
        {
            DechetDtoSend dechetDtoSend = _service.Create(dechet);
            return dechetDtoSend;
        }
    }
}
