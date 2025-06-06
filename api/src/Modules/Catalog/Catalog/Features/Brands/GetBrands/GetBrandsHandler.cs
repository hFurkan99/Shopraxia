using Catalog.Domain.Common;

namespace Catalog.Features.Brands.GetBrands;

internal class GetBrandsHandler(IUnitOfWork unitOfWork)
    : IQueryHandler<GetBrandsQuery, GetBrandsResult>
{
    public async Task<GetBrandsResult> Handle(
        GetBrandsQuery query,
        CancellationToken cancellationToken)
    {
        var brands = await unitOfWork.Brands
            .GetFilteredBrandsAsync(query.BrandsPayload, cancellationToken);

        var brandDtos = brands.Data.Adapt<List<BrandDto>>();
        var totalCount = brands.TotalCount;

        return new GetBrandsResult(
            new PaginatedResult<BrandDto>(
                query.BrandsPayload.Page,
                query.BrandsPayload.PageSize,
                totalCount,
                brandDtos));
    }
}   