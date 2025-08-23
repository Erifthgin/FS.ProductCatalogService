namespace FS.ProductCatalogService.BLL.Interfaces.Products;

public class ProductResponse : ProductRequest
{
    public Guid ID { get; init; }
    public string ProductCatalogTypeName { get; init; }
}
