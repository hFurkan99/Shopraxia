namespace Catalog.Infrastructure.Persistence.Repositories;

public class CategoryRepository(CatalogDbContext context)
    : GenericRepository<Category, Guid>(context), ICategoryRepository
{
    public async Task<Category?> GetBySlugAsync(
        string categorySlug, 
        CancellationToken cancellationToken = default)
    {
        return await _dbSet.AsNoTracking()
            .FirstOrDefaultAsync(b => b.Slug == categorySlug, cancellationToken);
    }

    public async Task<(List<CategoryDto> Data, int TotalCount)> GetFilteredCategoriesAsync(
        int page = 1,
        int pageSize = 10,
        string? search = null,
        string? sortBy = null,
        string? sortOrder = null, 
        CancellationToken cancellationToken = default)
    {
        var query = _dbSet.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(
                b => b.Name.ToLower().Contains(search.ToLower()) 
                || b.Slug.ToLower().Contains(search.ToLower()));
        }

        if (!string.IsNullOrWhiteSpace(sortBy))
        {
            bool ascending = sortOrder?.ToLower() != "desc";
            query = sortBy.ToLower() switch
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
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        var itemsDto = items.Select(c => new CategoryDto(
            c.Id, c.Name, c.Slug, c.Description)).ToList();

        return (itemsDto, totalCount);
    }
}