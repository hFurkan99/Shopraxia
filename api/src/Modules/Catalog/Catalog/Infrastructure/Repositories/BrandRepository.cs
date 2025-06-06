using Catalog.Domain.BrandAggregate;
using Catalog.Infrastructure.Persistence;

namespace Catalog.Infrastructure.Repositories;

public class BrandRepository(CatalogDbContext context)
    : GenericRepository<Brand, Guid>(context), IBrandRepository
{
    public async Task<Brand?> GetBySlugAsync(string brandSlug, CancellationToken cancellationToken = default)
    {
        return await _dbSet.AsNoTracking()
            .FirstOrDefaultAsync(b => b.Slug == brandSlug, cancellationToken);
    }

    public async Task<(List<Brand> Data, int TotalCount)> GetFilteredBrandsAsync(GetBrandsPayload payload, CancellationToken cancellationToken = default)
    {
        var query = _dbSet.AsQueryable();

        if (!string.IsNullOrWhiteSpace(payload.Search))
        {
            var search = payload.Search.ToLower();
            query = query.Where(b => b.Name.ToLower().Contains(search) || b.Slug.ToLower().Contains(search));
        }

        if (!string.IsNullOrWhiteSpace(payload.SortBy))
        {
            bool ascending = payload.SortOrder?.ToLower() != "desc";
            query = payload.SortBy.ToLower() switch
            {
                "name" => ascending ? query.OrderBy(b => b.Name) : query.OrderByDescending(b => b.Name),
                _ => query.OrderBy(b => b.Id)
            };
        }
        else
        {
            query = query.OrderBy(b => b.Id);
        }

        var totalCount = await query.CountAsync(cancellationToken);

        var items = await query
            .Skip((payload.Page - 1) * payload.PageSize)
            .Take(payload.PageSize)
            .ToListAsync(cancellationToken);

        return (items, totalCount);
    }
}