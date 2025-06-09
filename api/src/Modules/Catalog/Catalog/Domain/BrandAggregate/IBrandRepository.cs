namespace Catalog.Domain.BrandAggregate;

public interface IBrandRepository : IGenericRepository<Brand, Guid>
{
    Task<Brand?> GetBySlugAsync(
        string slug,
        CancellationToken cancellationToken = default);

    Task<(List<Brand> Data, int TotalCount)> GetFilteredBrandsAsync(
        int page = 1,
        int pageSize = 10,
        string? search = null,
        string? sortBy = null,
        string? sortOrder = null,
        CancellationToken cancellationToken = default);
}