namespace FS.ProductCatalogService.BLL.Interfaces.Products;

public class ProductFilter : PageFilter
{
    public Guid? ProductCatalogTypeID { get; init; }
}
