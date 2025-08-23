using FS.ProductCatalogService.BLL.Interfaces;
using FS.ProductCatalogService.BLL.Interfaces.DB;
using FS.ProductCatalogService.BLL.Interfaces.ProductCatalogTypes;
using FS.ProductCatalogService.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace FS.ProductCatalogService.BLL.ProductCatalogTypes;

internal class ProductCatalogTypePredicateBuilder(IRepository<ProductCatalogType> repository)
    : IPredicateBuilder<ProductCatalogType, ProductCatalogTypeFilter>
{
    private readonly IRepository<ProductCatalogType> _repository = repository;

    public IQueryable<ProductCatalogType> Build(ProductCatalogTypeFilter filter)
    {
        var query = _repository.AsQueryable();

        if (!string.IsNullOrWhiteSpace(filter.SearchString))
        {
            query = query.Where(x => EF.Functions.Like(x.Name, $"%{filter.SearchString}%"));
        }

        if (filter.ProductCatalogCategoryID.HasValue)
        {
            query = query.Where(x => x.ProductCatalogCategoryID == filter.ProductCatalogCategoryID);
        }

        return query;
    }
}
