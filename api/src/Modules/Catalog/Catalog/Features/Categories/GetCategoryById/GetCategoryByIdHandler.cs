using Catalog.Domain.Common;

namespace Catalog.Features.Categories.GetCategoryById;

internal class GetCategoryByIdHandler(IUnitOfWork unitOfWork)
    : IQueryHandler<GetCategoryByIdQuery, GetCategoryByIdResult>
{
    public async Task<GetCategoryByIdResult> Handle(
        GetCategoryByIdQuery query, 
        CancellationToken cancellationToken)
    {
        var category = await unitOfWork.Categories
            .GetByIdAsync(query.CategoryId, cancellationToken)
            ?? throw new CategoryNotFoundException(query.CategoryId);

        return new GetCategoryByIdResult(
            category.Id,
            category.Name,
            category.Slug,
            category.Description);
    }
}   