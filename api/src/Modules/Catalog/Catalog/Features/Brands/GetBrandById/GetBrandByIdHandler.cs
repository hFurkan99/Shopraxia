namespace Catalog.Features.Brands.GetBrandById;

public record GetBrandByIdQuery(Guid BrandId)
    : IQuery<GetBrandByIdResult>;

public record GetBrandByIdResult(
    Guid Id,
    string Name,
    string Slug,
    string? Description);

internal class GetBrandByIdHandler(IUnitOfWork unitOfWork)
    : IQueryHandler<GetBrandByIdQuery, GetBrandByIdResult>
{
    public async Task<GetBrandByIdResult> Handle(
        GetBrandByIdQuery query,
        CancellationToken cancellationToken)
    {
        var brand = await unitOfWork.Brands
            .GetByIdAsync(query.BrandId, cancellationToken)
            ?? throw new BrandNotFoundException(query.BrandId);

        return new GetBrandByIdResult(
            brand.Id,
            brand.Name,
            brand.Slug,
            brand.Description);
    }
}