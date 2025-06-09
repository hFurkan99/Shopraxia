namespace Catalog.Infrastructure.Persistence.Repositories;

public class ProductRepository(CatalogDbContext context)
    : GenericRepository<Product, Guid>(context), IProductRepository
{
    public async Task<(List<Product> Data, int TotalCount)> GetFilteredProductsAsync(
        Guid? brandId,
        Guid? categoryId,
        decimal? minPrice,
        decimal? maxPrice,
        string? search,
        string? sortBy,
        string? sortOrder,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var query = _context.Products
            .Include(p => p.Category)
            .Include(p => p.Brand)
            .Include(p => p.Variants.Where(v => v.Stock > 0))
                .ThenInclude(v => v.VariantAttributes)
            .Include(p => p.Variants)
                .ThenInclude(v => v.Images)
            .Where(p => p.Variants.Any(v => v.Stock > 0))
            .AsQueryable();

        if (categoryId.HasValue)
            query = query.Where(p => p.CategoryId == categoryId);

        if (brandId.HasValue)
            query = query.Where(p => p.BrandId == brandId);

        if (minPrice.HasValue)
            query = query.Where(p => p.Variants.Any(v => v.Price >= minPrice.Value));

        if (maxPrice.HasValue)
            query = query.Where(p => p.Variants.Any(v => v.Price <= maxPrice.Value));

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(p =>
                p.Name.ToLower().Contains(search.ToLower()) ||
                p.Slug.ToLower().Contains(search.ToLower()) ||
                p.Description.ToLower().Contains(search.ToLower()));
        }

        if (!string.IsNullOrWhiteSpace(sortBy))
        {
            bool ascending = sortOrder?.ToLower() != "desc";
            query = sortBy.ToLower() switch
            {
                "price" => ascending
                    ? query.OrderBy(p => p.Variants.Min(v => v.Price))
                    : query.OrderByDescending(p => p.Variants.Min(v => v.Price)),
                "name" => ascending
                    ? query.OrderBy(p => p.Name)
                    : query.OrderByDescending(p => p.Name),
                "rating" => ascending
                    ? query.OrderBy(p => p.Rating)
                    : query.OrderByDescending(p => p.Rating),
                _ => query.OrderBy(p => p.Id)
            };
        }
        else query = query.OrderBy(p => p.Id);

        var totalCount = await query.CountAsync(cancellationToken);

        var items = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return (items, totalCount);
    }

    public async Task<Product?> GetProductWithVariantsById(Guid productId, CancellationToken cancellationToken)
    {
        return await _context.Products
            .Include(p => p.Category)
            .Include(p => p.Brand)
            .Include(p => p.Variants)
                .ThenInclude(v => v.VariantAttributes)
            .Include(p => p.Variants)
                .ThenInclude(v => v.Images)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == productId, cancellationToken);
    }

    public async Task<Product?> GetProductWithVariantsBySlug(string productSlug, CancellationToken cancellationToken)
    {
        return await _context.Products
            .Include(p => p.Category)
            .Include(p => p.Brand)
            .Include(p => p.Variants)
                .ThenInclude(v => v.VariantAttributes)
            .Include(p => p.Variants)
                .ThenInclude(v => v.Images)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Slug == productSlug, cancellationToken);
    }
}