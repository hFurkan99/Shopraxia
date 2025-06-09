namespace Catalog.Domain.ProductAggregate;

public interface IProductRepository : IGenericRepository<Product, Guid>
{
    Task<(List<Product> Data, int TotalCount)> GetFilteredProductsAsync(
        Guid? brandId,
        Guid? categoryId,
        decimal? minPrice,
        decimal? maxPrice,
        string? search,
        string? sortBy,
        string? sortOrder,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default);

    Task<Product?> GetProductWithVariantsById(Guid productId, CancellationToken cancellationToken);

    Task<Product?> GetProductWithVariantsBySlug(string productSlug, CancellationToken cancellationToken);
}