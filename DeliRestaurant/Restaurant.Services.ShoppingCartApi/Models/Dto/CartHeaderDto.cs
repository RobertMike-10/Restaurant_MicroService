using System.ComponentModel.DataAnnotations;

namespace Restaurant.Services.ShoppingCartApi.Models.Dto
{
    public class CartHeaderDto
    {        
        public int CartHeaderId { get; set; }

        [Required]
        public string UserId { get; set; }
        public string? CuoponCode { get; set; }

    }
}
