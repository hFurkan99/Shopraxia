namespace Catalog.Categories.Features.CreateCategory;

public class CreateCategoryCommandValidator 
    : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(x => x.CategoryPayload.Name)
            .NotEmpty()
            .MaximumLength(200)
            .WithMessage("Category name must not be empty and cannot exceed 200 characters.");

        RuleFor(x => x.CategoryPayload.Slug)
            .NotEmpty()
            .MaximumLength(200)
            .WithMessage("Category slug must not be empty and cannot exceed 200 characters.");

        RuleFor(x => x.CategoryPayload.Description)
            .MaximumLength(1000)
            .WithMessage("Category description cannot exceed 1000 characters.");
    }
}