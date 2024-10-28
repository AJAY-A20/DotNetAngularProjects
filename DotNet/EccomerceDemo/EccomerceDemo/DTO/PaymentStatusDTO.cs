using System.ComponentModel.DataAnnotations;

namespace EccomerceDemo.DTO
{
    public class PaymentStatusDTO
    {
        [Required]
        public int PaymentId { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
