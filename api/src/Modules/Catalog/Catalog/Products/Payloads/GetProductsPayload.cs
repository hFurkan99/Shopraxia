namespace Catalog.Products.Payloads;

public record GetProductsPayload(
    Guid? CategoryId,
    Guid? BrandId,
    decimal? MinPrice,
    decimal? MaxPrice,
    string? Search,
    string? SortBy,       // e.g. "price", "name", "rating"
    string? SortOrder,    // "asc" or "desc"
    int Page = 1,
    int PageSize = 10);