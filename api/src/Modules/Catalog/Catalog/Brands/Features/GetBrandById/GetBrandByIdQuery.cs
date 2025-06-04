namespace Catalog.Brands.Features.GetBrandById;

public record GetBrandByIdQuery(Guid BrandId) 
    : IQuery<GetBrandByIdResult>;

public record GetBrandByIdResult(
    Guid Id,
    string Name,
    string Slug,
    string Description);