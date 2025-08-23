namespace FS.ProductCatalogService.BLL.Interfaces.ProductCatalogTypes;

public interface IProductCatalogTypeBLL
{
    public Task<ProductCatalogTypeResponse> CreateAsync(ProductCatalogTypeRequest request, CancellationToken cancellationToken);
    public Task<ProductCatalogTypeResponse> UpdateAsync(Guid id, ProductCatalogTypeRequest request, CancellationToken cancellationToken);
    public Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    public Task<ProductCatalogTypeResponse[]> GetArrayAsync(ProductCatalogTypeFilter filter, CancellationToken cancellationToken);
}
