namespace Catalog.Categories.Features.DeleteCategory;

public class DeleteCategoryCommandValidator 
    : AbstractValidator<DeleteCategoryCommand>
{
    public DeleteCategoryCommandValidator()
    {
        RuleFor(x => x.CategoryId)
            .NotEmpty()
            .WithMessage("Category ID is required.");
    }
}   