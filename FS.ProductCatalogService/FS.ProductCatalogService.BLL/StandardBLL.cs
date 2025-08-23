using AutoMapper;
using FS.ProductCatalogService.BLL.Interfaces;
using FS.ProductCatalogService.BLL.Interfaces.DB;
using FS.ProductCatalogService.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FS.ProductCatalogService.BLL;

internal class StandardBLL<TEntity, TRequest, TResponse, TFilter>(IRepository<TEntity> repository,
    IUnitOfWork unitOfWork,
    IMapper mapper,
    IFluentValidator<TRequest> requestValidator,
    ILogger logger,
    IPredicateBuilder<TEntity, TFilter> predicateBuilder)
    where TEntity : BaseEntity
    where TRequest : class
    where TResponse : class
    where TFilter : PageFilter
{
    public readonly IRepository<TEntity> _repository = repository;
    public readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly IFluentValidator<TRequest> _requestValidator = requestValidator;
    private readonly ILogger _logger = logger;
    private readonly IPredicateBuilder<TEntity, TFilter> _predicateBuilder = predicateBuilder;

    public async Task<TResponse> CreateAsync(TRequest request, CancellationToken cancellationToken)
    {
        var validateResult = await _requestValidator.ValidateAsync(request, cancellationToken);

        if (!validateResult.IsValid)
        {
            var errorMessage = validateResult.Errors.FirstOrDefault().ErrorMessage;
            _logger.LogError(errorMessage);
            throw new InvalidOperationException(errorMessage);
        }

        var entity = _mapper.Map<TEntity>(request);
        _repository.Insert(entity);
        await _unitOfWork.SaveAsync(cancellationToken);

        return _mapper.Map<TResponse>(entity);
    }

    public async Task<TResponse> UpdateAsync(Guid id, TRequest request, CancellationToken cancellationToken)
    {
        var entity = await _repository.FirstOrDefaultAsync(x => x.ID == id, cancellationToken)
            ?? throw new InvalidOperationException("Объект не найден");
        _mapper.Map(request, entity);
        _repository.Update(entity);
        await _unitOfWork.SaveAsync(cancellationToken);
        return _mapper.Map<TResponse>(entity);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _repository.FirstOrDefaultAsync(x => x.ID == id, cancellationToken)
            ?? throw new InvalidOperationException("Объект не найден");
        _repository.Delete(entity);
        await _unitOfWork.SaveAsync(cancellationToken);
    }

    public async Task<TResponse[]> GetArrayAsync(TFilter filter, CancellationToken cancellationToken)
    {
        var query = _predicateBuilder.Build(filter);

        if (filter.Take.HasValue && filter.Skip.HasValue)
        {
            query = query.Skip(filter.Take.Value).Take(filter.Take.Value);
        }

        var entities = await (!filter.Asc.HasValue || filter.Asc.Value
            ? query.OrderBy(x => x.ID)
            : query.OrderByDescending(x => x.ID))
            .ToArrayAsync(cancellationToken);

        return _mapper.Map<TResponse[]>(entities);
    }
}
