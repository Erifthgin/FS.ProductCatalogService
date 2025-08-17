using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FS.ProductCatalogService.Database;

public static class ServiceCollection
{
    public static void AddDatabaseServices(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddDbContextPool<ApplicationDbContext>(opt =>
        {
            opt.UseNpgsql(configuration["ConnectionString"]);
        });

        service.AddDbSets();
    }

    private static IServiceCollection AddDbSets(this IServiceCollection services)
    {
        var getDbSet = typeof(DbContext).GetMethod(nameof(DbContext.Set), []);

        foreach (var entityType in EntityTypes)
        {
            var genericSet = getDbSet.MakeGenericMethod(entityType);
            services.AddScoped(
                typeof(DbSet<>).MakeGenericType(entityType),
                provider => genericSet.Invoke(provider.GetService<ApplicationDbContext>(), []));
        }

        return services;
    }

    private static IEnumerable<Type> EntityTypes => Assembly.GetExecutingAssembly().GetTypes()
        .Where(t => t.IsClass && !t.IsAbstract && !t.IsSubclassOf(typeof(DbContext)));
}