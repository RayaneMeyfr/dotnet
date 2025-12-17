using ProductService.DTO;
using ProductService.Models;
using ProductService.Repository;

namespace ProductService.Service
{
    public class ProductiService : IService<ProductDtoReceive, ProductDtoSend>
    {

        private readonly IRepository<Product> repository;

        public ProductiService(IRepository<Product> repository)
        {
            this.repository = repository;
        }

        public ProductDtoSend Create(ProductDtoReceive receive)
        {
            return EntityToDto(repository.Create(DtoToEntity(receive, null)));
        }

        public bool Delete(int id)
        {
            return repository.Delete(id);
        }

        public List<ProductDtoSend> GetAll()
        {
            List<Product> products = repository.GetAll();
            List<ProductDtoSend> productDtoSends = new List<ProductDtoSend>();
            foreach (var product in products)
            {
                productDtoSends.Add(EntityToDto(product));
            }

            return productDtoSends;
        }

        public ProductDtoSend GetById(int id)
        {
            Product product = repository.GetById(id);
            if (product == null)
            {
                return null;
            }

            return EntityToDto(product);
        }

        public ProductDtoSend Update(ProductDtoReceive receive, int id)
        {
            return EntityToDto(repository.Update(DtoToEntity(receive, id)));
        }

        private Product DtoToEntity(ProductDtoReceive receive, int? id)
        {
            Product product = new Product()
            {
                Name = receive.Name,
                Description = receive.Description,
                Price = receive.Price
            };

            if (id != null)
            {
                product.Id = (int)id;
            }

            return product;
        }
        private ProductDtoSend EntityToDto(Product product)
        {
            return new ProductDtoSend()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            };
        }
    }
}
