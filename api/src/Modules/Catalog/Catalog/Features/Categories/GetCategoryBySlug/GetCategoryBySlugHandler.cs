namespace Catalog.Features.Categories.GetCategoryBySlug;

public record GetCategoryBySlugQuery(string Slug)
    : IQuery<GetCategoryBySlugResult>;

public record GetCategoryBySlugResult(
    Guid Id,
    string Name,
    string Slug,
    string? Description);

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