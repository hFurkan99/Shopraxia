namespace Catalog.Categories.Features.DeleteCategory;

public record DeleteCategoryCommand(Guid CategoryId) 
    : ICommand<DeleteCategoryResult>;

public record DeleteCategoryResult(bool IsSuccess); 