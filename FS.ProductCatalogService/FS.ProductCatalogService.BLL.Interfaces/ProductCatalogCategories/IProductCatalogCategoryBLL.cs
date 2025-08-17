namespace FS.ProductCatalogService.BLL.Interfaces.ProductCatalogCategories;

public interface IProductCatalogCategoryBLL
{
    public Task<ProductCatalogCategoryResponse> CreateAsync(ProductCatalogCategoryRequest request, CancellationToken cancellationToken);
    public Task<ProductCatalogCategoryResponse> UpdateAsync(Guid id, ProductCatalogCategoryRequest request, CancellationToken cancellationToken);
    public Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    public Task<ProductCatalogCategoryResponse[]> GetArrayAsync(ProductCatalogCategoryFilter filter, CancellationToken cancellationToken);
}
