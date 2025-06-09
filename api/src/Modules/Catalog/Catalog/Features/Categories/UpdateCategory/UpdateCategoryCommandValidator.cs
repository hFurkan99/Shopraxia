namespace Catalog.Features.Categories.UpdateCategory;

public class UpdateCategoryCommandValidator 
    : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Category ID is required.");

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200)
            .WithMessage("Category name is required and must be less than 200 characters long.");

        RuleFor(x => x.Slug)
            .NotEmpty()
            .MaximumLength(200)
            .WithMessage("Category slug is required and must be less than 200 characters long.");

        RuleFor(x => x.Description)
            .MaximumLength(1000)
            .WithMessage("Category description must be less than 1000 characters long.");
    }
}