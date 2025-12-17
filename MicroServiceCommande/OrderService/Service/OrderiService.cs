using OrderService.DTO;
using OrderService.Models;
using OrderService.Repository;
using OrderService.Rest;

namespace OrderService.Service
{
    public class OrderiService : IService<OrderDtoReceive, OrderDtoSend>
    {
        private readonly IRepository<Order> _repository;
        private RestClient<UserDtoSend> _restClientUser;
        private RestClient<ProductDtoSend> _restClientProduct;


        public OrderiService(IRepository<Order> repository)
        {
            _repository = repository;
            _restClientUser = new RestClient<UserDtoSend>("http://localhost:5232/api/users/");
            _restClientProduct = new RestClient<ProductDtoSend>("http://localhost:5201/api/product/");
        }
        public async Task<OrderDtoSend> Create(OrderDtoReceive receive)
        {
            return await EntityToDto(_repository.Create(DtoToEntity(receive, null)));
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public async Task<List<OrderDtoSend>> GetAll()
        {
            List<Order> orders = _repository.GetAll();
            List<OrderDtoSend> orderDtoSends = new List<OrderDtoSend>();
            foreach (var order in orders)
            {
                orderDtoSends.Add(await EntityToDto(order));
            }

            return orderDtoSends;
        }

        public async Task<OrderDtoSend> GetById(int id)
        {
            return await EntityToDto(_repository.GetById(id));
        }

        public async Task<OrderDtoSend> Update(OrderDtoReceive receive, int id)
        {
            return await EntityToDto(_repository.Update(DtoToEntity(receive, id)));
        }

        private Order DtoToEntity(OrderDtoReceive receive, int? id)
        {
            Order order = new Order()
            {
                UserId = receive.UserId,
                ProductIds = receive.ProductIds,
            };

            if (id != null)
            {
                order.Id = (int)id;
            }


            return order;
        }

        private async Task<OrderDtoSend> EntityToDto(Order order)
        {
            OrderDtoSend orderDtoSend = new OrderDtoSend()
            {
                Id = order.Id,
            };

            foreach (var product in order.ProductIds)
            {
                orderDtoSend.Products.Add(await _restClientProduct.GetRequest(product.ToString()));
            }

            orderDtoSend.User = await _restClientUser.GetRequest(order.UserId.ToString());

            return orderDtoSend;

        }
    }
}
