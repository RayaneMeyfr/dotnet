namespace OrderService.DTO
{
    public class OrderDtoReceive
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<int> ProductIds { get; set; }
    }
}
