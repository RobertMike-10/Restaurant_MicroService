using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Services.ShoppingCartApi.Models.Dto
{
    public class CartDetailDto
    {
        [Key]
        public int CartDetailId { get; set; }

        [Required]
        public int CartHeaderId { get; set; }      

        [Required]
        public int ProductId { get; set; }

        public int Count { get; set; }


    }

}
