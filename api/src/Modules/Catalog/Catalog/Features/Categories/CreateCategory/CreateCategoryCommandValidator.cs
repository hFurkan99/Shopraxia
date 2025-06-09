namespace Catalog.Features.Categories.CreateCategory;

public class CreateCategoryCommandValidator 
    : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200)
            .WithMessage("Category name must not be empty and cannot exceed 200 characters.");

        RuleFor(x => x.Slug)
            .NotEmpty()
            .MaximumLength(200)
            .WithMessage("Category slug must not be empty and cannot exceed 200 characters.");

        RuleFor(x => x.Description)
            .MaximumLength(1000)
            .WithMessage("Category description cannot exceed 1000 characters.");
    }
}