namespace Catalog.Brands.Payloads;

public record GetBrandsPayload(
    int Page = 1,
    int PageSize = 10,
    string? Search = null,
    string? SortBy = null,       // e.g. "name", "slug"
    string? SortOrder = null      // "asc" or "desc"
);
