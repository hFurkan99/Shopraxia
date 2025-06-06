namespace Catalog.Features.Categories.UpdateCategory;

public record UpdateCategoryCommand(UpdateCategoryPayload CategoryPayload) 
    : ICommand<UpdateCategoryResult>;

public record UpdateCategoryResult(bool IsSuccess);