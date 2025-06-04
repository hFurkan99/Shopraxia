namespace Catalog.Data.Repositories.Brands;

public interface IBrandRepository : IGenericRepository<Brand, Guid>
{
    Task<Brand?> GetBySlugAsync(
        string brandSlug,
        CancellationToken cancellationToken = default);

    Task<(List<Brand> Data, int TotalCount)> GetFilteredBrandsAsync(
        GetBrandsPayload payload,
        CancellationToken cancellationToken = default);
}