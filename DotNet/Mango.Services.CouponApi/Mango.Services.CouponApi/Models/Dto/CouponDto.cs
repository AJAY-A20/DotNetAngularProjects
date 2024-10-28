namespace Mango.Services.CouponApi.Models.Dto
{
    public class CouponDto
    {
        public int CouponId { get; set; }
        public string? CounponCode { get; set; }
        public string? DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }
}
