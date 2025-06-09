namespace Catalog.Features.Categories.GetCategories;

public record GetCategoriesQuery(
    int Page = 1,
    int PageSize = 10,
    string? Search = null,
    string? SortBy = null,
    string? SortOrder = null)
    : IQuery<GetCategoriesResult>;

public record GetCategoriesResult(PaginatedResult<CategoryDto> Categories);

internal class GetCategoriesHandler(IUnitOfWork unitOfWork)
    : IQueryHandler<GetCategoriesQuery, GetCategoriesResult>
{
    public async Task<GetCategoriesResult> Handle(
        GetCategoriesQuery query, 
        CancellationToken cancellationToken)
    {
        var (Data, TotalCount) = await unitOfWork.Categories
            .GetFilteredCategoriesAsync(query.Page, query.PageSize,
            query.Search, query.SortBy, query.SortOrder, cancellationToken);

        var categoryDtos = Data.Adapt<List<CategoryDto>>();
        var totalCount = TotalCount;

        return new GetCategoriesResult(
            new PaginatedResult<CategoryDto>(
                query.Page,
                query.PageSize,
                totalCount,
                categoryDtos));
    }
}           