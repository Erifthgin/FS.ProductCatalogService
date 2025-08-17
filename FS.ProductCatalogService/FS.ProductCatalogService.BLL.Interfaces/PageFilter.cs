namespace FS.ProductCatalogService.BLL.Interfaces;

public class PageFilter
{
    public int? Skip { get; init; }
    public int? Take { get; init; }
    public bool? Asc { get; init; }
    public string SearchString { get; init; }
}
