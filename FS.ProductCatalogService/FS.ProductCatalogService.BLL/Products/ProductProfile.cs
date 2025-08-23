using AutoMapper;
using FS.ProductCatalogService.BLL.Extensions;
using FS.ProductCatalogService.BLL.Interfaces.Products;
using FS.ProductCatalogService.Database.Entities;

namespace FS.ProductCatalogService.BLL.Products;

internal class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductRequest, Product>()
            .IgnoreNulls();

        CreateMap<Product, ProductResponse>()
            .ForMember(response => response.ProductCatalogTypeName,
                mapper => mapper.MapFrom(entity => entity.ProductCatalogType.Name));
    }
}
