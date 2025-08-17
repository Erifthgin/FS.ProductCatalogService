namespace FS.ProductCatalogService.Database.Entities;

public class ProductCatalogType : BaseEntity
{
    public string Name { get; init; }
    public Guid ProductCatalogCategoryID { get; init; }
    public virtual ProductCatalogCategory ProductCatalogCategory { get; }
}
