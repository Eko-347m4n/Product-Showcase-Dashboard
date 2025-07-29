using System.ComponentModel.DataAnnotations;

namespace ProductShowcase.Core.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "Product name cannot be longer than 200 characters.")]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public bool IsDeleted { get; set; } = false;

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
