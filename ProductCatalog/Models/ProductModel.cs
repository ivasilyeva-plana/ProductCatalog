namespace ProductCatalog.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        public ProductCategoryModel ProductCategory { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Specification { get; set; }
    }
}
