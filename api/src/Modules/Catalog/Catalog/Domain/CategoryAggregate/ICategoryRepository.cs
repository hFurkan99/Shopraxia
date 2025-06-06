namespace Catalog.Domain.CategoryAggregate;

public interface ICategoryRepository : IGenericRepository<Category, Guid>
{
    Task<Category?> GetBySlugAsync(
        string slug,
        CancellationToken cancellationToken = default);

    Task<(List<Category> Data, int TotalCount)> GetFilteredCategoriesAsync(
        GetCategoriesQuery query,
        CancellationToken cancellationToken = default);
}