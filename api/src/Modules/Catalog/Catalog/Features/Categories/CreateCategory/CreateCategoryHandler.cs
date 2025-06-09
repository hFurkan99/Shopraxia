namespace Catalog.Features.Categories.CreateCategory;

public record CreateCategoryCommand(
    string Name,
    string Slug,
    string? Description)
    : ICommand<CreateCategoryResult>;

public record CreateCategoryResult(Guid Id);

internal class CreateCategoryHandler(IUnitOfWork unitOfWork)
    : ICommandHandler<CreateCategoryCommand, CreateCategoryResult>
{
    public async Task<CreateCategoryResult> Handle(
        CreateCategoryCommand command, 
        CancellationToken cancellationToken)
    {
        var category = CreateNewCategory(command.Name, command.Slug,
            command.Description);

        await unitOfWork.Categories.AddAsync(category, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new CreateCategoryResult(category.Id);
    }

    private static Category CreateNewCategory(
        string name,
        string slug,
        string? description)
    {
        var category = Category.Create(name, slug, description);
        return category;
    }
}