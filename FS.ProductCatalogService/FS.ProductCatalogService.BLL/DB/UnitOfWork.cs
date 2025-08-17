using FS.ProductCatalogService.BLL.Interfaces.DB;
using FS.ProductCatalogService.Database;

namespace FS.ProductCatalogService.BLL.DB;

internal class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
    private readonly ApplicationDbContext _context = context;

    public void Save()
    {
        _context.SaveChanges();
    }

    public async Task SaveAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
