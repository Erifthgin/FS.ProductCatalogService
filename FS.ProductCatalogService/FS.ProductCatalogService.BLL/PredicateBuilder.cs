using FS.ProductCatalogService.BLL.Interfaces;
using System.Linq.Expressions;

namespace FS.ProductCatalogService.BLL;

internal class PredicateBuilder<TEntity, TFilter> : IPredicateBuilder<TEntity, TFilter>
    where TEntity : class
    where TFilter : class
{
    public Expression<Func<TEntity, bool>> Build(TFilter filter)
    {
        return x => true;
    }
}
