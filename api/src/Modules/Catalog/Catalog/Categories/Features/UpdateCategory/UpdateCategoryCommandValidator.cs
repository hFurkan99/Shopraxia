namespace Catalog.Categories.Features.UpdateCategory;

public class UpdateCategoryCommandValidator 
    : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(x => x.CategoryPayload.Id)
            .NotEmpty()
            .WithMessage("Category ID is required.");

        RuleFor(x => x.CategoryPayload.Name)
            .NotEmpty()
            .MaximumLength(200)
            .WithMessage("Category name is required and must be less than 200 characters long.");

        RuleFor(x => x.CategoryPayload.Slug)
            .NotEmpty()
            .MaximumLength(200)
            .WithMessage("Category slug is required and must be less than 200 characters long.");

        RuleFor(x => x.CategoryPayload.Description)
            .MaximumLength(1000)
            .WithMessage("Category description must be less than 1000 characters long.");
    }
}