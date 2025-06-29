namespace Catalog.Features.Brands.GetBrandBySlug;

public record GetBrandBySlugQuery(string Slug)
    : IQuery<GetBrandBySlugResult>;

public record GetBrandBySlugResult(
    Guid Id,
    string Name,
    string Slug,
    string? Description);

internal class GetBrandBySlugHandler(IUnitOfWork unitOfWork)
    : IQueryHandler<GetBrandBySlugQuery, GetBrandBySlugResult>
{
    public async Task<GetBrandBySlugResult> Handle(
        GetBrandBySlugQuery query,
        CancellationToken cancellationToken)
    {
        var brand = await unitOfWork.Brands
            .GetBySlugAsync(query.Slug, cancellationToken)
            ?? throw new BrandSlugNotFoundException(query.Slug);

        return new GetBrandBySlugResult(
            brand.Id,
            brand.Name,
            brand.Slug,
            brand.Description
        );
    }
}   