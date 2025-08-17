using FS.ProductCatalogService.BLL.DB;
using FS.ProductCatalogService.BLL.Interfaces;
using FS.ProductCatalogService.BLL.Interfaces.DB;
using FS.ProductCatalogService.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FS.ProductCatalogService.BLL;

public static class ServiceCollection
{
    public static void AddInfrastructureBLL(this IServiceCollection service)
    {
        service.AddDbSets();
        service.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        service.AddScoped<IUnitOfWork, UnitOfWork>();
        service.AddScoped(typeof(IPredicateBuilder<>), typeof(PredicateBuilder<>));
    }

    private static IServiceCollection AddDbSets(this IServiceCollection services)
    {
        var getDbSet = typeof(DbContext).GetMethod(nameof(DbContext.Set), Array.Empty<Type>());

        foreach (var entityType in EntityTypes)
        {
            var genericSet = getDbSet.MakeGenericMethod(entityType);
            services.AddScoped(
                typeof(DbSet<>).MakeGenericType(entityType),
                provider => genericSet.Invoke(provider.GetService<ApplicationDbContext>(), Array.Empty<object>()));
        }

        return services;
    }

    private static IEnumerable<Type> EntityTypes => Assembly.GetExecutingAssembly().GetTypes()
        .Where(t => t.IsClass && !t.IsAbstract && !t.IsSubclassOf(typeof(DbContext)));
}
