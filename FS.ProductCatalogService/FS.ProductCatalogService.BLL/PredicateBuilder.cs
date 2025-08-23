using FS.ProductCatalogService.BLL.Interfaces;
using FS.ProductCatalogService.BLL.Interfaces.DB;
namespace FS.ProductCatalogService.BLL;

internal class PredicateBuilder<TEntity, TFilter>(IRepository<TEntity> repository) : IPredicateBuilder<TEntity, TFilter>
    where TEntity : class
    where TFilter : class
{
    private readonly IRepository<TEntity> _repository = repository;

    public IQueryable<TEntity> Build(TFilter filter) => _repository.AsQueryable();
}
