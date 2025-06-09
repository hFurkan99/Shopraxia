namespace Catalog.Features.Brands.GetBrands;

public record GetBrandsQuery(
    int Page = 1,
    int PageSize = 10,
    string? Search = null,
    string? SortBy = null,
    string? SortOrder = null)
    : IQuery<GetBrandsResult>;

public record GetBrandsResult(PaginatedResult<BrandDto> Brands);

internal class GetBrandsHandler(IUnitOfWork unitOfWork)
    : IQueryHandler<GetBrandsQuery, GetBrandsResult>
{
    public async Task<GetBrandsResult> Handle(
        GetBrandsQuery query,
        CancellationToken cancellationToken)
    {
        var (Data, TotalCount) = await unitOfWork.Brands
            .GetFilteredBrandsAsync(query.Page, query.PageSize,
            query.Search, query.SortBy, query.SortOrder, cancellationToken);

        var brandDtos = Data.Adapt<List<BrandDto>>();
        var totalCount = TotalCount;

        return new GetBrandsResult(
            new PaginatedResult<BrandDto>(
                query.Page,
                query.PageSize,
                totalCount,
                brandDtos));
    }
}   