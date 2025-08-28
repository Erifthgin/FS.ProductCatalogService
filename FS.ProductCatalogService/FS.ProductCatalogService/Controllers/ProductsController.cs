using FS.ProductCatalogService.BLL.Interfaces.Products;
using Microsoft.AspNetCore.Mvc;

namespace FS.ProductCatalogService.Controllers;

//[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProductsController(IProductBLL productBLL) : Controller
{
    private readonly IProductBLL _productBLL = productBLL;

    [HttpGet]
    public async Task<ProductResponse[]> GetArrayAsync([FromQuery] ProductFilter filter,
        CancellationToken cancellationToken)
    {
        return await _productBLL.GetArrayAsync(filter, cancellationToken);
    }

    [HttpPost]
    public async Task<ProductResponse> CreateAsync([FromBody] ProductRequest request, 
        CancellationToken cancellationToken)
    {
        return await _productBLL.CreateAsync(request, cancellationToken);
    }

    [HttpPut("{id}")]
    public async Task<ProductResponse> UpdateAsync([FromRoute] Guid id, 
        [FromBody] ProductRequest request, 
        CancellationToken cancellationToken)
    {
        return await _productBLL.UpdateAsync(id, request, cancellationToken);
    }

    [HttpDelete("{id}")]
    public async Task DeleteAsync([FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        await _productBLL.DeleteAsync(id, cancellationToken);
    }
}
