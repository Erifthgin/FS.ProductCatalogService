using FluentValidation;
using FS.ProductCatalogService.BLL.Interfaces.Products;

namespace FS.ProductCatalogService.BLL.Products;

internal class ProductValidator : FluentValidator<ProductRequest>
{
    public override void Init()
    {
        RuleFor(model => model.Name).NotEmpty().WithMessage("Необходимо указать название продукта.");
        RuleFor(model => model.Price).NotEmpty().WithMessage("Необходимо указать стоимость продукта.");
        RuleFor(model => model.Count).NotEmpty().WithMessage("Необходимо указать количество продукта.");
        RuleFor(model => model.Description).NotEmpty().WithMessage("Необходимо указать описание продукта.");
    }
}
