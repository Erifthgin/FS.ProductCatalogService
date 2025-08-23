using System.Linq.Expressions;

namespace FS.ProductCatalogService.BLL.Interfaces.DB;

public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    Task<TEntity> FirstOrDefaultAsync(CancellationToken cancellationToken = default);
    Task<TEntity[]> ArrayAsync(CancellationToken cancellationToken = default);
    Task<TEntity[]> ArrayAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    IQueryable<TEntity> AsQueryable();
    void Insert(TEntity entity);
    void Delete(TEntity entity);
    void Update(TEntity entity);
}
