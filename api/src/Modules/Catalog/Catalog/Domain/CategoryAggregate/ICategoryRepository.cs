namespace Catalog.Domain.CategoryAggregate;

public interface ICategoryRepository : IGenericRepository<Category, Guid>
{
    Task<Category?> GetBySlugAsync(
        string slug,
        CancellationToken cancellationToken = default);

    Task<(List<CategoryDto> Data, int TotalCount)> GetFilteredCategoriesAsync(
        int Page = 1,
        int PageSize = 10,
        string? Search = null,
        string? SortBy = null,
        string? SortOrder = null,
        CancellationToken cancellationToken = default);
}