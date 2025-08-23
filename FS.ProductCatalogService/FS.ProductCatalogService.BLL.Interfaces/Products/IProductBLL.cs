namespace FS.ProductCatalogService.BLL.Interfaces.Products;

public interface IProductBLL
{
    public Task<ProductResponse> CreateAsync(ProductRequest request, CancellationToken cancellationToken);
    public Task<ProductResponse> UpdateAsync(Guid id, ProductRequest request, CancellationToken cancellationToken);
    public Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    public Task<ProductResponse[]> GetArrayAsync(ProductFilter filter, CancellationToken cancellationToken);
}
