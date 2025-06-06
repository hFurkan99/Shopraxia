namespace Catalog.Features.Categories.CreateCategory;

public record CreateCategoryCommand(CreateCategoryPayload CategoryPayload) 
    : ICommand<CreateCategoryResult>;

public record CreateCategoryResult(Guid Id);