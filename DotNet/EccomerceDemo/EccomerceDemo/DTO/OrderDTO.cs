using System.ComponentModel.DataAnnotations;

namespace EccomerceDemo.DTO
{
    public class OrderDTO
    {

        [Required]
        public int CustomerId { get; set; }
        [Required]
        public List<OrderItemDetailsDTO> Items { get; set; }
    }
}
