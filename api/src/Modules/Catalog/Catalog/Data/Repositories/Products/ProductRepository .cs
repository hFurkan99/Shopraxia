namespace Catalog.Data.Repositories.Products;

public class ProductRepository(CatalogDbContext context)
    : GenericRepository<Product, Guid>(context), IProductRepository
{
    public async Task<(List<Product> Data, int TotalCount)> GetFilteredProductsAsync(GetProductsPayload payload, 
        CancellationToken cancellationToken)
    {
        var query = _context.Products
            .Include(p => p.Variants.Where(v => v.Stock > 0))
                .ThenInclude(v => v.Attributes)
            .Include(p => p.Variants)
                .ThenInclude(v => v.Images)
            .Where(p => p.Variants.Any(v => v.Stock > 0))
            .AsQueryable();

        if (payload.CategoryId.HasValue)
            query = query.Where(p => p.CategoryId == payload.CategoryId);

        if (payload.BrandId.HasValue)
            query = query.Where(p => p.BrandId == payload.BrandId);

        if (payload.MinPrice.HasValue)
            query = query.Where(p => p.Variants.Any(v => v.Price >= payload.MinPrice.Value));

        if (payload.MaxPrice.HasValue)
            query = query.Where(p => p.Variants.Any(v => v.Price <= payload.MaxPrice.Value));

        if (!string.IsNullOrWhiteSpace(payload.Search))
        {
            var search = payload.Search.ToLower();
            query = query.Where(p =>
                p.Name.ToLower().Contains(search) ||
                p.Slug.ToLower().Contains(search) ||
                p.Description.ToLower().Contains(search));
        }

        if (!string.IsNullOrWhiteSpace(payload.SortBy))
        {
            bool ascending = payload.SortOrder?.ToLower() != "desc";
            query = payload.SortBy.ToLower() switch
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
            .Skip((payload.Page - 1) * payload.PageSize)
            .Take(payload.PageSize)
            .ToListAsync(cancellationToken);

        return (items, totalCount);
    }

    public async Task<Product?> GetProductWithVariantsById(Guid productId, CancellationToken cancellationToken)
    {
        return await _context.Products
            .Include(p => p.Variants)
                .ThenInclude(v => v.Attributes)
            .Include(p => p.Variants)
                .ThenInclude(v => v.Images)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == productId, cancellationToken);
    }

    public async Task<Product?> GetProductWithVariantsBySlug(string productSlug, CancellationToken cancellationToken)
    {
        return await _context.Products
            .Include(p => p.Variants)
                .ThenInclude(v => v.Attributes)
            .Include(p => p.Variants)
                .ThenInclude(v => v.Images)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Slug == productSlug, cancellationToken);
    }
}