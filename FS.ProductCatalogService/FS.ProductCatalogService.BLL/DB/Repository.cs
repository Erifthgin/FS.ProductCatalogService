using FS.ProductCatalogService.BLL.Interfaces.DB;
using FS.ProductCatalogService.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FS.ProductCatalogService.BLL.DB;

internal class Repository<TEntity>(ApplicationDbContext context) : IRepository<TEntity> where TEntity : class
{
    private readonly DbSet<TEntity> _entities = context.Set<TEntity>();

    public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _entities.FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public async Task<TEntity> FirstOrDefaultAsync(CancellationToken cancellationToken = default)
    {
        return await _entities.FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<TEntity[]> ArrayAsync(CancellationToken cancellationToken = default)
    {
        return await _entities.ToArrayAsync(cancellationToken);
    }

    public async Task<TEntity[]> ArrayAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _entities.Where(predicate).ToArrayAsync(cancellationToken);
    }

    public void Insert(TEntity entity)
    {
        _entities.Add(entity);
    }

    public void Update(TEntity entity)
    {
        _entities.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        _entities.Remove(entity);
    }

    public IQueryable<TEntity> OrderBy<TKey>(Expression<Func<TEntity, TKey>> orderBy, bool isDesc = true)
    {
        return isDesc ? _entities.OrderByDescending(orderBy) : _entities.OrderBy(orderBy);
    }

    public IQueryable<IGrouping<TKey, TEntity>> GroupBy<TKey>(Expression<Func<TEntity, TKey>> groupBy)
    {
        return _entities.GroupBy(groupBy);
    }

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _entities.AnyAsync(predicate, cancellationToken);
    }

    public IQueryable<TEntity> AsQueryable()
    {
        return _entities.AsQueryable();
    }
}