namespace FS.ProductCatalogService.Database.Entities;

public class ProductCatalogCategory : BaseEntity
{
    public string Name { get; init; }
    public Guid ParentProductCatalogCategoryID { get; init; }
    public virtual ProductCatalogCategory ParentProductCatalogCategory { get; }
}
