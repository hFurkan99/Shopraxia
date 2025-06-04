namespace Catalog.Brands.Features.GetBrandBySlug;

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