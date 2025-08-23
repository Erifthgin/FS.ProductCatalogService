namespace FS.ProductCatalogService.BLL.Interfaces.ProductCatalogTypes;

public class ProductCatalogTypeResponse : ProductCatalogTypeRequest
{
    public Guid ID { get; init; }
    public string ProductCatalogCategoryName { get; init; }
}
