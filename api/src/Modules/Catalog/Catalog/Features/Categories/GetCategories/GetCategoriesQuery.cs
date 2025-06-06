namespace Catalog.Features.Categories.GetCategories;

public record GetCategoriesQuery(GetCategoriesPayload CategoriesPayload) 
    : IQuery<GetCategoriesResult>;

public record GetCategoriesResult(PaginatedResult<CategoryDto> Categories);