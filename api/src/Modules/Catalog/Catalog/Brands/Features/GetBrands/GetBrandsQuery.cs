namespace Catalog.Brands.Features.GetBrands;

public record GetBrandsQuery(GetBrandsPayload BrandsPayload) 
    : IQuery<GetBrandsResult>;

public record GetBrandsResult(PaginatedResult<BrandDto> Brands);