namespace FS.ProductCatalogService.BLL.Interfaces.ProductCatalogType;

public class ProductCatalogTypeRequest
{
    public string Name { get; init; }
    public Guid ProductCatalogCategoryID { get; init; }
}
