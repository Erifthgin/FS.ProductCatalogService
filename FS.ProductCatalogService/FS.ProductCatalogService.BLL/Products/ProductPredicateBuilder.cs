using FS.ProductCatalogService.BLL.Interfaces;
using FS.ProductCatalogService.BLL.Interfaces.DB;
using FS.ProductCatalogService.BLL.Interfaces.Products;
using FS.ProductCatalogService.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace FS.ProductCatalogService.BLL.Products;

internal class ProductPredicateBuilder(IRepository<Product> repository)
    : IPredicateBuilder<Product, ProductFilter>
{
    private readonly IRepository<Product> _repository = repository;

    public IQueryable<Product> Build(ProductFilter filter)
    {
        var query = _repository.AsQueryable();

        if (!string.IsNullOrWhiteSpace(filter.SearchString))
        {
            query = query.Where(x => EF.Functions.Like(x.Name, $"%{filter.SearchString}%")
                || EF.Functions.Like(x.Description, $"%{filter.SearchString}%"));
        }

        if (filter.ProductCatalogTypeID.HasValue)
        {
            query = query.Where(x => x.ProductCatalogTypeID == filter.ProductCatalogTypeID);
        }

        return query;
    }
}
