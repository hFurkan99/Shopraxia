namespace Catalog.Categories.Features.CreateCategory;

public record CreateCategoryCommand(CreateCategoryPayload CategoryPayload) 
    : ICommand<CreateCategoryResult>;

public record CreateCategoryResult(Guid Id);