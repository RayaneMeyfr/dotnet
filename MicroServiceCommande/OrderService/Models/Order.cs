using System.ComponentModel.DataAnnotations;

namespace OrderService.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<int> ProductIds { get; set; }

        public Order()
        {
            ProductIds = new List<int>();
        }
    }
}
