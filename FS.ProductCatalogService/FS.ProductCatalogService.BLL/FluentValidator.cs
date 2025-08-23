using FluentValidation;
using FluentValidation.Results;
using FS.ProductCatalogService.BLL.Interfaces;

namespace FS.ProductCatalogService.BLL;

internal abstract class FluentValidator<T> : AbstractValidator<T>, IFluentValidator<T>
{
    public abstract void Init();

    public async Task<ValidationResult> ValidateAsync(T data, CancellationToken cancellationToken)
    {
        Init();
        return await base.ValidateAsync(data, cancellationToken);
    }
}
