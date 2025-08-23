using AutoMapper;

namespace FS.ProductCatalogService.BLL.Extensions;

internal static class AutoMapperExtension
{
    public static void IgnoreNulls<TSource, TDestination>(this IMappingExpression<TSource, TDestination> mapping)
    {
        mapping.ForAllMembers(opt => opt.Condition((src, destination, srcMember, targetMember) => srcMember != null));
    }
}
