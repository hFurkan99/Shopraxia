namespace Catalog.Features.Categories.UpdateCategory;

public record UpdateCategoryCommand(
    Guid Id,
    string Name,
    string Slug,
    string? Description)
    : ICommand<UpdateCategoryResult>;

public record UpdateCategoryResult(bool IsSuccess);

internal class UpdateCategoryHandler(IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateCategoryCommand, UpdateCategoryResult>
{
    public async Task<UpdateCategoryResult> Handle(
        UpdateCategoryCommand command, 
        CancellationToken cancellationToken)
    {
        var category = await unitOfWork.Categories
            .GetByIdAsync(command.Id, cancellationToken)
            ?? throw new CategoryNotFoundException(command.Id);

        UpdateCategory(category, command.Name, 
            command.Slug,command.Description);

        unitOfWork.Categories.Update(category);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return new UpdateCategoryResult(true);
    }

    private static void UpdateCategory(
        Category category, 
        string name, 
        string slug, 
        string? description)
    {
        category.Update(name, slug, description);
    }
}   