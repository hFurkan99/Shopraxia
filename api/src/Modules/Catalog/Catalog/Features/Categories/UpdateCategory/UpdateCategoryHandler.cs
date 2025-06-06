using Catalog.Domain.Common;

namespace Catalog.Features.Categories.UpdateCategory;

internal class UpdateCategoryHandler(IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateCategoryCommand, UpdateCategoryResult>
{
    public async Task<UpdateCategoryResult> Handle(
        UpdateCategoryCommand command, 
        CancellationToken cancellationToken)
    {
        var category = await unitOfWork.Categories
            .GetByIdAsync(command.CategoryPayload.Id, cancellationToken)
            ?? throw new CategoryNotFoundException(command.CategoryPayload.Id);

        UpdateCategory(category, command.CategoryPayload);

        unitOfWork.Categories.Update(category);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return new UpdateCategoryResult(true);
    }

    private static void UpdateCategory(Category category, UpdateCategoryPayload categoryPayload)
    {
        category.Update(categoryPayload);
    }
}   