namespace FS.ProductCatalogService.BLL.Interfaces.ProductCatalogTypes;

public class ProductCatalogTypeRequest
{
    public string Name { get; init; }
    public Guid? ProductCatalogCategoryID { get; init; }
}
