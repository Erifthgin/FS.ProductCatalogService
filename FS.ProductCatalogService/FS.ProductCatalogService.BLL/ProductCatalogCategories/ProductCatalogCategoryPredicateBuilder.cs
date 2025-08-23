using FS.ProductCatalogService.BLL.Interfaces;
using FS.ProductCatalogService.BLL.Interfaces.DB;
using FS.ProductCatalogService.BLL.Interfaces.ProductCatalogCategories;
using FS.ProductCatalogService.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace FS.ProductCatalogService.BLL.ProductCatalogCategories;

internal class ProductCatalogCategoryPredicateBuilder(IRepository<ProductCatalogCategory> repository)
    : IPredicateBuilder<ProductCatalogCategory, ProductCatalogCategoryFilter>
{
    private readonly IRepository<ProductCatalogCategory> _repository = repository;

    public IQueryable<ProductCatalogCategory> Build(ProductCatalogCategoryFilter filter)
    {
        var query = _repository.AsQueryable();

        if (!string.IsNullOrWhiteSpace(filter.SearchString))
        {
            query = query.Where(x => EF.Functions.Like(x.Name, $"%{filter.SearchString}%"));
        }

        if (filter.ParentProductCatalogCategoryID.HasValue)
        {
            query = query.Where(x => x.ParentProductCatalogCategoryID == filter.ParentProductCatalogCategoryID);
        }

        return query;
    }
}
