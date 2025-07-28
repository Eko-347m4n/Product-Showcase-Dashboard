using System.Collections.Generic;

namespace ProductShowcase.Core.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; } = false;

        public ICollection<Product> Products { get; set; }
    }
}