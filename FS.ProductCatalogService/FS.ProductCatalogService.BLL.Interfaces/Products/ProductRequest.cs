namespace FS.ProductCatalogService.BLL.Interfaces.Products;

public class ProductRequest
{
    public string Name { get; init; }
    public decimal? Price { get; init; }
    public decimal? Count { get; init; }
    public string Description { get; init; }
    public Guid? ProductCatalogTypeID { get; init; }
}
