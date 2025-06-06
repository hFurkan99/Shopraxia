using Catalog.Domain.Common;

namespace Catalog.Features.Categories.GetCategories;

internal class GetCategoriesHandler(IUnitOfWork unitOfWork)
    : IQueryHandler<GetCategoriesQuery, GetCategoriesResult>
{
    public async Task<GetCategoriesResult> Handle(
        GetCategoriesQuery query, 
        CancellationToken cancellationToken)
    {
        var categories = await unitOfWork.Categories
            .GetFilteredCategoriesAsync(query.CategoriesPayload, cancellationToken);

        var categoryDtos = categories.Data.Adapt<List<CategoryDto>>();
        var totalCount = categories.TotalCount;

        return new GetCategoriesResult(
            new PaginatedResult<CategoryDto>(
                query.CategoriesPayload.Page,
                query.CategoriesPayload.PageSize,
                totalCount,
                categoryDtos));
    }
}           