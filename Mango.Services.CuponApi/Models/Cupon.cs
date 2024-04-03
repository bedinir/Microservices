namespace Mango.Services.CuponApi.Models
{
    public class Cupon
    {
        public int CuponId { get; set; }
        public string CuponCode { get; set; }
        public string DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }
}
