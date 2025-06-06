namespace Catalog.Features.Brands.GetBrands;

public record GetBrandsQuery(
    int Page = 1,
    int PageSize = 10,
    string? Search = null,
    string? SortBy = null,
    string? SortOrder = null)
    : IQuery<GetBrandsResult>;

public record GetBrandsResult(PaginatedResult<BrandDto> Brands);