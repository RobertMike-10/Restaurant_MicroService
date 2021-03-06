using System.ComponentModel.DataAnnotations;

namespace Restaurant.Services.ProductApi.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(50)]
        public String Name { get; set; }
        [Range(1,50000)]
        public decimal Price { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [MaxLength(50)]
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
    }
}
