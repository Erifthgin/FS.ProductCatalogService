using FS.ProductCatalogService.BLL;
using FS.ProductCatalogService.Database;

namespace FS.ProductCatalogService;

public static class InfrastructureServiceCollection
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabaseServices(configuration);
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddInfrastructureBLL();
        services.AddLogging();
    }
}
