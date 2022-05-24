using System.ComponentModel.DataAnnotations;

namespace Restaurant.Web.Models
{
    public class ProductDto
    {
        public ProductDto()
        {
            Count = 0;
        }
        public int ProductId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Range(1, 50000)]
        public decimal Price { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        [MaxLength(50)]
        public string? CategoryName { get; set; }
        public string? imageUrl { get; set; }

        [Range(1,100)]
        public int Count { get; set; }
    }
}
