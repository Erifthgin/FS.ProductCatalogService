namespace FS.ProductCatalogService.BLL.Interfaces.ProductCatalogCategories;

public class ProductCatalogCategoryRequest
{
    public string Name { get; init; }
    public Guid ParentProductCatalogCategoryID { get; init; }
}
