namespace FS.ProductCatalogService.BLL.Interfaces.ProductCatalogCategories;

public class ProductCatalogCategoryFilter : PageFilter
{
    public Guid? ParentProductCatalogCategoryID { get; init; }
}
