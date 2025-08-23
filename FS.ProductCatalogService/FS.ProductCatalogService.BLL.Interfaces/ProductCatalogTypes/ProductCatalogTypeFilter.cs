namespace FS.ProductCatalogService.BLL.Interfaces.ProductCatalogTypes;

public class ProductCatalogTypeFilter : PageFilter
{
    public Guid? ProductCatalogCategoryID { get; init; }
}
