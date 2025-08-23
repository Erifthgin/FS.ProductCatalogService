using FS.ProductCatalogService.BLL.Interfaces.ProductCatalogCategories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FS.ProductCatalogService.Test;

public class ProductCatalogCategoryTest
{
    private readonly ServiceProvider _serviceProvider;

    public ProductCatalogCategoryTest()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        var services = new ServiceCollection();
        services.AddInfrastructureServices(config);
        _serviceProvider = services.BuildServiceProvider();
    }

    [Fact]
    public async Task GetArrayAsync()
    {
        var productCatalogCategoryBLL = _serviceProvider.GetService<IProductCatalogCategoryBLL>();
        var cancellationTokenSource = new CancellationTokenSource();
        var result = await productCatalogCategoryBLL.GetArrayAsync(new ProductCatalogCategoryFilter(), cancellationTokenSource.Token);
    }

    [Fact]
    public async Task CreateAsync()
    {
        var productCatalogCategoryBLL = _serviceProvider.GetService<IProductCatalogCategoryBLL>();
        var cancellationTokenSource = new CancellationTokenSource();
        var request = new ProductCatalogCategoryRequest
        {
            Name = "Тестовая категория"
        };

        var result = await productCatalogCategoryBLL.CreateAsync(request, cancellationTokenSource.Token);
    }

    [Fact]
    public async Task DeleteAsync()
    {
        var productCatalogCategoryBLL = _serviceProvider.GetService<IProductCatalogCategoryBLL>();
        var cancellationTokenSource = new CancellationTokenSource();
        var id = new Guid("0198d6de-162f-71fe-a7d1-8bbc58e44c78");
        await productCatalogCategoryBLL.DeleteAsync(id, cancellationTokenSource.Token);
    }
}