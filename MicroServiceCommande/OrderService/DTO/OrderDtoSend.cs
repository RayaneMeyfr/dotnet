namespace OrderService.DTO
{
    public class OrderDtoSend
    {
        public int Id { get; set; }
        public UserDtoSend User { get; set; }
        public List<ProductDtoSend> Products { get; set; } = new List<ProductDtoSend>();
        public float Price => Products.Sum(p => p.Price);
    }
}
