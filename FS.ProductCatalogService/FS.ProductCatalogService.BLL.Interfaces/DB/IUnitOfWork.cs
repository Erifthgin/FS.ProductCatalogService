namespace FS.ProductCatalogService.BLL.Interfaces.DB;

public interface IUnitOfWork
{
    Task SaveAsync(CancellationToken cancellationToken);
    void Save();
}
