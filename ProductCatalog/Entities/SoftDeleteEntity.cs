namespace ProductCatalog.Entities
{
    public abstract class SoftDeleteEntity
    {
        public bool IsDeleted { get; set; }
    }
}
