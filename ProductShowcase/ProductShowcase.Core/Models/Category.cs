using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductShowcase.Core.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Category name cannot be longer than 100 characters.")]
        public string Name { get; set; }
        public bool IsDeleted { get; set; } = false;

        public ICollection<Product> Products { get; set; }
    }
}