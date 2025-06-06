namespace Catalog.Domain.ProductAggregate;

public interface IProductRepository : IGenericRepository<Product, Guid>
{
    Task<(List<Product> Data, int TotalCount)> GetFilteredProductsAsync(
        GetProductsQuery payload,
        CancellationToken cancellationToken);

    Task<Product?> GetProductWithVariantsById(Guid productId, CancellationToken cancellationToken);

    Task<Product?> GetProductWithVariantsBySlug(string productSlug, CancellationToken cancellationToken);
}