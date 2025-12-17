using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.DTO;
using ProductService.Service;

namespace ProductService.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IService<ProductDtoReceive, ProductDtoSend> _service;

        public ProductController(IService<ProductDtoReceive, ProductDtoSend> service)
        {
            _service = service;
        }

        [HttpGet]
        public List<ProductDtoSend> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public ProductDtoSend GetById(int id)
        {
            var product = _service.GetById(id);
            return product;
        }

        [HttpPost]
        public ProductDtoSend Create([FromBody] ProductDtoReceive product)
        {
            ProductDtoSend productDtoSend = _service.Create(product);
            return productDtoSend;
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
