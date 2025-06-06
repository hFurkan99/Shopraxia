namespace Catalog.Features.Categories.GetCategoryBySlug;

public record GetCategoryBySlugQuery(string Slug) 
    : IQuery<GetCategoryBySlugResult>;

public record GetCategoryBySlugResult(
    Guid Id,
    string Name,
    string Slug,
    string Description);   