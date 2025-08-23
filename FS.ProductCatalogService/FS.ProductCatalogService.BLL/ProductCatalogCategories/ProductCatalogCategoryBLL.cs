using AutoMapper;
using FS.ProductCatalogService.BLL.Interfaces;
using FS.ProductCatalogService.BLL.Interfaces.DB;
using FS.ProductCatalogService.BLL.Interfaces.ProductCatalogCategories;
using FS.ProductCatalogService.Database.Entities;
using Microsoft.Extensions.Logging;

namespace FS.ProductCatalogService.BLL.ProductCatalogCategories;

internal class ProductCatalogCategoryBLL(IRepository<ProductCatalogCategory> repository,
    IUnitOfWork unitOfWork,
    IMapper mapper, 
    IFluentValidator<ProductCatalogCategoryRequest> requestValidator,
    ILogger<ProductCatalogCategoryBLL> logger,
    IPredicateBuilder<ProductCatalogCategory, ProductCatalogCategoryFilter> predicateBuilder) : 
    StandardBLL<ProductCatalogCategory, ProductCatalogCategoryRequest, ProductCatalogCategoryResponse, ProductCatalogCategoryFilter>(
        repository, unitOfWork, mapper, requestValidator, logger, predicateBuilder),
    IProductCatalogCategoryBLL
{
}
