using Catalog.Domain.Common;

namespace Catalog.Features.Categories.GetCategoryBySlug;

internal class GetCategoryBySlugHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetCategoryBySlugQuery, GetCategoryBySlugResult>
{
    public async Task<GetCategoryBySlugResult> Handle(
        GetCategoryBySlugQuery query, 
        CancellationToken cancellationToken)
    {
        var category = await unitOfWork.Categories
            .GetBySlugAsync(query.Slug, cancellationToken)
            ?? throw new CategorySlugNotFoundException(query.Slug);

        return new GetCategoryBySlugResult(
            category.Id,
            category.Name,
            category.Slug,
            category.Description);
    }
}   