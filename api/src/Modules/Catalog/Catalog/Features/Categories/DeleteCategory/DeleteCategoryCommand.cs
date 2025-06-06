namespace Catalog.Features.Categories.DeleteCategory;

public record DeleteCategoryCommand(Guid CategoryId) 
    : ICommand<DeleteCategoryResult>;

public record DeleteCategoryResult(bool IsSuccess); 