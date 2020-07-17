using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.Entities
{
    public class ProductCategory
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } 

        public string Description { get; set; }

        public ICollection<Product> Products { get; } = new List<Product>();
    }
}
