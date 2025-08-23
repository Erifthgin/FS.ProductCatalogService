namespace FS.ProductCatalogService.BLL.Interfaces;

public interface IPredicateBuilder<TEntity, TFilter>
    where TEntity : class
    where TFilter : class
{
    public IQueryable<TEntity> Build(TFilter filter);
}
