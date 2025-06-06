namespace Catalog.Features.Products.GetProducts;

public record GetProductsQuery(
    Guid? BrandId,
    decimal? MinPrice,
    decimal? MaxPrice,
    string? Search,
    string? SortBy,       // e.g. "price", "name", "rating"
    string? SortOrder,    // "asc" or "desc"
    int Page = 1,
    int PageSize = 10)
    : IQuery<GetProductsResult>;

public record GetProductsResult(PaginatedResult<ProductDto> Products);