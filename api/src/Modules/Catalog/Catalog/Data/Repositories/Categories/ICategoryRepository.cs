namespace Catalog.Data.Repositories.Categories;

public interface ICategoryRepository : IGenericRepository<Category, Guid>
{
    Task<Category?> GetBySlugAsync(
        string categorySlug,
        CancellationToken cancellationToken = default);

    Task<(List<Category> Data, int TotalCount)> GetFilteredCategoriesAsync(
        GetCategoriesPayload payload,
        CancellationToken cancellationToken = default);
}