using Microsoft.AspNetCore.Mvc;
using ApiGateway.DTO;
using ApiGateway.Rest;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatewayController : ControllerBase
    {
        private RestClient<UserDtoSend, UserDtoReceive> _restUser;
        private RestClient<ProductDtoSend, ProductDtoReceive> _restProduct;
        private RestClient<OrderDtoSend, OrderDtoReceive> _restOrder;

        public GatewayController()
        {
            _restUser = new RestClient<UserDtoSend, UserDtoReceive>("http://localhost:5232/api");
            _restProduct = new RestClient<ProductDtoSend, ProductDtoReceive>("http://localhost:5201/api");
            _restOrder = new RestClient<OrderDtoSend, OrderDtoReceive>("http://localhost:5062/api");
        }

        [HttpGet("users")]
        public async Task<List<UserDtoSend>> GetUsers()
        {
            return await _restUser.GetListRequest("/users");
        }

        [HttpGet("users/{id}")]
        public async Task<UserDtoSend> GetUserById(int id)
        {
            return await _restUser.GetRequest($"/users/{id}");
        }

        [HttpPost("users")]
        public async Task<UserDtoSend> PostUser([FromBody] UserDtoReceive user)
        {
            return await _restUser.PostRequest("/users", user);
        }

        [HttpDelete("users/{id}")]
        public async Task DeleteUser(int id)
        {
            await _restUser.DeleteRequest($"/users/{id}");
        }

        [HttpGet("product")]
        public async Task<List<ProductDtoSend>> GetProducts()
        {
            return await _restProduct.GetListRequest("/product");
        }

        [HttpGet("product/{id}")]
        public async Task<ProductDtoSend> GetProductById(int id)
        {
            return await _restProduct.GetRequest($"/product/{id}");
        }

        [HttpPost("product")]
        public async Task<ProductDtoSend> PostProduct([FromBody] ProductDtoReceive product)
        {
            return await _restProduct.PostRequest("/product", product);
        }

        [HttpDelete("product/{id}")]
        public async Task DeleteProduct(int id)
        {
            await _restProduct.DeleteRequest($"/product/{id}");
        }

        [HttpGet("order")]
        public async Task<List<OrderDtoSend>> GetOrders()
        {
            return await _restOrder.GetListRequest("/order");
        }

        [HttpGet("order/{id}")]
        public async Task<OrderDtoSend> GetOrderById(int id)
        {
            return await _restOrder.GetRequest($"/order/{id}");
        }

        [HttpPost("order")]
        public async Task<OrderDtoSend> PostOrder([FromBody] OrderDtoReceive order)
        {
            return await _restOrder.PostRequest("/order", order);
        }

        [HttpDelete("order/{id}")]
        public async Task DeleteOrder(int id)
        {
            await _restOrder.DeleteRequest($"/order/{id}");
        }
    }
}
