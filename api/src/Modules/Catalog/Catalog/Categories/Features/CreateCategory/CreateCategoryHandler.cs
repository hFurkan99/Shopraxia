namespace Catalog.Categories.Features.CreateCategory;

internal class CreateCategoryHandler(IUnitOfWork unitOfWork)
    : ICommandHandler<CreateCategoryCommand, CreateCategoryResult>
{
    public async Task<CreateCategoryResult> Handle(
        CreateCategoryCommand command, 
        CancellationToken cancellationToken)
    {
        var categoryPayload = command.CategoryPayload;
        var category = CreateNewCategory(categoryPayload);
        await unitOfWork.Categories.AddAsync(category, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new CreateCategoryResult(category.Id);
    }

    private static Category CreateNewCategory(CreateCategoryPayload categoryPayload)
    {
        var category = Category.Create(categoryPayload);
        return category;
    }
}