using MicroServiceEnergie.Application.Dto;
using MicroServiceEnergie.Application.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroServiceEnergie.Api.Cotroller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnergieController : ControllerBase
    {
        private readonly IService<EnergieDtoReceive, EnergieDtoSend> _service;

        public EnergieController(IService<EnergieDtoReceive, EnergieDtoSend> service)
        {
            _service = service;
        }

        [HttpGet]
        public List<EnergieDtoSend> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public EnergieDtoSend GetById(int id)
        {
            var energie = _service.GetById(id);
            return energie;
        }

        [HttpPost]
        public EnergieDtoSend Create([FromBody] EnergieDtoReceive energie)
        {
            EnergieDtoSend energieDtoSend = _service.Create(energie);
            return energieDtoSend;
        }
    }
}
