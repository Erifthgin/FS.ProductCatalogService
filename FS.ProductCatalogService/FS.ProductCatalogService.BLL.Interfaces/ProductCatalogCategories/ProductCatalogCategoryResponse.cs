namespace FS.ProductCatalogService.BLL.Interfaces.ProductCatalogCategories;

public class ProductCatalogCategoryResponse : ProductCatalogCategoryRequest
{
    public Guid ID { get; init; }
    public string ParentProductCatalogCategoryName { get; init; }
}
