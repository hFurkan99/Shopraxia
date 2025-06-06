namespace Catalog.Features.Categories.DeleteCategory;

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