using FluentValidation;
using FS.ProductCatalogService.BLL.Interfaces.ProductCatalogTypes;

namespace FS.ProductCatalogService.BLL.ProductCatalogTypes;

internal class ProductCatalogTypeValidator : FluentValidator<ProductCatalogTypeRequest>
{
    public override void Init()
    {
        RuleFor(model => model.Name).NotEmpty().WithMessage("Необходимо указать название типа продукта.");
    }
}
