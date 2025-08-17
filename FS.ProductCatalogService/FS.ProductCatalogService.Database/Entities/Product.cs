namespace FS.ProductCatalogService.Database.Entities;

public class Product : BaseEntity
{
    public string Name { get; init; }
    public decimal Price { get; init; }
    public decimal Count { get; init; }
    public string Description { get; init; }
    public Guid ProductCatalogTypeID { get; init; }
    public virtual ProductCatalogType ProductCatalogType { get; init; }
}
