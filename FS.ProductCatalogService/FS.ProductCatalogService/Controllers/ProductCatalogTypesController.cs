using FS.ProductCatalogService.BLL.Interfaces.ProductCatalogTypes;
using Microsoft.AspNetCore.Mvc;

namespace FS.ProductCatalogService.Controllers;

//[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProductCatalogTypesController(IProductCatalogTypeBLL productCatalogTypeBLL) : Controller
{
    private readonly IProductCatalogTypeBLL _productCatalogTypeBLL = productCatalogTypeBLL;

    [HttpGet]
    public async Task<ProductCatalogTypeResponse[]> GetArrayAsync([FromQuery] ProductCatalogTypeFilter filter,
        CancellationToken cancellationToken)
    {
        return await _productCatalogTypeBLL.GetArrayAsync(filter, cancellationToken);
    }

    [HttpPost]
    public async Task<ProductCatalogTypeResponse> CreateAsync([FromBody] ProductCatalogTypeRequest request, 
        CancellationToken cancellationToken)
    {
        return await _productCatalogTypeBLL.CreateAsync(request, cancellationToken);
    }

    [HttpPut("{id}")]
    public async Task<ProductCatalogTypeResponse> UpdateAsync([FromRoute] Guid id, 
        [FromBody] ProductCatalogTypeRequest request, 
        CancellationToken cancellationToken)
    {
        return await _productCatalogTypeBLL.UpdateAsync(id, request, cancellationToken);
    }

    [HttpDelete("{id}")]
    public async Task DeleteAsync([FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        await _productCatalogTypeBLL.DeleteAsync(id, cancellationToken);
    }
}
