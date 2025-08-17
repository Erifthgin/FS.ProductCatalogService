using System.Linq.Expressions;

namespace FS.ProductCatalogService.BLL.Interfaces;

public interface IPredicateBuilder<TEntity, TFilter>
    where TEntity : class
    where TFilter : class
{
    Expression<Func<TEntity, bool>> Build(TFilter filter);
}
