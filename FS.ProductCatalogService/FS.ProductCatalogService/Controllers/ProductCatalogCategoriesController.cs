using FS.ProductCatalogService.BLL.Interfaces.ProductCatalogCategories;
using Microsoft.AspNetCore.Mvc;

namespace FS.ProductCatalogService.Controllers;

//[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProductCatalogCategoriesController(IProductCatalogCategoryBLL productCatalogCategoryBLL) : Controller
{
    private readonly IProductCatalogCategoryBLL _productCatalogCategoryBLL = productCatalogCategoryBLL;

    [HttpGet]
    public async Task<ProductCatalogCategoryResponse[]> GetArrayAsync([FromQuery] ProductCatalogCategoryFilter filter,
        CancellationToken cancellationToken)
    {
        return await _productCatalogCategoryBLL.GetArrayAsync(filter, cancellationToken);
    }

    [HttpPost]
    public async Task<ProductCatalogCategoryResponse> CreateAsync([FromBody] ProductCatalogCategoryRequest request, 
        CancellationToken cancellationToken)
    {
        return await _productCatalogCategoryBLL.CreateAsync(request, cancellationToken);
    }

    [HttpPut("{id}")]
    public async Task<ProductCatalogCategoryResponse> UpdateAsync([FromRoute] Guid id, 
        [FromBody] ProductCatalogCategoryRequest request, 
        CancellationToken cancellationToken)
    {
        return await _productCatalogCategoryBLL.UpdateAsync(id, request, cancellationToken);
    }

    [HttpDelete("{id}")]
    public async Task DeleteAsync([FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        await _productCatalogCategoryBLL.DeleteAsync(id, cancellationToken);
    }
}
