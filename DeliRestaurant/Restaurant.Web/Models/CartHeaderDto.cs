using System.ComponentModel.DataAnnotations;

namespace Restaurant.Web.Models
{
    public class CartHeaderDto
    {
        public int CardHeaderId { get; set; }

        [Required]
        public string UserId { get; set; }
        public string? CuoponCode { get; set; }
        public Double OrderTotal { get; set; }
    }
}
