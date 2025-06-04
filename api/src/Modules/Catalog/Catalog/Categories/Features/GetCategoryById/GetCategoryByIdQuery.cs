namespace Catalog.Categories.Features.GetCategoryById;

public record GetCategoryByIdQuery(Guid CategoryId) 
    : IQuery<GetCategoryByIdResult>;

public record GetCategoryByIdResult(
    Guid Id,
    string Name,
    string Slug,
    string Description); 