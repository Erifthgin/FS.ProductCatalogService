using AutoMapper;
using FS.ProductCatalogService.BLL.Extensions;
using FS.ProductCatalogService.BLL.Interfaces.ProductCatalogCategories;
using FS.ProductCatalogService.Database.Entities;

namespace FS.ProductCatalogService.BLL.ProductCatalogCategories;

internal class ProductCatalogCategoryProfile : Profile
{
    public ProductCatalogCategoryProfile()
    {
        CreateMap<ProductCatalogCategoryRequest, ProductCatalogCategory>()
            .IgnoreNulls();

        CreateMap<ProductCatalogCategory, ProductCatalogCategoryResponse>()
            .ForMember(response => response.ParentProductCatalogCategoryName, 
                mapper => mapper.MapFrom(entity => entity.ParentProductCatalogCategory.Name));
    }
}
