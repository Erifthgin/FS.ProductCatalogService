using FluentValidation;
using FS.ProductCatalogService.BLL.Interfaces.ProductCatalogCategories;

namespace FS.ProductCatalogService.BLL.ProductCatalogCategories;

internal class ProductCatalogCategoryValidator : FluentValidator<ProductCatalogCategoryRequest>
{
    public override void Init()
    {
        RuleFor(model => model.Name).NotEmpty().WithMessage("Необходимо указать название категории.");
    }
}
