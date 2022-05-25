using System.ComponentModel.DataAnnotations;

namespace Restaurant.Services.ShoppingCartApi.Models
{
    public class CartHeader
    {
        [Key]
        public int CardHeaderId { get; set; }

        [Required]
        public string userId { get; set; }
        public string? cuoponCode { get; set; }


    }
}
