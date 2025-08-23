using AutoMapper;
using FS.ProductCatalogService.BLL.Extensions;
using FS.ProductCatalogService.BLL.Interfaces.ProductCatalogTypes;
using FS.ProductCatalogService.Database.Entities;

namespace FS.ProductCatalogService.BLL.ProductCatalogTypes;

internal class ProductCatalogTypeProfile : Profile
{
    public ProductCatalogTypeProfile()
    {
        CreateMap<ProductCatalogTypeRequest, ProductCatalogType>()
            .IgnoreNulls();

        CreateMap<ProductCatalogType, ProductCatalogTypeResponse>()
            .ForMember(response => response.ProductCatalogCategoryName,
                mapper => mapper.MapFrom(entity => entity.ProductCatalogCategory.Name));
    }
}
