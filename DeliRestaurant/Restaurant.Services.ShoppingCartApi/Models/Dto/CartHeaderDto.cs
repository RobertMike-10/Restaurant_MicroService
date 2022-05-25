using System.ComponentModel.DataAnnotations;

namespace Restaurant.Services.ShoppingCartApi.Models.Dto
{
    public class CartHeaderDto
    {
        
        public int CardHeaderId { get; set; }

        [Required]
        public string userId { get; set; }
        public string? cuoponCode { get; set; }


    }
}
