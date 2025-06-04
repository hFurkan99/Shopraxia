namespace Catalog.Brands.Features.GetBrandBySlug;

public record GetBrandBySlugQuery(string Slug) 
    : IQuery<GetBrandBySlugResult>;

public record GetBrandBySlugResult(
    Guid Id,
    string Name,
    string Slug,
    string Description);