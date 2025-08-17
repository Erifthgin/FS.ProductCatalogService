using FS.ProductCatalogService.Database;

namespace FS.ProductCatalogService;

public static class ServiceCollection
{
    public static void AddServices(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddDatabaseServices(configuration);
        service.AddAutoMapper(typeof(Program));
    }
}
