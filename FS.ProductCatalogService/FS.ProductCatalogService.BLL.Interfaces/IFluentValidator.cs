using FluentValidation.Results;

namespace FS.ProductCatalogService.BLL.Interfaces;

public interface IFluentValidator<T>
{
    public Task<ValidationResult> ValidateAsync(T data, CancellationToken cancellationToken);
}
