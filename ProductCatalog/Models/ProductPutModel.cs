namespace ProductCatalog.Models
{
    public class ProductPutModel
    {
        public int ProductCategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Specification { get; set; }
    }
}
