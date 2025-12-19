using MicroServiceTransport.Application.Dto;
using MicroServiceTransport.Application.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroServiceTransport.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportController : ControllerBase
    {
        private readonly IService<TransportDtoReceive, TransportDtoSend> _service;

        public TransportController(IService<TransportDtoReceive, TransportDtoSend> service)
        {
            _service = service;
        }

        [HttpGet]
        public List<TransportDtoSend> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public TransportDtoSend GetById(int id)
        {
            var transport = _service.GetById(id);
            return transport;
        }

        [HttpPost]
        public TransportDtoSend Create([FromBody] TransportDtoReceive transport)
        {
            TransportDtoSend transportDtoSend = _service.Create(transport);
            return transportDtoSend;
        }

        [HttpPatch("{id}")]
        public ActionResult<TransportDtoSend> Update(int id, [FromBody] TransportDtoReceive transport)
        {
            var updatedTransport = _service.Update(transport, id);

            if (updatedTransport == null)
            {
                return NotFound();
            }

            return Ok(updatedTransport);
        }

        [HttpGet("{id}/emission")]
        public ActionResult<TransportDtoSend> GetTransportWithEmission(int id)
        {
            var transport = _service.GetByIdEmission(id); 
            if (transport == null) return NotFound();

            return Ok(transport); 
        }



    }
}
