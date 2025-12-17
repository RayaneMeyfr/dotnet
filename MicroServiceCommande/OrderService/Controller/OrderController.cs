using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.DTO;
using OrderService.Service;

namespace OrderService.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IService<OrderDtoReceive, OrderDtoSend> _service;

        public OrderController(IService<OrderDtoReceive, OrderDtoSend> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _service.GetById(id);
            if (order is null)
                return NotFound("orderN Not found");
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderDtoReceive orderDtoReceive)
        {
            OrderDtoSend orderDtoSend = await _service.Create(orderDtoReceive);
            return CreatedAtAction(nameof(Create), orderDtoSend);
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            if (_service.Delete(id))
            {
                return NoContent();
            }

            return NotFound("Order not found");
        }
    }
}
