using System;
using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.Entities
{
    public class Product : SoftDeleteEntity
    {
        public int Id { get; set; }

        public int ProductCategoryId { get; set; }

        public ProductCategory ProductCategory { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Specification { get; set; }

    }
}
