namespace FS.ProductCatalogService.BLL.Interfaces.DB;

public interface IUnitOfWork
{
    public Task SaveAsync(CancellationToken cancellationToken);
    public void Save();
}
