using AutoMapper;
using FS.ProductCatalogService.BLL.Interfaces;
using FS.ProductCatalogService.BLL.Interfaces.DB;
using FS.ProductCatalogService.BLL.Interfaces.ProductCatalogTypes;
using FS.ProductCatalogService.Database.Entities;
using Microsoft.Extensions.Logging;

namespace FS.ProductCatalogService.BLL.ProductCatalogTypes;

internal class ProductCatalogTypeBLL(IRepository<ProductCatalogType> repository,
    IUnitOfWork unitOfWork,
    IMapper mapper, 
    IFluentValidator<ProductCatalogTypeRequest> requestValidator,
    ILogger<ProductCatalogTypeBLL> logger,
    IPredicateBuilder<ProductCatalogType, ProductCatalogTypeFilter> predicateBuilder) : 
    StandardBLL<ProductCatalogType, ProductCatalogTypeRequest, ProductCatalogTypeResponse, ProductCatalogTypeFilter>(
        repository, unitOfWork, mapper, requestValidator, logger, predicateBuilder),
    IProductCatalogTypeBLL
{
}
