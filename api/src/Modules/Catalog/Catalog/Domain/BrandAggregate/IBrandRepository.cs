namespace Catalog.Domain.BrandAggregate;

public interface IBrandRepository : IGenericRepository<Brand, Guid>
{
    Task<Brand?> GetBySlugAsync(
        string slug,
        CancellationToken cancellationToken = default);

    Task<(List<Brand> Data, int TotalCount)> GetFilteredBrandsAsync(
        GetBrandsQuery query,
        CancellationToken cancellationToken = default);
}