using System.ComponentModel.DataAnnotations;

namespace Restaurant.Web.Models
{
    public class CartDetailDto
    {
       
        public int CartDetailId { get; set; }

        [Required]
        public int CartHeaderId { get; set; }

        [Required]
        public int ProductId { get; set; }

        public int Count { get; set; }
        public virtual ProductDto Product { get; set; }

    }
}
