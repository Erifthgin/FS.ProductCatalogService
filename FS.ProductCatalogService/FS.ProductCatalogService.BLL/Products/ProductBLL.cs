using AutoMapper;
using FS.ProductCatalogService.BLL.Interfaces;
using FS.ProductCatalogService.BLL.Interfaces.DB;
using FS.ProductCatalogService.BLL.Interfaces.Products;
using FS.ProductCatalogService.Database.Entities;
using Microsoft.Extensions.Logging;

namespace FS.ProductCatalogService.BLL.Products;

internal class ProductBLL(IRepository<Product> repository,
    IUnitOfWork unitOfWork,
    IMapper mapper,
    IFluentValidator<ProductRequest> requestValidator,
    ILogger<ProductBLL> logger,
    IPredicateBuilder<Product, ProductFilter> predicateBuilder) : 
    StandardBLL<Product, ProductRequest, ProductResponse, ProductFilter>(
        repository, unitOfWork, mapper, requestValidator, logger, predicateBuilder),
    IProductBLL
{
}
