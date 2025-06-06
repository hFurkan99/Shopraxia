using Catalog.Domain.Common;

namespace Catalog.Features.Categories.DeleteCategory;

internal class DeleteCategoryHandler(IUnitOfWork unitOfWork)
    : ICommandHandler<DeleteCategoryCommand, DeleteCategoryResult>
{
    public async Task<DeleteCategoryResult> Handle(
        DeleteCategoryCommand command, 
        CancellationToken cancellationToken)
    {
        var category = await unitOfWork.Categories
            .GetByIdAsync(command.CategoryId, cancellationToken)
            ?? throw new CategoryNotFoundException(command.CategoryId);

        unitOfWork.Categories.Delete(category);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new DeleteCategoryResult(true);
    }
}   