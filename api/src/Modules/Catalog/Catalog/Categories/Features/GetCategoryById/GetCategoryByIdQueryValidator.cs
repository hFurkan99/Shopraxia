namespace Catalog.Categories.Features.GetCategoryById;

public class GetCategoryByIdQueryValidator 
    : AbstractValidator<GetCategoryByIdQuery>
{
    public GetCategoryByIdQueryValidator()
    {
        RuleFor(x => x.CategoryId)
            .NotEmpty()
            .WithMessage("Category ID is required.");
    }
}   